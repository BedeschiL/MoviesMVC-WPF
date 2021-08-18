using DAL_DataAcessLayer.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DAL_DataAcessLayer.Parser
{
    public class FileParser
    {
        public void LoadTextFileInDB(string file, int NbFilmToLoad)
        {
            Console.WriteLine("Test lecture fichier");

            var f = new StreamReader(file);
            //Console.WriteLine("Data peut se co : " + CtxDB.Database.CanConnect());

            List<Film> TempLFilm = new List<Film>();
            List<FilmType> TempLTypeFilm = new List<FilmType>();
            List<Actor> TempLActor = new List<Actor>();


            for (int i = 0; i < NbFilmToLoad; i++)
            {
                var line = f.ReadLine();
                if (line != null)
                {
                    //Console.WriteLine("----------------------------\n Nouveau film !!! \n");
                    Char[] delimiterChars = { '\u2023' };
                    var filmdetailwords = line.Split(delimiterChars);

                    Film film = new Film();

                    //Console.WriteLine("f.Id "+ Int32.Parse(filmdetailwords[0]));
                    film.Id = int.Parse(filmdetailwords[0], 0);
                    Console.WriteLine("N°Ligne : " + i + "f.Title " + filmdetailwords[1]);
                    film.Title = filmdetailwords[1];
                    //Console.WriteLine("f.Date " + filmdetailwords[3]);
                    try
                    {
                        film.Date = Convert.ToDateTime(filmdetailwords[3]);
                    }
                    catch (System.FormatException) { };
                    //Console.WriteLine("f.Runtime " + Int32.Parse(filmdetailwords[7]));
                    film.Runtime = int.Parse(filmdetailwords[7], 0);
                    //Console.WriteLine("f.Posterpath " + filmdetailwords[9]);
                    film.Posterpath = filmdetailwords[9];

                    film.VoteAverage = 0;

                    delimiterChars[0] = '\u2016';
                    if (filmdetailwords.Length == 15)
                    {
                        var genres = filmdetailwords[12].Split(delimiterChars);
                        //Console.WriteLine("Genre : ");
                        foreach (string s in genres)
                        {
                            if (s.Length > 0)
                            {
                                FilmType filmtype = new FilmType(s);

                                int IndexFT = TempLTypeFilm.FindIndex(genre => genre.Id == filmtype.Id);
                                if (IndexFT == -1)
                                {
                                    //Console.WriteLine("Ajout type de film : " + filmtype);
                                    TempLTypeFilm.Add(filmtype);
                                    film.Types.Add(TempLTypeFilm[^1]);
                                }
                                else
                                {
                                    //Console.WriteLine("Utilisation type de film : " + TempLTypeFilm[IndexFT]);
                                    film.Types.Add(TempLTypeFilm[IndexFT]);
                                }
                            }

                        }
                        var acteurs = filmdetailwords[14].Split(delimiterChars);
                        //Console.WriteLine("Acteur : ");
                        foreach (string s in acteurs)
                        {
                            if (s.Length > 0)
                            {
                                Actor acteur = new Actor(s);

                                int IndexActor = TempLActor.FindIndex(act => act.Id == acteur.Id);
                                if (IndexActor == -1)
                                {
                                    //Console.WriteLine("Ajout d'un acteur : " + acteur);
                                    TempLActor.Add(acteur);
                                    film.Actors.Add(TempLActor[^1]);
                                }
                                else
                                {
                                    //Console.WriteLine("Utilisation d'un acteur : " + TempLActor[IndexActor]);
                                    film.Actors.Add(TempLActor[IndexActor]);
                                }
                            }
                        }
                    }
                    TempLFilm.Add(film);
                }
            }
            using (MovieContext CtxDB = new MovieContext())
            {
                CtxDB.Database.EnsureDeleted();
                CtxDB.Database.EnsureCreated();
                CtxDB.AddRange(TempLTypeFilm);
                CtxDB.AddRange(TempLActor);
                CtxDB.SaveChanges();
                CtxDB.AddRange(TempLFilm);
                CtxDB.SaveChanges();
                CtxDB.Dispose();
            }
        }
    }
}

