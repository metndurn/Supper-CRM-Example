using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SupperCRMExample.DataAccess.Context;
using SupperCRMExample.Entities;

namespace SupperCRMExample.DataAccess
{
	public class ClientRepository
	{
		private readonly DatabaseContext _context;// DatabaseContext sınıfından bir nesne tanımlıyoruz, bu sınıf veritabanı bağlantısını ve işlemlerini yönetir.
		public ClientRepository(DatabaseContext context)/*nesne turetılerek context yapısı olusturuldu*/
		{
			_context = context;
		}
		public List<Client> GetAll()//burada butun client verilerini listelemek için bir metot yazıyoruz
		{
			return _context.Clients.ToList();
		}
		public Client Get(int id)//tekil bir veri çekilecegi zaman bu kullanılır 
		{
			return _context.Clients.Find(id); //id parametresine göre Client tablosundan veriyi bulur
		}
		public Client Add(Client model)//yeni bir client eklemek için bu metot kullanılır
		{
			_context.Clients.Add(model); //Client tablosuna yeni bir müşteri ekler
			if (_context.SaveChanges() > 0 ) //değişiklikleri veritabanına kaydeder
				return model; //Eğer kaydetme işlemi başarılıysa eklenen müşteri nesnesini döner
			
			return null; //Eğer kaydetme işlemi başarısızsa null döner	
		}
		/*void metod oldugu için geriye deger dondurmuyor o yuzden asagıdakı kodlar yazılıyor nerede hata varsa rahat bulalaım dıye*/
		public void Update(Client model)/*guncelleme yi verılen model ve id ile bulup yapıyor id ilede baska işlem yapılmak istenilebilinir*/
		{
			if (model.Id == 0) //model 0 ise yani null ise hata fırlatır
				throw new ArgumentNullException(nameof(model.Id), "Model cannot be null");
			var entity = _context.Entry(model);
			entity.State = EntityState.Modified; //modelin durumunu güncellenmiş olarak ayarlar
			if (_context.SaveChanges() == 0)
				throw new Exception("Güncelleme İşlemi Yapılamadı.."); //Eğer kaydetme işlemi başarısızsa bir hata fırlatır
		}
		public void Remove(int id)
		{
			_context.Clients.Remove(Get(id));
			if (_context.SaveChanges() == 0) //id ile bulunan müşteri kaydını siler ve değişiklikleri veritabanına kaydeder
				throw new Exception("Silme İşlemi Yapılamadı.."); //Eğer kaydetme işlemi başarısızsa bir hata fırlatır
		}
	}
}
