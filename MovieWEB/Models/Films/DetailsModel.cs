using DTO_DataTransferObject;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using Windows.UI.Xaml.Media.Imaging;

namespace MovieWEB.Models
{
    public class DetailsModel : FullFilmDTO
    {
        public string runtimeToString { get; set; }
        public DetailsModel(FullFilmDTO f)
        {
            Id = f.Id;
            Title = f.Title;
            Date = f.Date;     
            Runtime = f.Runtime;
            Posterpath = f.Posterpath;
            ActorsDTO = f.ActorsDTO;
            TypesDTO = f.TypesDTO;
            CommentsDTO = f.CommentsDTO;
            this.VoteAverage = f.VoteAverage;
            if (this.Runtime > 0)
            {
                this.runtimeToString = this.getDuree(this.Runtime);
            }
        }
        public string getDuree(int run)
        {
            int heure = run / 60;
            int minute = run % 60;
            return heure.ToString() + "h" + minute.ToString();
        }



    }
}
