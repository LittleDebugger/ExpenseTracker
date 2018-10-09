using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Repository.Entities
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        public DateTime TransactionDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [ForeignKey("Currency")]
        public short CurrencyId { get; set; }
        public Currency Currency { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string Recipient { get; set; }

        [ForeignKey("TransactionType")]
        public short TransactionTypeId { get; set; }
        public TransactionType TransactionType { get;set;}

        public override string ToString()
        {
            return $"{{ Id: {Id}, TrasactionDate: {TransactionDate}, Amount:{Amount}, CurrencyId: {CurrencyId}, Recipient: {Recipient}, TransactionTypeId: {TransactionTypeId} }}";
        }
    }
}
