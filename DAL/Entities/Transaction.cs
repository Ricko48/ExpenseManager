namespace DAL.Entities
{
    public class Transaction : BaseEntity
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int TransactionTypeId { get; set; }
        public virtual TransactionType TransactionType { get; set; }
    }
}
