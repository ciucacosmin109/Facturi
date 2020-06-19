using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Facturi
{
    [Table("Conturi")]
    public class Cont: ICloneable
    {
        public int Id { get; set; }
        public string IBAN { get; set; }
        public string Moneda { get; set; }

        public double? SoldInitial { get; set; }
        public DateTime? DataDeschideriiContului { get; set; }

        public double? Sold { get; set; }
        public DateTime? DataSold { get; set; }
         

        public Banca Banca { get; set; }
        public int BancaId { get; set; }

        public Companie Companie { get; set; }
        public int CompanieId { get; set; }

        public List<Operatiune> ListaOperatiuni { get; set; }

        [ForeignKey("ContClientId")]
        public List<Tranzactie> ListaTranzactii_Client { get; set; }
        [ForeignKey("ContFurnizorId")]
        public List<Tranzactie> ListaTranzactii_Furnizor { get; set; }


        public object Clone() => this.MemberwiseClone();//new Cont { Id=Id,IBAN=IBAN,Sold=Sold,Moneda=Moneda,Banca=Banca,BancaId=BancaId,Companie=Companie,CompanieId=CompanieId,ListaOperatiuni=ListaOperatiuni };  
    }
}
