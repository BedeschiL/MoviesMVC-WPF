
using BLL_BusinessLogicLayer;
using DAL_DataAcessLayer.Parser;
using DTO_DataTransferObject;
using System;
using System.Collections.Generic;
using System.IO;

namespace MoviesMVC_WPF
{
    class ConsoleProgram
    {
        static void Main(string[] args)
        {
            FileParser fp = new FileParser();

            //CREATION DB
            /*Console.WriteLine(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\DataBase\\movie.db")));
            String movieFilePath = "C:\\movie\\movie.txt";
            fp.LoadTextFileInDB(movieFilePath,1000);*/
            //------------------------
            Console.WriteLine(DateTime.Now);

            //TEST BLL 
            BLLmanager BLLmanager = new BLLmanager();
            ICollection<LightActorDTO>  temp = BLLmanager.GetListActorsByIdFilm(2);

            foreach(LightActorDTO t in temp)
            {
                Console.WriteLine(t.Name + t.Id);
            }
            Console.WriteLine("SORTIE DU PROGR!");
            Console.ReadKey();
        }
    }
}
