using DAL.Enums;

namespace DAL.Entities
{
    public class Transaction : BaseEntity
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime Date { get; set; }
    }
}
