namespace CustomerFeedbackApp.Services.IRepositories
{
    public interface IUnitOfWork
    {
        IFeedbackRepository Feedbacks { get; } // we have only get because we don't want to set the repository. setting the repository will be done in the UnitOfWork class

        Task<int> CompleteAsync(); // this method will save all the changes made to the database
    }
}
