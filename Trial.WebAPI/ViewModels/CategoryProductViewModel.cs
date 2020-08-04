namespace Trial.WebAPI.ViewModels
{
    public class CategoryProductViewModel
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }

        public CategoryViewModel Category { get; set; }
        public ProductViewModel Product { get; set; }
    }
}
