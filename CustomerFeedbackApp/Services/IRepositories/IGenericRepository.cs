namespace CustomerFeedbackApp.Services.IRepositories
{
    public interface IGenericRepository<T> where T : class // T is a generic type, it means that it can be of any type
    {
        Task<IEnumerable<T>> All(); // Task is a type that represents an asynchronous operation that can return a value
        Task<T> GetById(int id);

        Task<bool> Add(T entity); // returns true if successful

        Task<bool> Delete(int id);

        Task<bool> Update(T entity);
    }
}
