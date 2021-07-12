using DTO_DataTransferObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Net.Http;
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
        public override string Posterpath { get { return _posterpath; } set { _posterpath = value; OnPropertyChanged("Posterpath"); OnPropertyChanged("Poster"); } }
        public BitmapImage Poster { get { return new BitmapImage(new Uri(ConfigurationManager.AppSettings["pathImg"] + Posterpath + ConfigurationManager.AppSettings["apiKey"])); } }

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

            if (VoteAverage > 0f && VoteAverage < 2f)
            {
                filename = "1etoile.PNG";
            }
            else
            if (VoteAverage > 2f && VoteAverage < 4f)
            {
                filename = "2etoiles.PNG";
            }
            else
            if (VoteAverage > 4f && VoteAverage < 6f)
            {
                filename = "3etoiles.PNG";
            }
            else
            if (VoteAverage > 6f && VoteAverage < 8f)
            {
                filename = "1etoile.PNG";
            }
            else
            if (VoteAverage > 8f && VoteAverage < 10f)
            {
                filename = "5etoiles.PNG";
            }

            return new BitmapImage(new Uri(ConfigurationManager.AppSettings["pathRate"] + filename));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
