using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CollectionDemo.Services
{
    public class ServiceBase
    {
        protected JsonSerializerOptions _serializerOptions;
        public ServiceBase()
        {
            _serializerOptions = new JsonSerializerOptions
            {
                //PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                PropertyNameCaseInsensitive = true
            };
        }
    }
}
