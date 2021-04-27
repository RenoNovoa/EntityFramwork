using Lab22MoviePractice.Models;
using Lab22MoviePractice.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public  async Task<IActionResult> Delete([FromRoute]int id) // you add the atrubute FromRoute
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction("Index"); //nameof(Index)
        }

        public async Task<IActionResult> Details([FromRoute] int id) // you add the atrubute FromRoute
        {
            var movie = await _repository.GetMovieByIdAsync(id);
            return RedirectToAction(nameof(RegisterMovieDetails), movie);
            //await _repository.DeleteAsync(id);
            //return RedirectToAction("Index"); //nameof(Index)
        }

        public async Task<IActionResult> RegisterMovieDetails(MovieModel moviepracticeModel)
        {
            if (ModelState.IsValid) // Validation properties using atributes asigned to the properties
            {
                await _repository.CreateAsync(moviepracticeModel);
                return View(moviepracticeModel);
            }

            return View("RegisterMovie", moviepracticeModel);
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

