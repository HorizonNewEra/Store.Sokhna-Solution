using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Store.Sokhna.PL.Models
{
    public class ResetPasswordViewModel
	{
		[Required(ErrorMessage = "يجب ادخال الرقم السري")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Required(ErrorMessage = "يجب اعادت ادخال الرقم السري")]
		[DataType(DataType.Password)]
		[Compare(nameof(Password),ErrorMessage ="كلمه السر غير متطابق")]
		public string ConfirmPassword { get; set; }
	}
}
