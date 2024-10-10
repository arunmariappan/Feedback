using CustomerFeedbackApp.Models;
using CustomerFeedbackApp.Services.Http;
using CustomerFeedbackApp.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;

namespace CustomerFeedbackApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJiraClient _client;
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork; // readonly means that the variable can only be assigned a value in the constructor

        public HomeController(
            IJiraClient client,
            ILogger<HomeController> logger,
            IUnitOfWork unitOfWork
            )
        {
            _client = client;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        // create a new player
        [HttpPost]
        public async Task<IActionResult> CreateFeedback(Feedback feedback) // 
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Feedbacks.Add(feedback); // add the feedback to the database
                int saveCount = await _unitOfWork.CompleteAsync(); // save the changes to the database

                
                var response = await _client.CreateJiraIssue(feedback);

                return Ok(new { status = (saveCount > 0), issueKey = response.Key.Value });
            }

            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
