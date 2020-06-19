using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Facturi
{ 
    [Table("Costuri")]
    public class Cost
    {
        public int Id { get; set; }
        public string Denumire { get; set; }

        public double Valoare { get; set; }
        public string Moneda { get; set; }
         
        public Tranzactie Tranzactie { get; set; }
        public int TranzactieId { get; set; }
    }
}
