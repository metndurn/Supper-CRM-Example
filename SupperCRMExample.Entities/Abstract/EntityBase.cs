using System.ComponentModel.DataAnnotations;

namespace SupperCRMExample.Entities.Abstract
{
	public abstract class EntityBase
	{ /*Temel bir sınıf, diğer sınıflar bu sınıftan türetilir Bu sınıfı kullanarak ortak özellikleri ve davranışları tanımlayabiliriz. Örneğin, tüm varlıkların sahip olması gereken ortak özellikler burada tanımlanabilir.*/
		[Key]
		public int Id { get; set; }

	}
}
