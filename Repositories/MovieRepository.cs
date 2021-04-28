using Lab22MoviePractice.Data;
using Lab22MoviePractice.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab22MoviePractice.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _context;
        

        public MovieRepository(MovieDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(MovieModel movie)
        {
            await _context.Movies.AddAsync(movie);//This is just a collection of memories
            await _context.SaveChangesAsync(); //this is supper imp adding to actually save data 
        }

        public async Task DeleteAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Movies.AnyAsync(e => e.ID == id);
            //throw new NotImplementedException();
        }

        public async Task<List<MovieModel>> GetAllMoviesAsync()
        {
           return  await _context.Movies.ToListAsync();
        }

        public async Task<MovieModel> GetMovieByIdAsync(int id)
        {
            return await _context.Movies.FirstOrDefaultAsync(_ => _.ID == id);
        }

        public async Task UpdateAsync(int id, MovieModel movie)
        {
            var foundMovie = await GetMovieByIdAsync(id);


            _context.Update(foundMovie);
            await _context.SaveChangesAsync();
        }

        //public async Task Test1()
        //{
        //    using (var context = new MovieDbContext())
        //    {
        //        context.Movies.FirstOrDefault(_ => _.ID == 1);
        //    }
        //}
    }
}
