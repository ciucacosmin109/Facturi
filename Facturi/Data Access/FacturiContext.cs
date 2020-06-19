using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturi
{
    public class FacturiContext : DbContext
    {
        public FacturiContext() : base("BD_Facturi")//@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Facturi; Integrated Security = true")
        {

        }
        public DbSet<Banca> Banci { get; set; }
        public DbSet<Companie> Companii { get; set; }
        public DbSet<Cont> Conturi { get; set; }
        public DbSet<Cost> Costuri { get; set; }
        public DbSet<Factura> Facturi { get; set; }
        public DbSet<Operatiune> Operatiuni { get; set; }
        //public DbSet<OperatiuniConturi> OperatiuniConturi { get; set; }
        public DbSet<Tranzactie> Tranzactii { get; set; }

        public DbSet<TemplateExportBanci> TemplateExportBanci { get; set; }
    }
}
