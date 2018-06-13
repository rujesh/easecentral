using EaseCentral.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace EaseCentral.Repository
{
    public class FavoriteRepository : IFavRepository
    {
        private EaseCentralEntities _dbContext;

        public FavoriteRepository()
        {
            _dbContext = new EaseCentralEntities();
        }

        public async Task<int> CreateAsync(Favorite favorite)
        {
            _dbContext.Favorites.Add(favorite);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Favorite>> GetAllByTagAsync(string tag)
        {
            return await _dbContext.Favorites.Where(f => f.tag == tag).ToListAsync();
        }

        public async Task<IEnumerable<Favorite>> GetAllAsync()
        {
            return await _dbContext.Favorites.ToListAsync();
        }

        public async Task<Favorite> GetByIdAsync(int id)
        {
            return await _dbContext.Favorites.FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
