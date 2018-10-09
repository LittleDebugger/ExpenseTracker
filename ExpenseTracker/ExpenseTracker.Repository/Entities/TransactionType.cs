using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Repository.Entities
{
    public class TransactionType
    {
        [Key]
        public short Id { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }
    }
}
