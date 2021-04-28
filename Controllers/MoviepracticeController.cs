using Lab22MoviePractice.Models;
using Lab22MoviePractice.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lab22MoviePractice.Controllers
{
    public class MoviepracticeController : Controller
    {
        private readonly IMovieRepository _repository;

        public MoviepracticeController(IMovieRepository repository)
        {
            _repository = repository;
        }

        // Here he add the async Task<IActionResult> 
        public async Task<IActionResult> Index()
        {
            var results = await _repository.GetAllMoviesAsync();
            return View(results);
        }

        public IActionResult RegisterMovie()
        {
            return View();
        }

        public async Task<IActionResult> RegisterMovieDetails(MovieModel moviepracticeModel)
        {
            if (ModelState.IsValid) // Validation properties using atributes asigned to the properties
            {
                await _repository.CreateAsync(moviepracticeModel);
                return View("Details", moviepracticeModel);
            }

            return View("RegisterMovie", moviepracticeModel);
        }

        public async Task<IActionResult> Delete([FromRoute] int id) // you add the atrubute FromRoute
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction("Index"); //nameof(Index)
        }

        public async Task<IActionResult> Details([FromRoute] int id) // you add the atrubute FromRoute
        {
            var movie = await _repository.GetMovieByIdAsync(id);
            return View(movie);
            //await _repository.DeleteAsync(id);
            //return RedirectToAction("Index"); //nameof(Index)
        }

        public async Task<IActionResult> EditMovie([FromRoute] int? id)
        {
            if (id is null)
            {
                return RedirectToAction(nameof(Index));
            }

            var foundMovie = await _repository.GetMovieByIdAsync((int)id);

            return View(foundMovie);
        }

        [HttpPost]
        public async Task<IActionResult> EditMovie([FromRoute] int? id, [Bind("Title,Genre,Year,Actors,Directors")] MovieModel movie)
        w{
            if (id is null)
            {
                return RedirectToAction(nameof(Index));
            }

            await _repository.UpdateAsync((int)id, movie);

            return View("Details", await _repository.GetMovieByIdAsync((int)id));
        }


        //public  IActionResult SearchResultGenre(Genre Genre)
        //{
        //    var movies = _movies.Where(x => x.Genre == Genre).ToList();
        //    return View(movies);
        //}

        //public IActionResult SearchResultTitle(string Title)
        //{
        //    return View();
        //}

        //public IActionResult Search()
        //{
        //    return View();
        //}
    }
}

