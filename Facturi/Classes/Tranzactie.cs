using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Facturi
{
    [Table("Tranzactii")]
    public class Tranzactie { 
        public int Id { get; set; }
        public double ValoareFactura { get; set; } // valoarea din factura care a fost achitata
        public double ValoareTotala { get; set; } // cu tot cu costuri
        public string Moneda { get; set; }

        public DateTime Data { get; set; }
        public bool isProcesata { get; set; }
        public string TipOperatiune { get; set; }

        [Required]
        public Factura Factura { get; set; }
        public int FacturaId { get; set; }

        public Cont ContFurnizor { get; set; }
        public int? ContFurnizorId { get; set; }

        public Cont ContClient { get; set; }
        public int? ContClientId { get; set; }


        public List<Cost> Costuri { get; set; }

        public double? TotalCost { get { return Costuri.Sum(x => x.Valoare); } }
        public void AdaugaCost(Operatiune op) {
            if (Costuri == null) Costuri = new List<Cost>();

            if (op.isFix) {
                Costuri.Add(new Cost {
                    Denumire = op.Denumire + " (Cost Fix)",
                    Valoare = op.CostFix ?? 0,
                    Moneda = this.Moneda
                });
            }
            if (op.isPercentage) {
                var valCost = (op.PercentageValue ?? 0) * (this.ValoareFactura);

                Costuri.Add(new Cost {
                    Denumire = op.Denumire,
                    Valoare = valCost > (op.CostMinim??0) ? valCost : op.CostMinim??0,
                    Moneda = this.Moneda
                });
            }
        }


    }
}
