using GUImovieWPF.Model;
using System.Collections.ObjectModel;

namespace GUImovieWPF.ViewModel
{
    class FilmViewModel
    {
        public ObservableCollection<FullFilm> Films { get; set; }

        public void LoadFilms()
        {
            ObservableCollection<FullFilm> films = new ObservableCollection<FullFilm>();
            Films = films;
        }
    }
}
