using Lab22MoviePractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab22MoviePractice.Repositories
{
    public class MocMovieRepository : IMovieRepository
    {
        public Task CreateAsync(MovieModel movie)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<MovieModel>> GetAllMoviesAsync()
        {
            //throw new NotImplementedException();
            return Task.FromResult(new List<MovieModel>
            {
                new MovieModel
                {
                    ID = 65,
                    Title = "Coco",
                    Genre = 0,
                    Year = "2018",
                    Actors= "Rambo",
                    Directors = "Danny Novoa"
                }
            });
        }

        public Task<MovieModel> GetMovieByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(MovieModel movie)
        {
            throw new NotImplementedException();
        }
    }
}
