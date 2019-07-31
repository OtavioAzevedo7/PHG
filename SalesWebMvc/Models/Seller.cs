using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc.Models
{
	public class Seller
	{
		public int Id { get; set; }
		public string Name { get; set; }
		[EmailAddress]
		public string Email { get; set; }
		//Exibe/formata o nome desejado nas views chamadas pelo tag helper
		[Display(Name = "Birth Date")]
		//Exibe/formata os inputs nas views
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
		public DateTime BirthDate { get; set; }
		[Display(Name = "Base Salary")]
		//Formata para 2 casas decimais
		[DisplayFormat(DataFormatString ="{0:F2}")]
		public double BaseSalary { get; set; }
		//Cada vendedor tem um Department
		public Department Department { get; set; }
		//Para tornar este atributo not null
		public int DepartmentId { get; set; }
		//Cada vendedor tem uma lista de SalesRecord
		public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

		//Construtor sem argumentos é necessário quando há outro construtor com argumentos;
		public Seller()
		{
		}

		public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
		{
			Id = id;
			Name = name;
			Email = email;
			BirthDate = birthDate;
			BaseSalary = baseSalary;
			Department = department;
		}

		public void AddSales(SalesRecord sr)
		{
			Sales.Add(sr);
		}

		public void RemoveSales(SalesRecord sr)
		{
			Sales.Remove(sr);
		}

		public double TotalSales(DateTime initial, DateTime final)
		{
			return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
		}
	}
}
