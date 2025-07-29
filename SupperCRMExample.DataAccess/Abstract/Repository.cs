using Microsoft.EntityFrameworkCore;
using SupperCRMExample.DataAccess.Context;
using SupperCRMExample.Entities.Abstract;

namespace SupperCRMExample.DataAccess.Abstract
{

	/*burada interface oluştu oluşma sekli ise alttakı clıentreposıtory sınıfına ctrl ile . yapıp olusturduk */
	/*burada Repository kısmında hangı tur verıldeyse o turden imterface devam edılmelıdır
	 burada genel olarak bır generıc sınıf olan repository olusturduk yanı burada client dersek client ile ilgili bilgiler gelecektir*/
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
	{
		private readonly DatabaseContext _context;// DatabaseContext sınıfından bir nesne tanımlıyoruz, bu sınıf veritabanı bağlantısını ve işlemlerini yönetir.
		private readonly DbSet<TEntity> _dbSet;
		public Repository(DatabaseContext context)/*nesne turetılerek context yapısı olusturuldu*/
		{
			_context = context;
			_dbSet = _context.Set<TEntity>(); //TEntity türündeki DbSet'i başlatır, böylece bu sınıf TEntity türündeki verilerle çalışabilir.
		}
		public List<TEntity> GetAll()//burada butun client verilerini listelemek için bir metot yazıyoruz
		{
			return _dbSet.ToList();
		}
		public TEntity Get(int id)//tekil bir veri çekilecegi zaman bu kullanılır 
		{
			return _dbSet.Find(id); //id parametresine göre Client tablosundan veriyi bulur
		}
		public TEntity Add(TEntity model)//yeni bir client eklemek için bu metot kullanılır
		{
			_dbSet.Add(model); //Client tablosuna yeni bir müşteri ekler
			if (_context.SaveChanges() > 0) //değişiklikleri veritabanına kaydeder
				return model; //Eğer kaydetme işlemi başarılıysa eklenen müşteri nesnesini döner

			return null; //Eğer kaydetme işlemi başarısızsa null döner	
		}
		/*void metod oldugu için geriye deger dondurmuyor o yuzden asagıdakı kodlar yazılıyor nerede hata varsa rahat bulalaım dıye*/
		public void Update(TEntity model)/*guncelleme yi verılen model ve id ile bulup yapıyor id ilede baska işlem yapılmak istenilebilinir*/
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
			_dbSet.Remove(Get(id));
			if (_context.SaveChanges() == 0) //id ile bulunan müşteri kaydını siler ve değişiklikleri veritabanına kaydeder
				throw new Exception("Silme İşlemi Yapılamadı.."); //Eğer kaydetme işlemi başarısızsa bir hata fırlatır
		}
	}
}
