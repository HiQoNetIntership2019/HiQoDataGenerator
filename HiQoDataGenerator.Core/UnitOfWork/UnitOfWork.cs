using System.Linq;
using System.Threading.Tasks;
using HiQoDataGenerator.DAL;
using Microsoft.EntityFrameworkCore;

namespace HiQoDataGenerator.Core.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private DataContext _context { get; }

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public void DetachAllEntities()
        {
            var changedEntriesCopy = _context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                    e.State == EntityState.Modified ||
                    e.State == EntityState.Deleted ||
                    e.State == EntityState.Unchanged)
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
