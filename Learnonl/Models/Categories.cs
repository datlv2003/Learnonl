namespace Learnonl.Models
{
    public class Categories
    {
        public int? CategoryId { get; set; }

        public string? Name { get; set; }

        public string? FileImage { get; set; }

        public Decimal? Price { get; set; }

        public decimal? Discount { get; set; }

        public string? Teacher { get; set; }

        public int? CourseId { get; set; }
        public string? Description { get; set; }
    }
}
