using CustomerFeedbackApp.Models;
using CustomerFeedbackApp.Services.Http;
using CustomerFeedbackApp.Services.IRepositories;
using Ganss.Xss;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;
using System.Web;

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
            _logger.LogInformation("Entering Home page");
            return View();
        }

        // create a new player
        [HttpPost]

        public async Task<IActionResult> CreateFeedback(Feedback feedback)
        {
            try
            {
                _logger.LogInformation("Start creating a Feedback.");

                // Sanitizing the input data
                var sanitizer = new HtmlSanitizer();
                feedback.CustomerName = sanitizer.Sanitize(feedback.CustomerName);
                feedback.EmailAddress = sanitizer.Sanitize(feedback.EmailAddress);
                feedback.FeedbackType = sanitizer.Sanitize(feedback.FeedbackType);
                feedback.FeedbackMessage = sanitizer.Sanitize(feedback.FeedbackMessage);
                feedback.AppVersion = sanitizer.Sanitize(feedback.AppVersion);

                if (ModelState.IsValid)
                {
                    // add the feedback to the database
                    await _unitOfWork.Feedbacks.Add(feedback);

                    // save the changes to the database
                    int saveCount = await _unitOfWork.CompleteAsync();

                    _logger.LogInformation("Created a Feedback " + feedback.Id);

                    // Create a JIRA issue with the feedback input
                    var response = await _client.CreateJiraIssue(feedback);

                    _logger.LogInformation("Created a Jira Issue " + response.Key.Value);

                    // Encoding the values before sending
                    return Ok(new { status = (saveCount > 0), issueKey = HttpUtility.HtmlEncode(response.Key.Value) });
                }
                return Ok(HttpStatusCode.BadRequest);
            }
            catch(Exception ex)
            {
                _logger.LogError("Error occurred while creating feedback"+ ex.Message + "\n"+ ex.StackTrace);
                return Ok(HttpStatusCode.InternalServerError);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
