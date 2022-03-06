using MyTopMovies.CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTopMovies.ServiceLayer
{
    public interface IMoviesService
    {
        public Task<CreateMovieResponse> CreateMovie(CreateMovieRequest request);
        public Task<ReadMovieResponse> ReadMovie();
        public Task<ReadCategoryResponse> ReadCategory();

        public Task<MovieCategoryResponse> MovieCategory();
        public Task<MovieIdResponse> MovieId(int Id);
        public Task<DeleteMovieResponse> DeleteMovie(DeleteMovieRequest request);
    }
}
