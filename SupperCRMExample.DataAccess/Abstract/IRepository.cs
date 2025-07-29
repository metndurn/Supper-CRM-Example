using SupperCRMExample.Entities.Abstract;

namespace SupperCRMExample.DataAccess.Abstract
{
	/*burada interface oluştu oluşma sekli ise alttakı clıentreposıtory sınıfına ctrl ile . yapıp olusturduk */
	public interface IRepository<TEntity>// TEntity burada Client sınıfını temsil eder, yani bu interface Client nesneleri ile çalışacak şekilde tasarlanmıştır.
		where TEntity : EntityBase //TEntity sınıfı, yani miras verdiğimiz yerden EntityBase sınıfından türemelidir. Bu, TEntity'nin EntityBase sınıfının özelliklerini ve davranışlarını miras almasını sağlar.
	{
		TEntity Add(TEntity model);
		TEntity Get(int id);
		List<TEntity> GetAll();
		void Remove(int id);
		void Update(TEntity model);
	}
}
