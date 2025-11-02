using SupperCRMExample.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupperCRMExample.Entities
{
	[Table("Clients")] //Veritabanında Clients tablosuna karşılık gelir
	//müşteri sınıfı, müşteri bilgilerini tutar
	public class Client : EntityBase //müşteri sınıfı EntityBase sınıfından türetilir, böylece Id özelliğini miras alır
	{
		//DataAnnotations kısımları kullanarak veri doğrulama ve sınırlamalar ekliyoruz.
		[Required,StringLength(60)]
		public string Name { get; set; }// müşteri adı yada kurum adıda olabılır
		
		[Required, StringLength(60)]
		public string Email { get; set; }

		[StringLength(20)]
		public string Phone { get; set; }

		[StringLength(500)]
		public string Description { get; set; }

		public bool IsCorporate { get; set; }

		public bool Locked { get; set; }//aktif mi pasif mi
		public DateTime CreatedAt { get; set; }
	}
}
