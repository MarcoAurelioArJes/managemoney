using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace managemoney.Controllers
{
    public class DashboardController : Controller
    {

        public DashboardController()
        {
        }

        public ActionResult Index()
        {
            List<RoundedColumnChartData> ChartPoints = new List<RoundedColumnChartData>
            {
                new RoundedColumnChartData { Country = "Sierra Leone", Rate = 100, Literacy_Rate = 48.1, Text = "48.1%" },
                new RoundedColumnChartData { Country = "South Sudan", Rate = 100, Literacy_Rate = 26.8, Text = "26.8%" },
                new RoundedColumnChartData { Country = "Nepal", Rate = 100, Literacy_Rate = 64.7, Text = "64.7%" },
                new RoundedColumnChartData { Country = "Gambia", Rate = 100, Literacy_Rate = 55.5, Text = "55.5%" },
                new RoundedColumnChartData { Country = "Gyana", Rate = 100, Literacy_Rate = 88.5, Text = "88.5%" },
                new RoundedColumnChartData { Country = "Kenya", Rate = 100, Literacy_Rate = 78.0, Text = "78.0%" },
                new RoundedColumnChartData { Country = "Singapore", Rate = 100, Literacy_Rate = 96.8, Text = "96.8%" },
                new RoundedColumnChartData { Country = "Niger", Rate = 100, Literacy_Rate = 19.1, Text = "19.1%" },
            };
            ViewBag.ChartPoints = ChartPoints;
            return View();

        }
        public class RoundedColumnChartData
        {
            public string Country;
            public double Rate;
            public double Literacy_Rate;
            public string Text;
        }
    }
}