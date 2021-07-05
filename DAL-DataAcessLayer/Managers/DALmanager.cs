﻿
using DAL_DataAcessLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL_DataAcessLayer.Managers
{
    public class DALmanager : IDisposable
    {
        #region Propriete
        public MovieContext movC;
        #endregion
        #region Constructeurs
        public DALmanager()
        {
            movC = new MovieContext();
        }
        #endregion
        public Film SelectFilmWithId(int IDF)
        {
            return (movC.Films.Include("Actors").Include("Types").Include("Comments").FirstOrDefault(f => f.Id == IDF));
        }

        public IQueryable<Film> GetPageOfFilmOrderByTitle(int index, int numberbypage)
        {
            return movC.Films.OrderBy(f => f.Title).Skip(index).Take(numberbypage);
        }

        public IQueryable<Film> GetFilmListWithName(string name)
        {
            return movC.Films.OrderBy(f => f.Title).Where(f => f.Title.ToLower().Contains(name.ToLower()));
        }

        public IQueryable<Actor> SelectActorWithName(String name)
        {
            return movC.Actors.Include("Films").Where(a => a.Name.ToLower().Contains(name.ToLower()));
        }

        public IQueryable<Actor> SelectActorNbFilmMin(int NbFilmMin)
        {
            return movC.Actors.Include("Films").Where(a => a.Films.Count >= NbFilmMin).OrderBy(a => a.Films.Count);
        }

        public void InsertComment(Comment c)
        {
            movC.Comments.Add(c);
            movC.SaveChanges();
        }
        public void Dispose()
        {
            movC?.Dispose();
        }
    }
}