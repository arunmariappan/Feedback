using CustomerFeedbackApp.Models;

namespace CustomerFeedbackApp.Services.IRepositories
{
    public interface IFeedbackRepository : IGenericRepository<Feedback>
    {
        // add methods that are specific to the Feedback entity
        // e.g Task<Feedback> GetByEmail(string email);
    }
}
