using CustomerFeedbackApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerFeedbackApp.Data
{
    public class CustomerFeedbackContext : DbContext
    {
        public CustomerFeedbackContext(DbContextOptions<CustomerFeedbackContext> options) : base(options) { }

        public DbSet<Feedback> Feedbacks { get; set; }
    }
}
