namespace BookStore.Application.DTOs.Book
{
    internal class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? Description { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
    }
}
