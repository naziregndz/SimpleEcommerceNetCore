using Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebAPI.Operations
{
    public static class OrderOperations
    {
        public static bool CreateOrder(int customerId, int addressId)
        {
            decimal totalPrice = 0;
            try
            {
                using (var session = SessionFactoryBuilder.OpenSession())
                {
                    var cartList = session.QueryOver<Cart>().Where(x => x.CustomerId == customerId && x.Status == 1).List();
                    foreach (var cartItem in cartList)
                    {
                        Order orderObj = new Order();
                        orderObj.CustomerId = customerId;
                        orderObj.ProductId = cartItem.ProductId;
                        orderObj.UnitPrice = cartItem.UnitPrice;
                        if (cartItem.Quantity > 1)
                            orderObj.TotalPrice = cartItem.Quantity * cartItem.UnitPrice;
                        else
                            orderObj.TotalPrice = cartItem.UnitPrice;
                        orderObj.Status = 1;//sipariş tamamlandı.
                        orderObj.AddressId = addressId;
                        orderObj.InsertDatetime = System.DateTime.Now;
                        session.Save(orderObj);
                        session.Clear();
                        cartItem.Status = 0;
                        using (ITransaction transaction = session.BeginTransaction())
                        {
                            session.Clear();
                            session.SaveOrUpdate(cartItem);
                            transaction.Commit();
                        }
                        totalPrice += orderObj.UnitPrice;
                    }

                    var couponList = session.QueryOver<Coupon>().Where(x => x.CustomerId == customerId && x.Status == 1).List();
                    if (couponList.Count > 0)
                    {
                        totalPrice = totalPrice - (totalPrice * couponList[0].Discount / 100); //CartDetail tablosu yapılarak toplam fiyattan düşülebilir.
                    }
                }
                return true; //json formatında dönülecek
            }
            catch (Exception ex)
            {
                //rollback yapılacak.
                //log atılacak.
                //json formatında dönülecek
                return false;
            }
        }

        public static bool AddToCart(int productId, string email)
        {
            try
            {
                using (var session = SessionFactoryBuilder.OpenSession())
                {
                    int discount = 0;
                    var productList = session.QueryOver<Product>().Where(x => x.Id == productId).List();
                    var customerList = session.QueryOver<Customer>().Where(x => x.Email == email).List();

                    var cartList = session.QueryOver<Cart>().Where(x => x.CustomerId == customerList[0].Id && x.Status == 1).List();
                    if (productList != null && productList.Count > 0)
                    {
                        if (cartList != null && cartList.Count == 0)
                        {
                            CreateNewCart(session, productList[0], customerList[0].Id);
                        }
                        else
                        {
                            CreateOrUpdateCart(session, cartList[0], productList[0], productId, customerList[0].Id);
                        }

                        if (discount > 0)
                        {
                            cartList[0].TotalPrice = cartList[0].TotalPrice - (cartList[0].TotalPrice * discount / 100);
                            session.SaveOrUpdate(cartList[0]);
                            session.Clear();
                        }
                    }
                    return true; //json formatında dönülecek
                }
            }
            catch (Exception ex)
            {
                //rollback yapılacak.
                //log atılacak.
                return false; //json formatında dönülecek
            }
        } //websitesinden sepete ekle yapıldığında sadece eklendi mesajı dönüyor ekleme işlemi yapılmıyor. Web sitesindeki product Id bilgilerinin gönderilmesi gerek.

        public static bool DeleteFromCart(int customerId, int productId)
        {
            try
            {
                using (var session = SessionFactoryBuilder.OpenSession())
                {
                    var cartItems = session.QueryOver<Cart>().Where(x => x.CustomerId == customerId && x.ProductId == productId && x.Status == 1).List();
                    session.Delete(cartItems[0]);
                }
                return true; //json formatında dönülecek
            }
            catch (Exception ex)
            {
                //rollback yapılacak.
                //log atılacak.
                return false; //json formatında dönülecek
            }
        }

        public static List<Cart> GetCartDetail(int customerId)
        {
            try
            {
                List<Cart> cartItems = new List<Cart>();
                using (var session = SessionFactoryBuilder.OpenSession())
                {
                    cartItems = (List<Cart>)session.QueryOver<Cart>().Where(x => x.CustomerId == customerId && x.Status == 1).List();
                }
                return cartItems; //json formatında dönülecek
            }
            catch (Exception ex)
            {
                //log atılacak.
                return null; //json formatında dönülecek
            }
        }

        public static void CreateNewCart(ISession session,Product product,int customerId)
        {
            try
            {
                var productList = session.QueryOver<Product>().Where(x => x.Id == product.Id).List(); //tek kayıt gelenlerde object şeklinde alınacak.
                Cart newcartObj = new Cart();
                newcartObj.ProductId = product.Id;
                newcartObj.CustomerId = customerId;
                newcartObj.Quantity = 1;
                newcartObj.Status = 1;
                newcartObj.UnitPrice = product.Price;
                newcartObj.TotalPrice = product.Price;
                if (productList.Count > 0)
                    newcartObj.ProductName = productList[0].ProductName;
                session.Save(newcartObj);
                session.Flush();
                session.Clear();
                //json formatında dönülecek
            }
            catch (Exception ex)
            {
                //rollback yapılacak.
                //log atılacak.
                //json formatında dönülecek
            }
        }

        public static void CreateOrUpdateCart(ISession session, Cart cart,Product product,int productId,int customerId)
        {
            try
            {
                if (cart.ProductId == productId)
                {
                    cart.UnitPrice = product.Price;
                    cart.TotalPrice += product.Price;
                    cart.Quantity++;
                    cart.Status = 1;
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Clear();
                        session.SaveOrUpdate(cart);
                        transaction.Commit();
                    }
                }
                else
                {
                    cart.Status = 1;
                    cart.ProductId = productId;
                    cart.CustomerId = customerId;
                    cart.Quantity = 1;
                    cart.UnitPrice = product.Price;
                    cart.TotalPrice = product.Price;
                    session.Clear();
                    session.Save(cart);
                    //json formatında dönülecek
                }
            }
            catch (Exception ex)
            {
                //rollback yapılacak.
                //log atılacak.
                //json formatında dönülecek
            }
        }
    }
}
