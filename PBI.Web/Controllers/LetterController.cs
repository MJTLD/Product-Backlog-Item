using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Kendo.DynamicLinqCore;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PBI.Model.Secretariat;
using PBI.Service.IService;

namespace PBI.Web.Controllers
{
    public class LetterController : Controller
    {
        private readonly ILetterService _letterService;
        
        public LetterController(ILetterService letterService)
        {
            _letterService = letterService;
        }
        
        public DataSourceResult GetAllData()
        {
            var item = System.Net.WebUtility.UrlDecode(Request.QueryString.ToString()
                .Remove(0, 1));
            var request = JsonConvert.DeserializeObject<DataSourceRequest>(item);
           
            var test = _letterService.GetAll()
                .ToDataSourceResult(request.Take, request.Skip, request.Sort, request.Filter);
            return test;
        }
        
        [HttpPost] // Add it to fix this error: The requested resource does not support http method 'PUT'
        public IActionResult UpdateLetter([FromBody]Letter letter)
        {
            var item = _letterService.Get(r => r.LetterId == 1).FirstOrDefault();
            if (item == null)
                return BadRequest();
            
            //if (!ModelState.IsValid || id != letter.ID)
               // return new HttpResponseMessage(HttpStatusCode.BadRequest);

            //ProductDataSource.LatestProducts[item.Index] = product;
            return Json(new DataSourceResult {Data = new[] {item}});
        }
        
        // GET
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        
    }
}