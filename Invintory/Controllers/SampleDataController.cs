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
        public IEnumerable<Items> ReturnProducts()
        {

            var context = new InventoryDBContext();
            var products = context.Items.FromSql("select * from \"Items\";").ToList();

            var allVal = from itm in products
                          select new { ID = itm.Id, Name = itm.Name, Company = itm.Company, Location = itm.Location, DatePurchased = itm.DatePurchased, Quantity = itm.Quantity, Color = itm.Color, Type = itm.Type, itm.Serial, itm.Photo };

            List<Items> result = new List<Items>();

            foreach(var item in allVal)
            {
                DateTime date = (DateTime) item.DatePurchased;
                result.Add(new Items { Id = item.ID, Name = item.Name, Company = item.Company, Location = item.Location, DatePurchased = date.Date, Quantity = item.Quantity, Color = item.Color, Type = item.Type, Serial = item.Serial, Photo = item.Photo  });
            }
         

            IEnumerable<Items> returnedResult = result;

            return returnedResult;


        }
    }
   
            
        

       
}

