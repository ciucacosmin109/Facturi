using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Facturi
{
    [Table("Operatiuni")]
    public class Operatiune
    {
        public int Id { get; set; }

        public string Denumire { get; set; }

        public bool isFix { get; set; }
        public double? CostFix { get; set; }
         
        public double? CostMinim { get; set; }// daca valoarea tranz e mai mica => folosim CostMinim pt PercentageValue
        public bool isPercentage { get; set; }
        public double? PercentageValue { get; set; }

        public List<Cont> ListaConturi { get; set; }

        public double CostCalculat(double valoare) {
            double percentCost = (this.PercentageValue ?? 0) * (valoare);
            double costOp = (this.CostFix ?? 0) + (percentCost > (this.CostMinim ?? 0) ? percentCost : this.CostMinim ?? 0);
            //double costOp = (op.CostFix ?? 0) + (op.PercentageValue ?? 0) * ((op.CostMinim ?? 0) > valDePlata ? (op.CostMinim ?? 0) : valDePlata);

            return costOp;
        }
    }
}
