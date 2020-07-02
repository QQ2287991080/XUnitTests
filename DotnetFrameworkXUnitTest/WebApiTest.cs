using DotnetWEBAPITest.Controllers;
using DotnetWEBAPITest.Repository;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Xunit;
using Xunit.Abstractions;

namespace DotnetFrameworkXUnitTest
{


    public class WebApiTest
    {
        private readonly ITestOutputHelper _output;
        public WebApiTest(ITestOutputHelper output)
        {
            _output = output;
        }
        [Fact]
        public void webapi_testController_IhttActionResultpGet_test()
        {
            //实例化依赖注入mock对象
            var mockRepository = new Mock<IProductRepository>();
            //实例化测试控制器
            var controller = new TestController(mockRepository.Object);
            IHttpActionResult response = controller.IHttpActionResultGet();
            var result = response as JsonResult<TestResult>;
            //if (response is JsonResult<TestResult>)
            //{

            //}

            var json = result.Content as TestResult;
            var jsonStr = JsonConvert.SerializeObject(json);
            _output.WriteLine(jsonStr);
            Assert.NotNull(response);
        }
        [Fact]
        public void webapi_testController_IhttActionResultpPost_test()
        {
            var controller = new TestController(new ProductRepository());
            controller.Request = new HttpRequestMessage();//http请求
            controller.Configuration = new System.Web.Http.HttpConfiguration();//http管道配置
            var response = controller.IHttpActionResultPost();//返回结果
            var result=response as JsonResult<object>;
            Assert.NotNull(response);
        }
        [Fact]
        public void webapi_testController_httpResponseMessageGet_test()
        {
            var controller = new TestController(new ProductRepository());
            controller.Request = new HttpRequestMessage();//http请求
            controller.Configuration = new System.Web.Http.HttpConfiguration();//http管道配置
            var response = controller.HttpResponseMessageGet();//返回结果
            response.TryGetContentValue(out string message);
            _output.WriteLine(message);
            Assert.NotNull(response);
        }
        [Fact]
        public void webapi_testController_httpResponseMessagePost_test()
        {
            var controller = new TestController(new ProductRepository());
            controller.Request = new HttpRequestMessage();//http请求
            controller.Configuration = new System.Web.Http.HttpConfiguration();//http管道配置
            var response = controller.HttpResponseMessagePost();
            response.TryGetContentValue(out string message);
            _output.WriteLine(message);
            Assert.NotNull(response);
        }
    }
}
