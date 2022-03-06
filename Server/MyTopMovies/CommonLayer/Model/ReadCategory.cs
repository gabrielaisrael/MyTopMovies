using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTopMovies.CommonLayer.Model
{
    public class ReadCategoryResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<ReadCategoryData> readCategoryData { get; set; }

}

    public class ReadCategoryData
    {
        public string Title { get; set; }
    }
}
