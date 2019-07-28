using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
	public class Department
	{
		public int Id { get; set; }
		public string Name { get; set; }
		//Cada departamento tem uma List de vendedores
		public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

		//Construtor sem argumentos é necessário quando há outro construtor com argumentos;
		public Department()
		{
		}

		public Department(int id, string name)
		{
			Id = id;
			Name = name;
		}

		public void AddSeller(Seller seller)
		{
			Sellers.Add(seller);
		}

		public double TotalSales (DateTime initial, DateTime final)
		{
			//Para cada vendedor da lista, chama o TotalSales do vendedor no período e soma o total de todos vendedores do departamento
			return Sellers.Sum(seller => seller.TotalSales(initial, final));
		}
	}
}
