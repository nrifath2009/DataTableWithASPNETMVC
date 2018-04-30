using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoGridApp.Models;
using Newtonsoft.Json;

namespace DemoGridApp.Controllers
{
    public class DataController : Controller
    {
        public JsonResult Index(int?draw, int? start, int? length)
        {
            var search = Request["search[value]"];
            var totalRecords = 0;
            var totalRecordsFiltered = 0;
            start = start.HasValue ? start / 10 : 0;

            var products = new ProductRepository().GetPaginated(search, start.Value, length ?? 10, out totalRecords,
                out totalRecordsFiltered);
            //return JsonConvert.SerializeObject(products);
            return Json(new { draw = draw, recordsFiltered = totalRecordsFiltered, recordsTotal = totalRecords, data = products });
        }
        
    }
}