using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Facturi
{
    [Table("Companii")]
    public class Companie
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Email { get; set; }

        // camp prioritate (1-6) !!
        public int? Prioritate { get; set; }

        public List<Cont> ListaConturi { get; set; }
        public List<Factura> ListaFacturi { get; set; }
    }
} 

