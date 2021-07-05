

using DAL_DataAcessLayer;
using DAL_DataAcessLayer.Managers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace ClassesAlimentation
{
    public class LectureFichierMovie
    {
        private string uri = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBase\\newTest.db"));
        public LectureFichierMovie()
        {

        }
        public string lectureLigne(DALmanager manager)
        {
            StreamReader f = new StreamReader(uri+"movies.txt");
            string line;

            line = f.ReadLine(); 
            if (line == null)
            {
                Console.WriteLine("Program.cs Console : Erreur ligne 16 : Line == NULL");
            }
            #if tr
            Console.WriteLine("Retour de brut du fichier  : " + line +"\n");
            #endif
            return line;
        }
        public void lectureMultiple(int limiteMax, DALmanager manager)
        {
            ICollection<Film> temp = new List<Film>();
            StreamReader f = new StreamReader(uri+"movies.txt");
            string line;
            int i = 0;
            while (i < limiteMax)
            {
                line = f.ReadLine();
                if (line == null)
                {
                    Console.WriteLine("Program.cs Console : Erreur ligne 16 : Line == NULL");
                }
                #if tr
                Console.WriteLine("Retour de brut du fichier  : " + line + "\n");
                #endif
                Film F = FilmParser.DecodeFilmText(line,manager);
                var filmTmp = manager.GetFilmById(F.Id);
                //SI FILMTMP != null ça veut dire qu'il y a un film
                if (filmTmp == null)
                {

                    manager.AddFilm(F);
#if tr
                    Console.WriteLine("LECTUREfichier : FILM NON PRESENT");
#endif
                   
                }
                else Console.WriteLine("LECTUREfichier : FILM DEJA PRESENT");

                i++;
            }
            
           
        }
    }
}
