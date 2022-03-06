using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTopMovies.CommonLayer.Model
{
    public class ReadMovieResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<ReadMovieData> readMovieData { get; set; }
    }

    public class ReadMovieData
    {
        public string Title { get; set; }
        public string ImgUrl { get; set; }
        public int CategoryId { get; set; }
        public int Rate { get; set; }

    }
}