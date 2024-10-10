using CustomerFeedbackApp.Data;
using CustomerFeedbackApp.Models;
using CustomerFeedbackApp.Services.IRepositories;

namespace CustomerFeedbackApp.Services.Repositories
{
    public class FeedbackRepository : GenericRepository<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(CustomerFeedbackContext context, ILogger logger) : base(context, logger)
        {

        }

    }
}
