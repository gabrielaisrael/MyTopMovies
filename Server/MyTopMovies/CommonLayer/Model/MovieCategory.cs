using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTopMovies.CommonLayer.Model
{
    public class MovieCategoryResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<MovieCategoryData> MovieCategoryData { get; set; }
    }

    public class MovieCategoryData
    {
        public int Id { get; set; }
        public string Title { get; set; }

    }
}

