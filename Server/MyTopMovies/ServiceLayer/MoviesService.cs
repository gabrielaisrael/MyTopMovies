using MyTopMovies.CommonLayer.Model;
using MyTopMovies.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTopMovies.ServiceLayer
{
    public class MoviesService : IMoviesService
    {
        public readonly IMoviesRepository _moviesRepository;

        public MoviesService(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;

        }

        public async Task<CreateMovieResponse> CreateMovie(CreateMovieRequest request)
        {
            return await _moviesRepository.CreateMovie(request);
        }
        public async Task<DeleteMovieResponse> DeleteMovie(DeleteMovieRequest request)
        {
            return await _moviesRepository.DeleteMovie(request);
       }

        public async Task<ReadMovieResponse> ReadMovie()
        {
           return await _moviesRepository.ReadMovie();
        }

        public async Task<ReadCategoryResponse> ReadCategory()
        {
            return await _moviesRepository.ReadCategory();
        }

        public async Task<MovieCategoryResponse> MovieCategory()
        {
            return await _moviesRepository.MovieCategory();
        }
        public async Task<MovieIdResponse> MovieId(int Id)
        {
            return await _moviesRepository.MovieId(Id);
        }
    }
}
