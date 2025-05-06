using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Store.Sokhna.PL.Models
{
    public class LogInViewModel
	{
		[Required(ErrorMessage = "يجب ادخال اسم مستخدم")]
		public string UserName { get; set; }
		[Required(ErrorMessage = "يجب ادخال الرقم السري")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		public bool RememberMe { get; set; }
	}
}
