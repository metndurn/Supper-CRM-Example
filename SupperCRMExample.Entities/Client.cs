using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupperCRMExample.Entities
{
	[Table("Clients")] //Veritabanında Clients tablosuna karşılık gelir
	public class Client //müşteri sınıfı, müşteri bilgilerini tutar
	{
		//DataAnnotations kısımları kullanarak veri doğrulama ve sınırlamalar ekliyoruz.
		[Key]
		public int Id { get; set; }
		
		[Required,StringLength(60)]
		public string Name { get; set; }// müşteri adı yada kurum adıda olabılır
		
		[Required, StringLength(60)]
		public string Email { get; set; }

		[StringLength(20)]
		public string Phone { get; set; }

		[StringLength(500)]
		public string Description { get; set; }
		public bool Locked { get; set; }//aktif mi pasif mi
		public DateTime CreatedAt { get; set; }
	}
}
