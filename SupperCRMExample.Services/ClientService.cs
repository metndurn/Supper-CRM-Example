using SupperCRMExample.DataAccess;
using SupperCRMExample.DataAccess.Abstract;
using SupperCRMExample.Entities;
using SupperCRMExample.Models;

namespace SupperCRMExample.Services
{
	public interface IClientService
	{
		void Create(string name, string email);//müşteri oluşturma metodu ama sadece name ve email alır
		void Create(CreateCustomerModel model);//müşteri oluşturma metodu ama CreateCustomerModel model alır
		List<Client> List();
	}

	public class ClientService : IClientService
	//client hakkında hersey burada yazılacak
	{
		//CRUD işlemleri için gerekli metotlar burada tanımlanacak
		private readonly ICleintRepository _repository;// ICleintRepository arayüzünden bir repository nesnesi tanımlıyoruz, bu sayede ClientRepository sınıfının metotlarını kullanabileceğiz.

		public ClientService(ICleintRepository repository)//kullanıcıya ait olan repository sınıfını alır ve bu sınıfı kullanarak CRUD işlemlerini yapar
		{
			_repository = repository;
		}
		public List<Client> List()//listeleme metodur
		{
			return _repository.GetAll();//repository üzerinden tüm clientları getirir
		}

		public void Create(string name, string email)
		{
			Client client = new Client
			{
				Name = name,
				Email = email,
				CreatedAt = DateTime.Now,
			};
			_repository.Add(client);//repository üzerinden yeni bir client ekler
		}

		public void Create(CreateCustomerModel model)
		{

			Client client = new Client
			{
				Name = model.Name,
				Email = model.Email,
				Phone = model.Phone,
				Locked = model.Locked,
				Description = model.Description,
				CreatedAt = DateTime.Now,
			};
			_repository.Add(client);//repository üzerinden yeni bir client ekler ve bu client bilgileri modelden gelir
		}
	}
}
