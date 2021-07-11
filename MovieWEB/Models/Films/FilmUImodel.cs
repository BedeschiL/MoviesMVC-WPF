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
    public class FilmUiModel : FilmDTO
    {
        public string runtimeToString { get; set; }
        public FilmUiModel(FilmDTO f) 
        {
          
            //////////////////
            this.Id = f.Id;
            this.Runtime=f.Runtime;
            this.Posterpath = f.Posterpath;
            this.Comments = f.Comments;
            this.Date = f.Date;
            this.Title = f.Title;
            this.VoteAverage = f.VoteAverage;
            if(this.Runtime>0)
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
