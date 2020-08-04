using FluentValidation;
using Trial.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using Trial.WebAPI.Common;

namespace Trial.WebAPI.Validators
{
    public class ProductValidator : AbstractValidator<ProductViewModel>
	{
        public ProductValidator()
		{
			RuleFor(x => x.Id).NotNull().WithMessage("Id is required");
			RuleFor(x => x.Name)
				.Cascade(CascadeMode.StopOnFirstFailure)
				.NotEmpty().WithMessage("Name is required")
				.Length(Constants.MinLengthName, Constants.MaxLengthName)
				.WithMessage($"Name should be greater {Constants.MinLengthName} and less {Constants.MaxLengthName}");
		
			RuleFor(x => x.ExpirationDate).Must(ValidateExpirationDateTime);

			RuleFor(x => x.ReceiptDate).Must(ValidateDateTime);
            RuleFor(x => x.CategoryProducts).Must(CheckCountCategoryProducts);
		}

		private bool ValidateExpirationDateTime(DateTime? date)
		{
			var currentDate = DateTime.Now;
			var expireDate = currentDate.AddDays(-Constants.ExpirationDays);

			return ValidateDateTime(date) || date < expireDate;
		}

        private bool CheckCountCategoryProducts(IList<CategoryProductViewModel> categoryProducts)
		{
			return categoryProducts.Count >= Constants.MinCategoryProductCount && 
				categoryProducts.Count <= Constants.MaxCategoryProductCount;
		}

        private bool ValidateDateTime(DateTime? date)
		{
			return date == null || !date.Equals(default);
		}
	}
}
