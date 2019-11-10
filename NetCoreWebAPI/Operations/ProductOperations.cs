using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebAPI.Operations
{
    public static class ProductOperations 
    {
        public static List<Product> GetProductList()
        {
            try
            {
                using (var session = SessionFactoryBuilder.OpenSession())
                {
                    var productList = session.Query<Product>().ToList();
                    if (productList != null && productList.Count > 0)
                        foreach (Product productItem in productList.ToList())
                        {
                            if (productItem.Stock == 0)
                                productList.Remove(productItem);
                        }

                    return productList; //json formatında dönülecek
                }
            }
            catch (Exception ex)
            {
                //log atılacak.
                return null; //json formatında dönülecek
            }
        }
    }
}
