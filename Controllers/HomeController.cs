using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotingDojo.Models;
using DbConnection;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View("index");
        }

        [HttpPost("quotes")]
        public IActionResult CreateQuote(Quotes _quote)
        {
            if(ModelState.IsValid)
            {
                string query = $"INSERT INTO quotes (name, quote, created_at, updated_at) VALUES ('{_quote.name}', '{_quote.quote}', NOW(), NOW())";
                DbConnector.Execute(query);
                return RedirectToAction("AllQuotes");
            }
            return View("index");
        }

        [HttpGet("quotes")]
        public IActionResult AllQuotes()
        {
            List<Dictionary<string, object>> AllQuotes = DbConnector.Query("SELECT * FROM quotes ORDER BY created_at DESC");
            ViewBag.Quotes = AllQuotes;
            return View("Quotes");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
