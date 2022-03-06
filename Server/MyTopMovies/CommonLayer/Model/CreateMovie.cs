using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTopMovies.CommonLayer.Model
{
    public class CreateMovieRequest
    {
        public string Title { get; set; }

        public string ImgUrl { get; set; }
        public int CategoryId { get; set; }

        public int Rate { get; set; }
    }

    public class CreateMovieResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

    }
}
