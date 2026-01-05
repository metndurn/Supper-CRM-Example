using System.ComponentModel.DataAnnotations;

namespace SupperCRMExample.Models
{
	public class CreateCustomerModel //müşteri oluşturmak için gerekli olan model
	{
		[Display(Name = "Ad Soyad / Şirket Adı")]// müşteri adı yada kurum adıda olabılır
		[Required(ErrorMessage ="{0} alanı zorunludur.")]
		[StringLength(60, ErrorMessage ="{0} alanı en fazla {1} karakter olabilir.")]
		public string Name { get; set; }// müşteri adı yada kurum adıda olabılır

		[Display(Name = "E-Posta")]
		[Required(ErrorMessage = "{0} alanı zorunludur.")]
		[StringLength(60, ErrorMessage = "{0} alanı en fazla {1} karakter olabilir.")]
		public string Email { get; set; }

		[Display(Name = "Telefon")]
		[Required(ErrorMessage = "{0} alanı zorunludur.")]
		[StringLength(60, ErrorMessage = "{0} alanı en fazla {1} karakter olabilir.")]
		public string Phone { get; set; }

		[Display(Name = "Açıklama")]
		[Required(ErrorMessage = "{0} alanı zorunludur.")]
		[StringLength(60, ErrorMessage = "{0} alanı en fazla {1} karakter olabilir.")]
		public string Description { get; set; }

		[Display(Name = "Kurumsal")]
		public bool IsCorporate { get; set; }

		[Display(Name = "Pasif")]
		public bool Locked { get; set; }
	}
}
