using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTopMovies.CommonLayer.Model;
using MyTopMovies.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTopMovies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        public readonly IMoviesService _moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        [HttpPost]
        [Route(template: "CreateMovie")]
        public async Task<IActionResult> CreateMovie(CreateMovieRequest request)
        {
            CreateMovieResponse response = null;

            try
            {
                response = await _moviesService.CreateMovie(request);
            }catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;

            }

            return Ok(response);
        }

        [HttpGet]
      [Route(template: "ReadMovie")]
        public async Task<IActionResult> ReadMovie()
        {
            ReadMovieResponse response = null;
            try
            {
                response = await _moviesService.ReadMovie();
            }catch(Exception ex)
            {

            }
            return Ok(response);
        }
        [HttpGet]
        [Route(template: "ReadCategory")]
        public async Task<IActionResult> ReadCategory()
        {
            ReadCategoryResponse response = null;
            try
            {
                response = await _moviesService.ReadCategory();
            }
            catch (Exception ex)
            {

            }
            return Ok(response);
        }

        [HttpDelete]
        [Route(template: "DeleteMovie")]
        public async Task<IActionResult> DeleteMovie(DeleteMovieRequest request)
        {
            DeleteMovieResponse response = null;
            try
            {
                response = await _moviesService.DeleteMovie(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet]
        [Route(template: "MovieCategory")]
        public async Task<IActionResult> MovieCategory()
        {
            MovieCategoryResponse response = null;
            try
            {
                response = await _moviesService.MovieCategory();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet]
        [Route(template: "{Id}")]
        public async Task<IActionResult> MovieId(int Id)
        {
            MovieIdResponse response = null;
                try {
                response = await _moviesService.MovieId(Id);
            } catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

    }
}
