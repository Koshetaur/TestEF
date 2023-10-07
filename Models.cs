using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestEF
{

    public class Manager
    {
        public int ID { get; set; }
        public string? Name { get; set; }
    }

    public class Customer
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public int? ManagerID { get; set; }
        [ForeignKey("ManagerID")]
        public virtual Manager? Manager { get; set; }
    }

    public class Order
    {
        public int ID { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Amount { get; set; }
        public int? CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer? Customer { get; set; }
    }
}
