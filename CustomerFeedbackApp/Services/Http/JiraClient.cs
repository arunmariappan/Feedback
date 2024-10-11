using Atlassian.Jira;
using CustomerFeedbackApp.Models;

namespace CustomerFeedbackApp.Services.Http
{
    public class JiraClient : IJiraClient
    {
        public async Task<Issue> CreateJiraIssue(Feedback feedback)
        {
            try
            {
                var appConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                var jiraBaseURL = appConfig.GetValue<string>("JiraBaseURL"); 
                var userName = appConfig.GetValue<string>("BasicAuthenticationUsername");
                var password = appConfig.GetValue<string>("BasicAuthenticationPassword");
                var jiraProjectKey = appConfig.GetValue<string>("JiraProjectKey");

                // create a connection to JIRA using the Rest client
                var jira = Jira.CreateRestClient(jiraBaseURL, userName, password);

                var issue = jira.CreateIssue(jiraProjectKey);
                issue.Type = feedback.FeedbackType;
                issue.Priority = "Major"; // Need to change
                issue.Summary = "Feedback from "+ feedback.CustomerName +" for App version "+ feedback.AppVersion;
                issue.Description = feedback.FeedbackMessage;
                issue.Priority = "Medium"; // Need to change
                // Adding environment only for Bug type
                if(feedback.FeedbackType == "10005")
                {
                    issue.Environment = "Production";
                }
                
                issue.DueDate = System.DateTime.Now;

                return await issue.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
