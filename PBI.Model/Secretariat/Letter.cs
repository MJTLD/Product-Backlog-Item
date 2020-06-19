using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PBI.Model.Secretariat
{
    public class Letter
    {
        [Key]
        public int LetterId { get; set; }
        public string LetterNum { get; set; }
        public DateTime LetterDate { get; set; }
        public string Subject { get; set; }
        public string Receptor { get; set; }
        public string LetterText { get; set; }
        public bool IsPrint { get; set; }
    }
}