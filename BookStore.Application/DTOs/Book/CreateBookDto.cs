namespace BookStore.Application.DTOs.Book
{
    internal class CreateBookDto
    {
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
    }
}
