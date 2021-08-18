using BLL_BusinessLogicLayer;
using DTO_DataTransferObject;
using NUnit.Framework;
using System.Collections.Generic;

namespace NUnitBLL
{
    public class Tests
    {
        private BLLmanager _bllManager;
        
        [SetUp]
        public void Setup()
        {
            _bllManager = new BLLmanager();
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        public void GetListActorsByIdFilmReturnsICollectionLightActorDTO(int id)
        {
            Assert.IsTrue(_bllManager.GetListActorsByIdFilm(id) is ICollection<LightActorDTO>, $"GetListActorsByIdFilm does not return a ICollection<LightActorDTO> for the id {id}");
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        public void GetFavoriteActorsReturnsICollectionActorDTO(int nbDefilmCondition)
        {
            Assert.IsTrue(_bllManager.GetFavoriteActors(nbDefilmCondition) is ICollection<ActorDTO>, $"GetFavoriteActors does not return a ICollection<ActorDTO> for the nbDefilmCondition {nbDefilmCondition}");
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        public void GetListFilmTypesByIdFilmReturnsICollectionFilmTypeDTO(int id)
        {
            Assert.IsTrue(_bllManager.GetListFilmTypesByIdFilm(id) is ICollection<FilmTypeDTO>, $"GetListFilmTypesByIdFilm does not return a ICollection<FilmTypeDTO> for the id {id}");
        }

        [TestCase("", -1)]
        [TestCase("", 0)]
        [TestCase("", 1)]
        public void FindListFilmByPartialActorNameReturnsListFilmDTO(string name, int maxFilm)
        {
            Assert.IsTrue(_bllManager.FindListFilmByPartialActorName(name, maxFilm) is List<FilmDTO>, $"FindListFilmByPartialActorName does not return a List<FilmDTO> for the name {name} and maxFilm {maxFilm}");
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        public void GetFullFilmDetailsByIdFilmReturnsFullFilmDTO(int id)
        {
            Assert.IsTrue(_bllManager.GetFullFilmDetailsByIdFilm(id) is FullFilmDTO, $"GetFullFilmDetailsByIdFilm does not return a FullFilmDTO for the id {id}");
        }

        [TestCase(-1, -1)]
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        public void GetPageOfFilmDTOOrderByTitleReturnsListFilmDTO(int index, int nbbypage)
        {
            Assert.IsTrue(_bllManager.GetPageOfFilmDTOOrderByTitle(index, nbbypage) is List<FilmDTO>, $"GetPageOfFilmDTOOrderByTitle does not return a List<FilmDTO> for the index {index} and nbbypage {nbbypage}");
        }

        [TestCase("", -1, -1)]
        [TestCase("", 0, 0)]
        [TestCase("", 1, 1)]
        public void GetFilmListWithNameReturnsListFilmDTO(string name, int index, int nbbypage)
        {
            Assert.IsTrue(_bllManager.GetFilmListWithName(name, index, nbbypage) is List<FilmDTO>, $"GetFilmListWithName does not return a List<FilmDTO> for the name {name}, index {index} and nbbypage {nbbypage}");
        }

        //InsertCommentOnFilmId
        //GetImage
        //VoteAverageCalculator
    }
}