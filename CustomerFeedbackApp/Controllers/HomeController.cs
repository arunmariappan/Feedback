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
        private readonly JiraClient _client;
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork; // readonly means that the variable can only be assigned a value in the constructor

        public HomeController(
            JiraClient client,
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
                await _unitOfWork.CompleteAsync(); // save the changes to the database
                var dateNow = System.DateTime.Now.ToString("MM/dd/yyyy");
                var jsonString = $$"""
                        {
                            "fields": {
                                "project": { 
                                    "key": "GC"
                                },
                                "summary": "Feedback",
                                "description": {
                                        "type": "doc",
                                        "version": 1,
                                        "content": [
                                            {
                                                "type": "paragraph",
                                                "content": [
                                                    {
                                                        "type": "text",
                                                        "text": "{{feedback.FeedbackMessage}}"
                                                    }
                                                ]
                                            }
                                        ]
                                    },
                                "issuetype": {
                                    "id": "{{feedback.FeedbackType}}"
                                },
                                "priority": {
                                    "id": "3",
                                    "name": "Medium"
                                },
                                "environment": {
                                        "type": "doc",
                                        "version": 1,
                                        "content": [
                                            {
                                                "type": "paragraph",
                                                "content": [
                                                    {
                                                        "type": "text",
                                                        "text": "Production"
                                                    }
                                                ]
                                            }
                                        ]
                                    },
                                "duedate": "{{dateNow}}"
                            }
                        }
                    """;
                var response = await _client.PostAsync(jsonString);



                return Ok(HttpStatusCode.Created);
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
