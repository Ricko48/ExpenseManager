using BL.Enums;

namespace BL.Models
{
    public class TransactionFilterModel
    {
        public decimal? AmountFrom { get; set; }
        public decimal? AmountTo { get; set; }
        public TransactionType? TransactionType { get; set; }
    }
}
