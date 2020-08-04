using System.Collections.Generic;

namespace Trial.WebAPI.ViewModels
{
    public class BrandViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public IList<ProductViewModel> Products { get; set; }
    }
}
