using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturi {
    [Table("TemplateExportBanci")]
    public class TemplateExportBanci {
        public int Id { get; set; }
        public string NumeBanca { get; set; }
        public string Template { get; set; }
    }
}
