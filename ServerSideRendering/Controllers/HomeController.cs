using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.NodeServices;
using ServerSideRendering.Models;

namespace ServerSideRendering.Controllers
{
    public class HomeController : Controller
    {  
        public async Task<IActionResult> Index([FromServices] INodeServices nodeServices)
        {
            var chartOptions = new
            {
                width    = 500,
                height   = 250,
                showArea = true
            };

            // for line chart
            var data = new
            {
                // x-axis
                labels = new[] {"Q1", "Q2", "Q3", "Q4"},
                // y-axis
                series = new[]
                {
                    new[] {70, 80, 60, 100},
                    new[] {88, 90, 99, 66},
                    new[] {100, 80, 60, 111}
                }
            };

            var lineResult = await nodeServices.InvokeAsync<string>(  "./JavaScripts/demo" ,
                                                                    "line", chartOptions, data);
            ViewData["lineResult"] = lineResult;


            // for pie chart
            var data2 = new { series = new[]
                {
                    new {name = "New York", value = 20},
                    new {name = "Boston", value = 20},
                    new {name = "San Francisco", value = 55},
                    new {name = "Charlotte", value = 5}
                }
            };
            var pieResult = await nodeServices.InvokeAsync<string>( "./JavaScripts/demo" ,
                                                                    "pie" , chartOptions , data2 );
            ViewData["pieResult"] = pieResult;


            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
