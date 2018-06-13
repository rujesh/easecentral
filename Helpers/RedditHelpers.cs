using EaseCentral.Models;
using EaseCentral.Repository;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EaseCentral.Helpers
{
    public static class RedditHelpers
    {
        public async static Task<List<RedditResponse>> FetchRedditDataAsync()
        {
            var redditData = new List<RedditResponse>();

            HttpClient client = new HttpClient();
            var redditString = await client.GetAsync("https://www.reddit.com/hot.json");
            if(redditString.IsSuccessStatusCode)
            {
                RedditJson redditJson = await redditString.Content.ReadAsAsync<RedditJson>();
                foreach (var item in redditJson.Data.Children)
                {
                    var reddit = new RedditResponse
                    {
                        Id = item.Data.Id,
                        Permalink = item.Data.Permalink,
                        Url = item.Data.Url,
                        Author = item.Data.Author
                    };

                    redditData.Add(reddit);
                }
            }
            
            return redditData;
        }

        public async static Task<FavoriteResponse> SaveFavouriteAsync(IFavRepository iFavRepository, Favorite favorite)
        {
            var result = await iFavRepository.CreateAsync(favorite);

            var favoriteResponse = new FavoriteResponse
            {
                Status = Status.Success,
                Message = "New Favorite Created"
            };

            return favoriteResponse;
        }

        public async static Task<List<RedditResponse>> FetchFavouritesAsync(IFavRepository iFavRepository, string tag)
        {
            var favorites = await iFavRepository.GetAllByTagAsync(tag);

            var response = new List<RedditResponse>();

            foreach (var favorite in favorites)
            {
                var redditResp = new RedditResponse
                {
                    Id = favorite.reddit_id,
                    Permalink = favorite.permalink,
                    Url = favorite.url,
                    Author = favorite.author
                };

                response.Add(redditResp);
            }

            return response;
        }

        public async static Task<FavoriteResponse> SaveFavouriteAsync(IFavRepository iFavRepository, string tag, string redditId)
        {
            throw new NotImplementedException();
        }
    }
}