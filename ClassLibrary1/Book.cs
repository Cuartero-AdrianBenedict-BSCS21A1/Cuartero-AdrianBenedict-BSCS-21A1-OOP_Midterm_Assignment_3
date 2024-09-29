namespace ClassLibrary1
{
    public class Book
    {
        public string Title { get; }
        public string ISBN { get; }
        public string Author { get; }
        public Book(string Title, string Author, string ISBN)
        {
            this.Title = Title;
            this.ISBN = ISBN;
            this.Author = Author;
        }
    }
}
