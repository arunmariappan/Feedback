using Atlassian.Jira;
using CustomerFeedbackApp.Models;

namespace CustomerFeedbackApp.Services.Http
{
    public interface IJiraClient
    {
        public Task<Issue> CreateJiraIssue(Feedback feedback);
    }
}
