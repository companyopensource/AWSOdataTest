using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWSOdataTest.Controllers
{
    public class ProductController : Controller
    {
        /*
         * http://localhost:54330/odata/Product?$top=2 
         * this URL returns 2 rows
         *         *
         * http://myapi.execute-api.us-west-2.amazonaws.com/Prod/odata/Product?$top=2
         * returns 10 rows
         */
        [EnableQuery]
        public IActionResult Get()
        {
            var list = new List<Product>();
            for (int i = 1; i <= 10; i++)
            {
                list.Add(new Product() {Id = i, ProductName = $"Product{i} Name"});
            }
            return Ok(list.AsQueryable());
        }
    }
}