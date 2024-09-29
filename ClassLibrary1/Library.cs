namespace ClassLibrary1
{
    public class Library
    {
        private List<Book> _listOfBooks = new List<Book>();

        public void AddBook(Book book)
        {
            _listOfBooks.Add(book);
        }
        public Book[] GetBooks() {
            return _listOfBooks.ToArray(); 
        }
    }
}
