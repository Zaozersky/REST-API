using Trial.WebAPI.Common;
using System;
using System.Collections.Generic;

namespace Trial.WebAPI.ViewModels
{
    public class ProductViewModel
    {
        private double _rating;

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Featured { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int ItemsInStock { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public double Rating 
        {
            get => _rating;

            set
            {
                if (value > Constants.ProductRatingThreshold)
                {
                    Featured = true;
                }

                _rating = value;
            }
        }

        public int BrandId { get; set; }

        public BrandViewModel Brand { get; set; }

        public IList<CategoryProductViewModel> CategoryProducts { get; set; }
    }
}
