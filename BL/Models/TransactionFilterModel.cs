namespace BL.Models
{
    public class TransactionFilterModel
    {
        public decimal AmountFrom { get; set; } = 0;
        public decimal AmountTo { get; set; } = 0;
        public DateTime FromDateTime { get; set; } = DateTime.Now;
        public DateTime ToDateTime { get; set; } = DateTime.Now;
    }
}
