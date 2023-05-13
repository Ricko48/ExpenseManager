using DAL.Enums;

namespace BL.Models
{
    public class TransactionFilterModel
    {
        public decimal? AmountFrom { get; set; }
        public decimal? AmountTo { get; set; }
        public TransactionType? TransactionType { get; set; }
        public DateTime? FromDateTime { get; set; }
        public DateTime? ToDateTime { get; set;}
    }
}
