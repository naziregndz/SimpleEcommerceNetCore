using Entities;
using NetCoreWebAPI.Operations.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebAPI.Operations
{
    public class AccountOperations
    {
        public static bool Login(string email, string password)
        {
            try
            {
                using (var session = SessionFactoryBuilder.OpenSession())
                {
                    var accountObj = session.QueryOver<Customer>().Where(x => x.Email == email).List();
                    if (accountObj != null && accountObj.Count > 0)
                    {
                        if (accountObj[0].Password == password) //hash tutulacak
                        {
                            return true;//json formatında dönülecek
                        }
  
                    }
                    return false;
                    //json formatında dönülecek
                }
            }
            catch (Exception ex)
            {
                //log atılacak.
                //json formatında dönülecek
                return false;
            }
        }

        public static int CreateCoupon(string email) //yeni yelik oluşturulurken bu metod çağrılır.
        {
            try
            {
                int discount = 0;
                using (var session = SessionFactoryBuilder.OpenSession())
                {
                    var customerList = session.QueryOver<Customer>().Where(x => x.Email == email).List();
                    if (customerList.Count == 0)
                    {
                        Coupon couponObj = new Coupon();
                        couponObj.CustomerId = customerList[0].Id;
                        couponObj.Discount = 5; //%5 hesabı yapılabilir.
                        session.Save(couponObj);
                        session.Clear();
                    }
                    return discount;//json formatında başarılı sonuç dönülecek.
                }
            }
            catch (Exception ex)
            {
                //rollback yapılacak.
                //log atılacak.
                return 0; //json formatında hata dönülecek.
            }
        }
    }
}