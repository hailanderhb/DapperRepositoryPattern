
using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[Post]")]

    public class Post
    {
        public int id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }


    }
}