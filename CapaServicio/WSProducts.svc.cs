using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using CapaNegocio;
using CapaDatos;

namespace CapaServicio
{
     public class WSProducts : IWSProducts
    {

        Business busi = new Business();
        CapaServicio.Product IWSProducts.GetProduct(int productid)
        {
            

            CapaDatos.Product prod = new CapaDatos.Product();
            //prod.ProductId = productid;

            if (productid > 0)
            {
                return new Product()
                {
                    ProductType = prod.ProductType,
                    ProductName = prod.ProductName,
                    ProductPrice = prod.ProductPrice,
                    ProductStock = prod.ProductStock,
                    ProductDescription = prod.ProductDescription
                };

            }
            else
            {
                return new Product()
                {
                    Error = "Id no encontrado"
                };
            }
        }

        

    }
}
