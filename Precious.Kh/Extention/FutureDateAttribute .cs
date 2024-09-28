using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Precious.core.Extention
{
	public class FutureDateAttribute : ValidationAttribute
	{
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			if(value is DateTime dateTime)
			{
				if(dateTime < DateTime.Now)
				{
					return new ValidationResult("Ngày nhập không được nhỏ hơn ngày hiện tại.");
				}
			}
			return ValidationResult.Success;
		}
	}
}
