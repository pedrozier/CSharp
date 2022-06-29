namespace HateoasAPI.Application.Models
{
    public class Product : Source
    {

        public int Id { get; set; }

        public string ProductName { get; set; }    

        public decimal ProductPrice { get; set; }
    }
}
