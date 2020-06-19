using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Facturi
{
    [Table("Banci")]
    public class Banca
    {
        public int Id { get; set; }
        public string Nume { get; set; }

        public List<Cont> Conturi { get; set; }
    }
}
