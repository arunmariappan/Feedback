namespace CustomerFeedbackApp.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public required string CustomerName { get; set; }
        public required string EmailAddress { get; set; }
        public required string FeedbackType { get; set; }
        public required string FeedbackMessage { get; set; }
        public required string AppVersion { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
