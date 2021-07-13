using DTO_DataTransferObject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Text;
using System.Windows.Media.Imaging;

namespace GUImovieWPF.Model
{
    public class FullFilmModel : FullFilmDTO, INotifyPropertyChanged
    {
        public override int Id { get { return _id; } set { _id = value; OnPropertyChanged("Id"); } }
        public override string Title { get { return _title; } set { _title = value; OnPropertyChanged("Title"); } }
        //Release date du film
        public override DateTime Date { get { return _date; } set { _date = value; OnPropertyChanged("Date"); } }
        public override float VoteAverage { get { return _voteAverage; } set { _voteAverage = value; OnPropertyChanged("VoteAverage"); } }
        public override int Runtime { get { return _runtime; } set { _runtime = value; OnPropertyChanged("Runtime"); } }
        public string ReadableRuntime { get { return String.Format("{0}h{1}", Runtime / 60, (Runtime % 60).ToString("D2")); } }
        public override string Posterpath { get { return _posterpath; } set { _posterpath = value; OnPropertyChanged("Posterpath"); } }
        public ObservableCollection<BitmapImage> TypeIcons { get { return GetTypeIcons(); } }

        public FullFilmModel(FullFilmDTO ff)
        {
            Id = ff.Id;
            Title = ff.Title;
            Date = ff.Date;
            VoteAverage = ff.VoteAverage;
            Runtime = ff.Runtime;
            Posterpath = ff.Posterpath;
            ActorsDTO = ff.ActorsDTO;
            TypesDTO = ff.TypesDTO;
            CommentsDTO = ff.CommentsDTO;
        }

        public ObservableCollection<BitmapImage> GetTypeIcons()
        {
            ObservableCollection<BitmapImage> iconlist = new ObservableCollection<BitmapImage>();
            foreach(FilmTypeDTO t in TypesDTO)
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
