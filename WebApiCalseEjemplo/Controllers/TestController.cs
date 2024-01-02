using Microsoft.AspNetCore.Mvc;
using System;
using DBCon;
using Microsoft.AspNetCore.Identity;
using DatabaseConnectionCustom.Data;
using WebUtils;

namespace WebApiCalseEjemplo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public TestController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "TestController")]
        public int Get()
        {
            SQLconn t = new DBCon.SQLconn();
            // t.connect();
            mailinfo maili = new WebUtils.mailinfo() { mail = "nach.fenix@gmail.com", pass = "jnnovnnsrett" };
            new WebUtils.mail().send(maili, "nach.fenix@gmail.com", "test","test",at: PDFManage.test().CreateAsAttachment("test.pdf"));


            return t.TestDB().Tables[0].Rows.Count;
        }
    }
}