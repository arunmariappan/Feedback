using CustomerFeedbackApp.Data;
using CustomerFeedbackApp.Services.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CustomerFeedbackApp.Services.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected CustomerFeedbackContext _context;
        protected DbSet<T> dbSet;
        protected readonly ILogger _logger;

        // constructor will take the context and logger factory as parameters
        public GenericRepository(
            CustomerFeedbackContext context,
            ILogger logger
        )
        {
            _context = context;
            _logger = logger;
            this.dbSet = _context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> All() // virtual means that this method can be overriden by a class that inherits from this class
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            try
            {
                return await dbSet.FindAsync(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error getting entity with id {Id}", id);
                return null;
            }
        }

        public virtual async Task<bool> Add(T entity)
        {
            try
            {
                await dbSet.AddAsync(entity);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error adding entity");
                return false;
            }
        }

        public virtual async Task<bool> Delete(int id)
        {
            try
            {
                var entity = await dbSet.FindAsync(id);
                if (entity != null)
                {
                    dbSet.Remove(entity);
                    return true;
                }
                else
                {
                    _logger.LogWarning("Entity with id {Id} not found for deletion", id);
                    return false;
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error deleting entity with id {Id}", id);
                return false;
            }
        }


        public Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
