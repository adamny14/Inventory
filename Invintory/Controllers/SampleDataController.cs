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
    public partial class ResultItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string DatePurchased { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
        public byte[] Photo { get; set; }
        public string Color { get; set; }
        public string Company { get; set; }
        public string Serial { get; set; }
        public string AdditionalData { get; set; }
    }

    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
       

        [HttpGet("[action]")]
        public IEnumerable<ResultItem> ReturnProducts()
        {

            var context = new InventoryDBContext();
            var products = context.Items.FromSql("select * from \"Items\";").ToList();

            var allVal = from itm in products
                          select new { ID = itm.Id, Name = itm.Name, Company = itm.Company, Location = itm.Location, DatePurchased = itm.DatePurchased, Quantity = itm.Quantity, Color = itm.Color, Type = itm.Type, itm.Serial, itm.Photo };

            List<ResultItem> result = new List<ResultItem>();

            foreach(var item in allVal)
            {
                DateTime date = (DateTime)item.DatePurchased;
                string formattedDate = date.Date.ToString("MM-dd-yyyy");
                result.Add(new ResultItem { Id = item.ID, Name = item.Name, Company = item.Company, Location = item.Location, DatePurchased = formattedDate, Quantity = item.Quantity, Color = item.Color, Type = item.Type, Serial = item.Serial, Photo = item.Photo  });
            }
         

            IEnumerable<ResultItem> returnedResult = result;

            return returnedResult;


        }
    }
   
            
        

       
}

