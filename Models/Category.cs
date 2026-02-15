namespace AfaqMall.Models
{
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; } // required لتجنب التحذير
    }
}
