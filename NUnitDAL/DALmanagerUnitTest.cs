using DAL_DataAcessLayer;
using DAL_DataAcessLayer.Managers;
using NUnit.Framework;
using System.Linq;

namespace NUnitDAL
{
    public class Tests
    {
        private DALmanager _dalManager;
        
        [SetUp]
        public void Setup()
        {
            _dalManager = new DALmanager();
        }

        [TestCase(100)]
        [TestCase(200)]
        [TestCase(300)]
        public void SelectFilmWithIdReturnsFilm(int id)
        {
            Assert.IsTrue(_dalManager.SelectFilmWithId(id) is Film, $"SelectFilmWithId does not return a Film for the id {id}");
        }

        [TestCase(-1, -1)]
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        public void GetPageOfFilmOrderByTitleReturnsIQueryableFilm(int index, int numberbypage)
        {
            Assert.IsTrue(_dalManager.GetPageOfFilmOrderByTitle(index, numberbypage) is IQueryable<Film>, $"GetPageOfFilmOrderByTitle does not return a IQueryable<Film> for the index {index} and numberbypage {numberbypage}");
        }

        [TestCase("", -1, -1)]
        [TestCase("", 0, 0)]
        [TestCase("", 1, 1)]
        public void GetFilmListWithNameReturnsIQueryableFilm(string name, int index, int numberbypage)
        {
            Assert.IsTrue(_dalManager.GetFilmListWithName(name, index, numberbypage) is IQueryable<Film>, $"GetFilmListWithName does not return a IQueryable<Film> for the name {name}, index {index} and numberbypage {numberbypage}");
        }

        [TestCase("")]
        [TestCase("")]
        [TestCase("")]
        public void SelectActorWithNameReturnsIQueryableActor(string name)
        {
            Assert.IsTrue(_dalManager.SelectActorWithName(name) is IQueryable<Actor>, $"SelectActorWithName does not return a IQueryable<Film> for the name {name}");
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        public void SelectActorWithIdReturnsIQueryableActor(int id)
        {
            Assert.IsTrue(_dalManager.SelectActorWithId(id) is IQueryable<Actor>, $"SelectActorWithId does not return a IQueryable<Film> for the id {id}");
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        public void SelectActorNbFilmMinReturnsIQueryableActor(int nbFilmMin)
        {
            Assert.IsTrue(_dalManager.SelectActorNbFilmMin(nbFilmMin) is IQueryable<Actor>, $"SelectActorNbFilmMin does not return a IQueryable<Film> for the nbFilmMin {nbFilmMin}");
        }
    }
}