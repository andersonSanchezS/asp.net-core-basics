namespace WebApiAuthors.Controllers.entities
{
    public class book
    {
        public int id { get; set; }

        public string title { get; set; }

        public int AuthorId { get; set; }
        
        public Author Author { get; set; }
    }
}
