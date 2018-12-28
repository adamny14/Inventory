using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Invintory.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
       

        [HttpGet("[action]")]
        public IEnumerable<Products> ReturnProducts()
        {

            var context = new InventoryDBContext();
            var products = context.Products.FromSql("select * from \"Products\";").ToList();

            var allProd = from prod in products
                          select new { ID = prod.Id, Name = prod.Name, Company = prod.Company, Location = prod.Location, DatePurchased = prod.DatePurchased, Quantity = prod.Quantity, Color = prod.Color, Type = prod.Type };

            List<Products> result = new List<Products>();

            foreach(var item in allProd)
            {
                result.Add(new Products { Id = item.ID, Name = item.Name, Company = item.Company, Location = item.Location, DatePurchased = item.DatePurchased, Quantity = item.Quantity, Color = item.Color, Type = item.Type  });
            }
         

            IEnumerable<Products> returnedResult = result;

            return returnedResult;


        }
    }
   
            
        

       
}

