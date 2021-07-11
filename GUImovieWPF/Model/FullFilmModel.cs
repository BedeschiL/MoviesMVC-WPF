using DTO_DataTransferObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

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
        public override string Posterpath { get { return _posterpath; } set { _posterpath = value; OnPropertyChanged("Posterpath"); } }

        public FullFilmModel(FullFilmDTO ff)
        {
            Id = ff.Id;
            Title = ff.Title;
            Date = ff.Date;
            VoteAverage = ff.VoteAverage;
            Runtime = ff.Runtime;
            Posterpath = ff.Posterpath;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
