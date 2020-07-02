using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetWEBAPITest.Repository
{
    public class ProductRepository : IProductRepository
    {
        public string Get()
        {
            return "get";
        }

        public string Post()
        {
            return "post";
        }
    }

    public interface IProductRepository
    {
        string Get();
        string Post();
    }
}
