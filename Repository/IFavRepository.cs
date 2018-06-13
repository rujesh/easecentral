using EaseCentral.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EaseCentral.Repository
{
    public interface IFavRepository : IRepository<Favorite>
    {
        Task<IEnumerable<Favorite>> GetAllByTagAsync(string tag);
    }
}