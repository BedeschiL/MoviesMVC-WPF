using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace Movies_Utils
{
    public static class MUtils
    {
        #region GetImage
        public static string GetImage(int id)
        {

            HttpClient client = new HttpClient();
            HttpResponseMessage r = client.GetAsync("https://api.themoviedb.org/3/movie/" + id + "?api_key=b61acbc4c15132b3cb5328f331b3c034").Result;
            if (!r.IsSuccessStatusCode)
            {

                return "";
            }
            else
            {

                string s = r.Content.ReadAsStringAsync().Result;
                var data = (JObject)JsonConvert.DeserializeObject(s);
                String newPath = data["poster_path"].Value<String>();
                newPath = "https://image.tmdb.org/t/p/w500" + newPath;
                return newPath;
            }
        }
        #endregion
    }
}
