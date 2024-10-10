using CustomerFeedbackApp.Data;
using CustomerFeedbackApp.Services.IRepositories;

namespace CustomerFeedbackApp.Services.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable // IDisposable is used to free unmanaged resources
    {
        private readonly CustomerFeedbackContext _context;
        private readonly ILogger _logger;

        public IFeedbackRepository Feedbacks { get; private set; }

        // constructor will take the context and logger factory as parameters
        public UnitOfWork(
            CustomerFeedbackContext context,
            ILoggerFactory loggerFactory
        )
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Feedbacks = new FeedbackRepository(_context, _logger);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
