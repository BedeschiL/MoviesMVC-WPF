using DTO_DataTransferObject;
using GUImovieWPF.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUImovieWPF.View
{
    /// <summary>
    /// Interaction logic for DetailsView.xaml
    /// </summary>
    public partial class DetailsView : Window
    {
        private FullFilmModel SelectedFilm { get; set; }
        public DetailsView()
        {
            InitializeComponent();
            SelectedFilm = new FullFilmModel(new FullFilmDTO());
            DataContext = SelectedFilm;
        }

        public DetailsView(int id)
        {
            InitializeComponent();

            Trace.WriteLine("INIT DETAILS  " + id);

            //PREPARATION APPEL API
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(ConfigurationManager.AppSettings["basicURL"])
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string route = ConfigurationManager.AppSettings["basicURL"] + "movie/details?idF=#id#".Replace("#id#", id.ToString());
            Trace.WriteLine(route);

            HttpResponseMessage reponse = client.GetAsync(route).Result;
            Trace.WriteLine(reponse.Content.ReadAsStringAsync().Result);

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            SelectedFilm = new FullFilmModel(JsonSerializer.Deserialize<FullFilmDTO>(reponse.Content.ReadAsStringAsync().Result, options));

            DataContext = SelectedFilm;
        }
    }
}
