using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using LINQtoCSV;

namespace Facturi
{
    [Table("Facturi")]
    public class Factura
    { 
        public int Id { get; set; }
        public double Valoare { get; set; }  
        public string Moneda { get; set; }
        public DateTime DataEmitere { get; set; }
        public DateTime DataScadenta { get; set; }

        //-------------------------------------------------

        public Companie Furnizor { get; set; }
        public int? FurnizorId { get; set; }
        
        public Companie Client { get; set; }
        public int? ClientId { get; set; }
        
        public List<Tranzactie> ListaTranzactii { get; set; }  
    }
}
