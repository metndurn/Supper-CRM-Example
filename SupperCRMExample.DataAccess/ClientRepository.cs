using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SupperCRMExample.DataAccess.Abstract;
using SupperCRMExample.DataAccess.Context;
using SupperCRMExample.Entities;
using SupperCRMExample.Entities.Abstract;

namespace SupperCRMExample.DataAccess
{
	/*dipnot bız burada bunları kaldırırsak proje yine de sorunsuz sekılde calısacaktır ozel olarakta
	 buraya ihtiyaca gore kodlar yazabıleyım*/
	public interface ICleintRepository : IRepository<Client> //ClientRepository sınıfı, IRepository<Client> arayüzünü uygular, yani Client nesneleri ile çalışır.
	{
		//Burada ClientRepository sınıfına özel metotlar tanımlanabilir buraya yazılan kdolar ClientRepository sınıfında kullanılabilir.
	}

	public class ClientRepository : Repository<Client>, ICleintRepository/*yukarıdaki IRepository interface ile client ile ilgili olan herseyi  burada goruyoruz*/
	{
		private readonly DatabaseContext _context;// DatabaseContext sınıfından bir nesne tanımlıyoruz, bu sınıf veritabanı bağlantısını ve işlemlerini yönetir.
		public ClientRepository(DatabaseContext context) : base(context)/*nesne turetılerek context yapısı olusturuldu base sonradan eklendi */
		{
			_context = context;
		}
	}
}
