using DTO_DataTransferObject;
using GUImovieWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace GUImovieWPF.ViewModel
{
    class FilmViewModel : INotifyPropertyChanged
    {
        private int _page;
        public int Page { get { return _page; } set { _page = value; OnPropertyChanged("Page"); } }
        public string Query { get; set; }
        public ObservableCollection<FilmModel> Films { get; set; }

        public FilmViewModel()
        {
            Page = 1;
            Query = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool LoadFilms()
        {
            if (Page < 1)
            {
                Page = 1;
                return false;
            }
            //PREPARATION APPEL API
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(ConfigurationManager.AppSettings["basicURL"])
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string route = Query != ""
                ? string.Format("{0}movie/title?name={1}&index={2}&nbbypage=5", ConfigurationManager.AppSettings["basicURL"], Query, (Page - 1) * 5)
                : string.Format("{0}movie/page?index={1}&nbbypage=5", ConfigurationManager.AppSettings["basicURL"], (Page - 1) * 5);
            Trace.WriteLine(route);

            HttpResponseMessage reponse = client.GetAsync(route).Result;
            if (!reponse.IsSuccessStatusCode)
            {
                return false;
            }

            Trace.WriteLine(reponse.Content.ReadAsStringAsync().Result);
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            //List<FilmDTO> lf = JsonSerializer.Deserialize<List<FilmDTO>>(reponse.Content.ReadAsStringAsync().Result, options);
            List<FilmDTO> lf = JsonSerializer.Deserialize<List<FilmDTO>>(reponse.Content.ReadAsStringAsync().Result.Replace("\"NaN\"", "0"), options);

            if (Films == null)
            {
                Films = new ObservableCollection<FilmModel>();
            }
            else
            {
                Films.Clear();
            }

            foreach (FilmDTO f in lf)
            {
                Trace.WriteLine(f.VoteAverage);
                Films.Add(new FilmModel(f));
            }

            return true;
        }
    }
}
