using MoneyTransfer.CustomValidationAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneyTransfer.Models
{
    public class Transfer
    {
        [Key]
        public int TransferId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Token")]
        public int TokenId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "CNP EXPEDITOR")]
        [ValidationCNP]
        public string CNP { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "IBAN DESTINATAR")]
        [ValidationIBAN]
        public string IBAN { get; set; }

        [Required]
        [Display(Name = "SUMA DE BANI")]
        [BiggerThanOne]
        public decimal Amount { get; set; }

        [Display(Name = "VALUTA DESTINATAR")]
        public string DestinationCurrency { get; set; }

        [Display(Name = "VALUTA EXPEDITOR")]
        public string Currency { get; set; }

        [Editable(false)]
        [Display(Name = "SUMA DE BANI PRIMITA DE DESTINATAR")]
        public decimal DestinationAmount { get; set; }

        [Required]
        [Display(Name = "Am peste 18 ani impliniti!")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Trebuie sa ai peste 18 ani!")]
        public bool isAdult { get; set; }

        [Required]
        [Display(Name = "Confirm consimtamantul pentru prelucrarea datelor cu caracter personal!")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Trebuie sa confirmi! In lipsa acestuia, transferul nu poate avea loc!")]
        public bool isApproved { get; set; }

        public List<SelectListItem> Currencies { get; set; }
    }
}