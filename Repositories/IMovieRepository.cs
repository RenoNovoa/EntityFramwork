using Lab22MoviePractice.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab22MoviePractice.Repositories
{
    public interface IMovieRepository 
    {
        Task CreateAsync(MovieModel movie);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<List<MovieModel>> GetAllMoviesAsync();
        Task<MovieModel> GetMovieByIdAsync(int id);
        Task UpdateAsync(MovieModel movie);
    }
}
