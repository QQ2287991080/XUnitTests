using DotnetWEBAPITest.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DotnetWEBAPITest.Controllers
{
    public class TestResult
    {
        public int ErrCode { get; set; }
        public IEnumerable<string> ErrMsg { get; set; }
        public object Data { get; set; }
    }
    public class TestController : ApiController
    {
        IProductRepository _productRepository;
        public TestController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public IHttpActionResult IHttpActionResultGet()
        {
            return Json(new TestResult { ErrCode = 0, ErrMsg = new string[] { "this is IHttpActionResult Get" } });
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult IHttpActionResultPost()
        {
            return Json("this is IHttpActionResult Post");
        }

        [HttpGet]
        public HttpResponseMessage HttpResponseMessageGet()
        {
            return Request.CreateResponse(_productRepository.Get());
        }

        [HttpPost]
        public HttpResponseMessage HttpResponseMessagePost()
        {
            return Request.CreateResponse(_productRepository.Post());
        }
    }
}
