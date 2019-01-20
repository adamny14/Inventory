
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Invintory.Controllers
{
    [Route("api/[controller]")]
    public class UploadDataController : Controller
    {


        [HttpPost("[action]")]
        public dynamic Upload(IFormCollection form)
        {
            var context = new InventoryDBContext();
            //var products = context.Items.FromSql(" INSERT INTO \"Items\" (\"Name\", \"Location\", \"Date_Purchased\", \"Quantity\", \"Type\", \"Photo\", \"Color\", \"Company\", \"Serial\") VALUES ("+ Request.Form["itemName"] + "," +  Request.Form["location"] + "," + Request.Form["dateBought"] + "," + Request.Form["numItems"] + "," +  Request.Form["type"] + "," +  Request.Form["color"] + "," + Request.Form["company"] + "," +  Request.Form["serial"] + "," + Request.Form["selectedFile"] +";");

            try
            {
                Items newItem = CreateNewItem(form);
                Byte[] picture = null;
                foreach (var file in form.Files)
                {
                   picture = UploadFile(file);
                }
                newItem.Photo = picture;
                var items = context.Items.Add(newItem);
                context.SaveChanges();
                return new { Success = true, newItem.Name};
            }
            catch (Exception ex)
            {
                return new { Success = false, ex.Message };
            }

        }

        private static Byte[] UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new Exception("File is empty!");
            byte[] fileArray;
            using (var stream = file.OpenReadStream())
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                fileArray = memoryStream.ToArray();
            }

            return fileArray;
           
        }

        private static Items CreateNewItem(IFormCollection form)
        {

            Items newObject = new Items();
            newObject.Name = form["itemName"];
            newObject.Location = form["location"];
            DateTime itemBought = DateTime.ParseExact(form["dateBought"].ToString(), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            newObject.DatePurchased = itemBought;
            newObject.Quantity =  Int32.Parse(form["numItems"]);
            newObject.Type = form["type"];
            newObject.Color = form["color"];
            newObject.Company = form["company"];
            newObject.Serial = form["serial"];

            return newObject;
        }
    }
}


        