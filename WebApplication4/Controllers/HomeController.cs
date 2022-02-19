using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using App1.Models;
using Newtonsoft.Json;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        const string url = "https://jsonplaceholder.typicode.com/todos";
        HttpClient client = new HttpClient();
        public ObservableCollection<SomeData> someData;
        [HttpGet("getJson")]
        public List<SomeData> GetTs()
        {
            return new List<SomeData>()
            {
                new SomeData()
                {
                    userId = 1, id = 2, title = "321", completed=true
                },
                new SomeData()
                {
                    userId = 2, id = 453, title = "321", completed=true
                }
            };

        }
        [HttpGet("getJson1")]
        public async Task<string> sda()
        {
            var content = await client.GetStringAsync(url);
            return content;
        }
        public async Task<ObservableCollection<SomeData>> GetMass()
        {
            var content = await client.GetStringAsync(url);
            var someJsons = JsonConvert.DeserializeObject<List<SomeData>>(content);
            return someData = new ObservableCollection<SomeData>(someData);
        }
    }
}
