using System;
using System.Linq;
using System.Net;
using System.Web;
using ITA.Common.Enumerations;
using Skyline.InternTrainingApp.Common.Domain;
using Skyline.InternTrainingApp.Common.Interfaces.ExternalServices;
using Newtonsoft.Json.Linq;
using Skyline.InternTrainingApp.Common.RequestResponse;

namespace Skyline.InternTrainingApp.ExternalServices.RottenTomatoes {

    public class RottenTomatoesService : IRottenTomatoesService {

        #region << Private Fields and Constants >>
        

        private const string FindByTitleUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies.json?apikey=4zmfvqnwud73a4mcxa6cqztg";
        private const string FindByTitleParam = "&q={0}&page_limit=1";
        private const string MovieInfoUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies/{0}.json?apikey=4zmfvqnwud73a4mcxa6cqztg";

        #endregion

        #region << Public Methods >>

        public BusinessServiceItemResponse<Movie> GetByTitle(string movieTitle) {
            BusinessServiceItemResponse<Movie> response = new BusinessServiceItemResponse<Movie>();
            string url = string.Format((FindByTitleUrl + FindByTitleParam),HttpUtility.UrlEncode(movieTitle));
            string json = new WebClient().DownloadString(url);
            JObject jObject = JObject.Parse(json);
            int total = (int) jObject["total"];
            if (total == 0) {
                response.ApplicationErrors.Add(string.Format("No movie's with title: {0}", movieTitle));
            }
            else if (total > 1) {
                response.ApplicationErrors.Add(string.Format("More than 1 movie returned with title: {0}", movieTitle));
            }
            else {
                response.Item = GetMovieInfo(jObject["movies"][0]["id"].ToString());
            }
            return response;
        } 


        #endregion

        #region << Private Methods >>

         private Movie GetMovieInfo(string movieId) {
             string url = string.Format(MovieInfoUrl, movieId);
             string movieInfo = new WebClient().DownloadString(url);
             JObject m = JObject.Parse(movieInfo);
             Movie movie = new Movie {
                 Title = m["title"].ToString(),
                 MpaaRating = m["mpaa_rating"].ToString(),
                 ReleaseDate = DateTime.Parse(m["release_dates"]["theater"].ToString()),
                 Genres = (from x in m["genres"] select new Genre { Title = x.Value<string>() }).ToList(),
                 AudienceRating = long.Parse(m["ratings"]["audience_score"].ToString()),
                 Synopsis = m["synopsis"].ToString(),
                 ClipsUrl = m["links"]["clips"].ToString(),
                 ImageUrl = m["posters"]["thumbnail"].ToString()
             };
             movie.People = (from x in m["abridged_cast"] select new Person { PersonType = PersonType.Actor, FullName = x["name"].ToString() }).ToList();
             movie.People = movie.People.Concat((from x in m["abridged_directors"] select new Person { PersonType = PersonType.Director, FullName = x["name"].ToString() }).ToList()).ToList();
             return movie;
         }

        #endregion
    }
}