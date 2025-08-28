namespace SupperCRMExample.Models
{
	public class CreateCustomerModel //müşteri oluşturmak için gerekli olan model
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Description { get; set; }
		public bool Locked { get; set; }
	}
}
