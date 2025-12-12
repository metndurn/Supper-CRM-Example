using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupperCRMExample.Models;
using SupperCRMExample.Services;

namespace SupperCRMExample.WepApp.Controllers
{
	public class CustomersController : Controller
	{
		private readonly IClientService _clientService;//IClientService arayüzünden bir clientService nesnesi tanımlıyoruz, bu sayede ClientService sınıfının metotlarını kullanabileceğiz.

		public CustomersController(IClientService clientService)//kullanıcıya ait olan service sınıfını alır ve bu sınıfı kullanarak CRUD işlemlerini yapar
		{
			_clientService = clientService;
		}


		// GET: CustomersController
		public ActionResult Index()//indexte listeleme yapılacak
		{
			var clients = _clientService.List();
			return View(clients);
		}

		// GET: CustomersController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: CustomersController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: CustomersController/Create
		[HttpPost]
		//[ValidateAntiForgeryToken]
		public ActionResult Create(CreateCustomerModel model)//müşteri oluşturma metodu, CreateCustomerModel'den model alır
		{
			if (ModelState.IsValid)
			{
				_clientService.Create(model);
				return Json(new { ok = true });
				//return RedirectToAction(nameof(Index));
			}
			return Json(new { ok = false });
			//return View(model);
		}

		// GET: CustomersController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: CustomersController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: CustomersController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: CustomersController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
