using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SupperCRMExample.DataAccess.Abstract;
using SupperCRMExample.DataAccess.Context;
using SupperCRMExample.Entities;
using SupperCRMExample.Entities.Abstract;

namespace SupperCRMExample.DataAccess
{


	public class ClientRepository : Repository<Client>, IRepository<Client>/*yukarıdaki IRepository interface ile client ile ilgili olan herseyi  burada goruyoruz*/
	{
		private readonly DatabaseContext _context;// DatabaseContext sınıfından bir nesne tanımlıyoruz, bu sınıf veritabanı bağlantısını ve işlemlerini yönetir.
		public ClientRepository(DatabaseContext context) : base(context)/*nesne turetılerek context yapısı olusturuldu base sonradan eklendi */
		{
			_context = context;
		}
	}
}
