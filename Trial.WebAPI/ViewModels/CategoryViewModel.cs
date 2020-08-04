using System.Collections.Generic;

namespace Trial.WebAPI.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<CategoryProductViewModel> CategoryProducts { get; set; }
    }
}
