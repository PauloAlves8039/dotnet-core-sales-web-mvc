using SalesWebMvc.Models.Enums;
using System;

namespace SalesWebMvc.Models
{
    /// <summary>
    /// Classe responsável pelas propriedades dos registros de vendas.
    /// </summary>
    public class SalesRecord
    {
        public int Id { get; set; }
        public DateTime Date  { get; set; }
        public double Amount { get; set; }
        public SalesStatus Status { get; set; }
        public Seller Seller { get; set; }

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
