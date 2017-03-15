using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
   using Models;
   using Newtonsoft.Json;
   using Newtonsoft.Json.Serialization;
   using Services;

   public class HomeController : Controller
   {
      private readonly IDataService service;

      public HomeController(IDataService service)
      {
         this.service = service;
      }

      public IActionResult Index()
      {
         return View();
      }

      public JsonResult Data(ItemQuery query)
      {
         var result = service.Query( query );

         //We'd abstract these settings as we'd want consistency across everything
         return Json( result, new JsonSerializerSettings
         {
            DateFormatString = "dd-MMM-yyyy",
            ContractResolver = new CamelCasePropertyNamesContractResolver()           
         } );
      }

      public IActionResult About()
      {
         ViewData["Message"] = "Your application description page.";

         return View();
      }

      public IActionResult Contact()
      {
         ViewData["Message"] = "Your contact page.";

         return View();
      }

      public IActionResult Error()
      {
         return View();
      }
   }
}