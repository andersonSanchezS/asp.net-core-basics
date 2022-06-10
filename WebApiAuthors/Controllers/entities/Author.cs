namespace WebApiAuthors.Controllers.entities
{
    public class Author
    {
        public int id { get; set; }

        public string name { get; set; }

        public List<book> books { get; set; }
    }
}
