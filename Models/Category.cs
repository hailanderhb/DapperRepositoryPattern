
using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[Category]")]

    public class Category
    {
        public int id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }


    }
}