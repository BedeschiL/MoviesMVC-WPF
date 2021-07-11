using GUImovieWPF.Model;
using GUImovieWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUImovieWPF.View
{
    /// <summary>
    /// Interaction logic for FilmView.xaml
    /// </summary>
    public partial class FilmView : UserControl
    {
        public FilmView()
        {
            InitializeComponent();
        }

        private void recherche_Click(object sender, RoutedEventArgs e)
        {

        }

        private void prev_Click(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("Clicked prev");
            ((FilmViewModel)DataContext).Page--;
            if (((FilmViewModel)DataContext).LoadFilms() != true)
            {
                Trace.WriteLine("Bad");
                ((FilmViewModel)DataContext).Page++;
            }
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("Clicked next");
            ((FilmViewModel)DataContext).Page++;
            if (((FilmViewModel)DataContext).LoadFilms() != true)
            {
                Trace.WriteLine("Bad");
                ((FilmViewModel)DataContext).Page--;
            }
        }

        private void details_Click(object sender, RoutedEventArgs e)
        {
            FilmModel selectedFilm = (FilmModel)dtFilm.SelectedCells.FirstOrDefault().Item;
            if (selectedFilm != null)
            {
                DetailsView detailsView = new DetailsView(selectedFilm.Id);
                detailsView.ShowDialog();
            }
        }
    }
}
