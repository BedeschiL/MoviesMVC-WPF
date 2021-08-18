using DTO_DataTransferObject;
using Movies_Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Media.Imaging;

namespace GUImovieWPF.Model
{
    public class FilmModel : FilmDTO, INotifyPropertyChanged
    {
        public override int Id { get { return _id; } set { _id = value; OnPropertyChanged("Id"); } }
        public override string Title { get { return _title; } set { _title = value; OnPropertyChanged("Title"); } }
        //Release date du film
        public override DateTime Date { get { return _date; } set { _date = value; OnPropertyChanged("Date"); } }
        public override float VoteAverage { get { return _voteAverage; } set { _voteAverage = value; OnPropertyChanged("VoteAverage"); OnPropertyChanged("Rating"); } }
        public BitmapImage Rating { get { return GetRating(); } }
        public override int Runtime { get { return _runtime; } set { _runtime = value; OnPropertyChanged("Runtime"); } }
        public string ReadableRuntime { get { return String.Format("{0}h{1}", Runtime / 60, (Runtime % 60).ToString("D2")); } }
        public override string Posterpath { get { return _posterpath; } set { _posterpath = value; OnPropertyChanged("Posterpath"); } }
        public BitmapImage Poster { get { return new BitmapImage(new Uri(MUtils.GetImage(Id))); } }
        public ObservableCollection<BitmapImage> TypeIcons { get { return GetTypeIcons(); } }

        public FilmModel(FilmDTO f)
        {
            Id = f.Id;
            Title = f.Title;
            Date = f.Date;
            VoteAverage = f.VoteAverage;
            Runtime = f.Runtime;
            Posterpath = f.Posterpath;
            Comments = f.Comments;
        }

        private BitmapImage GetRating()
        {
            string filename = "0etoiles.png";

            if (VoteAverage > 0f && VoteAverage <= 2f)
            {
                filename = "1etoile.PNG";
            }
            else
            if (VoteAverage > 2f && VoteAverage <= 4f)
            {
                filename = "2etoiles.PNG";
            }
            else
            if (VoteAverage > 4f && VoteAverage <= 6f)
            {
                filename = "3etoiles.PNG";
            }
            else
            if (VoteAverage > 6f && VoteAverage <= 8f)
            {
                filename = "4etoiles.PNG";
            }
            else
            if (VoteAverage > 8f && VoteAverage <= 10f)
            {
                filename = "5etoiles.PNG";
            }

            return new BitmapImage(new Uri(ConfigurationManager.AppSettings["pathRate"] + filename));
        }

        public ObservableCollection<BitmapImage> GetTypeIcons()
        {
            //PREPARATION APPEL API
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(ConfigurationManager.AppSettings["basicURL"])
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string route = string.Format("{0}filmtype?idmovie={1}", ConfigurationManager.AppSettings["basicURL"], Id);
            Trace.WriteLine(route);

            HttpResponseMessage reponse = client.GetAsync(route).Result;

            Trace.WriteLine(reponse.Content.ReadAsStringAsync().Result);
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<FilmTypeDTO> TypesDTO = JsonSerializer.Deserialize<List<FilmTypeDTO>>(reponse.Content.ReadAsStringAsync().Result, options);

            ObservableCollection<BitmapImage> iconlist = new ObservableCollection<BitmapImage>();
            foreach (FilmTypeDTO t in TypesDTO)
            {
                string filename = "default.png";

                if (t.Name.ToUpper().CompareTo("DRAMA") == 0)
                {
                    filename = "drama.png";
                }
                else
                if (t.Name.ToUpper().CompareTo("ADVENTURE") == 0)
                {
                    filename = "aventure.png";
                }
                else
                if (t.Name.ToUpper().CompareTo("FANTASY") == 0)
                {
                    filename = "fantasy.png";
                }
                if (t.Name.ToUpper().CompareTo("HORROR") == 0)
                {
                    filename = "horreur.png";
                }
                if (t.Name.ToUpper().CompareTo("ACTION") == 0)
                {
                    filename = "action.png";
                }
                if (t.Name.ToUpper().CompareTo("COMEDY") == 0)
                {
                    filename = "comedy.png";
                }
                if (t.Name.ToUpper().CompareTo("CRIME") == 0)
                {
                    filename = "crime.png";
                }
                if (t.Name.ToUpper().CompareTo("CRIME") == 0)
                {
                    filename = "crime.png";
                }
                if (t.Name.ToUpper().CompareTo("MYSTERY") == 0)
                {
                    filename = "scifi.png";
                }
                if (t.Name.ToUpper().CompareTo("SCIENCE FICTION") == 0)
                {
                    filename = "scifi.png";
                }
                if (t.Name.ToUpper().CompareTo("MUSIC") == 0)
                {
                    filename = "music.png";
                }
                if (t.Name.ToUpper().CompareTo("ANIMATION") == 0)
                {
                    filename = "animation.png";
                }
                if (t.Name.ToUpper().CompareTo("FAMILY") == 0)
                {
                    filename = "family.png";
                }
                if (t.Name.ToUpper().CompareTo("WAR") == 0)
                {
                    filename = "guerre.png";
                }
                if (t.Name.ToUpper().CompareTo("ROMANCE") == 0)
                {
                    filename = "romance.png";
                }
                if (t.Name.ToUpper().CompareTo("WESTERN") == 0)
                {
                    filename = "western.png";
                }

                iconlist.Add(new BitmapImage(new Uri(ConfigurationManager.AppSettings["pathIcon"] + filename)));
            }

            return iconlist;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
