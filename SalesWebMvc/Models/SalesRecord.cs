using SalesWebMvc.Models.Enums;
using System;

namespace SalesWebMvc.Models
{
	public class SalesRecord
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public double Amount { get; set; }
		public SalesStatus Status { get; set; }
		//Cada vendedor tem um SalesRecord
		public Seller Seller { get; set; }

		//Construtor sem argumentos é necessário quando há outro construtor com argumentos;
		public SalesRecord()
		{
		}

		public SalesRecord(int id, DateTime date, double amount, SalesStatus status, Seller seller)
		{
			Id = id;
			Date = date;
			Amount = amount;
			Status = status;
			Seller = seller;
		}
	}
}
