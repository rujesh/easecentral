using EaseCentral.Helpers;
using EaseCentral.Models;
using EaseCentral.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace EaseCentral.Controllers
{
    [Authorize]
    public class RedditController : ApiController
    {
        private IFavRepository _favRepository;

        public RedditController()
        {
            _favRepository = new FavoriteRepository();
        }

        public RedditController(IFavRepository iFavRepository)
        {
            _favRepository = iFavRepository;
        }

        [Route("api/reddit")]
        public async Task<List<RedditResponse>> Get()
        {
            return await RedditHelpers.FetchRedditDataAsync();
        }

        [Route("api/reddit/favourites/{tag}/{redditId}")]
        public async Task<FavoriteResponse> Post(string tag, string redditId)
        {
            return await RedditHelpers.SaveFavouriteAsync(_favRepository, tag, redditId);
        }

        [Route("api/reddit/favorites")]
        public async Task<FavoriteResponse> Post([FromBody]Favorite favorite)
        {
            return await RedditHelpers.SaveFavouriteAsync(_favRepository, favorite);
        }

        [Route("api/reddit/favourites")]
        public async Task<List<RedditResponse>> Get(string tag)
        {
            return await RedditHelpers.FetchFavouritesAsync(_favRepository, tag);
        }
    }
}
