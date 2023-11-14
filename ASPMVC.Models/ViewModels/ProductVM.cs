using System;
using ASPMVC.Models.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPMVC.Models.ViewModels
{
	public class ProductVM
	{
		public Product Product { get; set; }

		//never will be validated
		[ValidateNever]
		public IEnumerable<SelectListItem> CategoryList { get; set; }
	}
}

