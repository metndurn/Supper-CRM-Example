using Microsoft.EntityFrameworkCore;
using SupperCRMExample.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupperCRMExample.DataAccess.Context
{
	public class DatabaseContext : DbContext //veritabanı baglantı yolumuzu verıyoruz
	{
		/*sag tık yapıp bu alanı olusturuyoruz yani daha kısa ve optionslar ile beraber gelmiş oldu
		 config ayarlarınıda manuel olarak yazmayacagız hepsı otomatık olacak startup tarafından olacak*/
		public DatabaseContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Client> Clients { get; set; } //Client tablosu için DbSet tanımlıyoruz



	}
}
