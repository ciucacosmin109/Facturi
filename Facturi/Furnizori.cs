using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facturi {
    public partial class Furnizori : Form {
        private List<Companie> furnizori;

        public Furnizori(List<Companie> furnizori) {
            InitializeComponent();
            this.furnizori = furnizori;

            foreach(Companie fz in furnizori) {
                ListViewItem lvi = new ListViewItem(fz.Nume);
                lvi.SubItems.Add(fz.Email);
                lvi.SubItems.Add(fz.Prioritate.ToString());
                //lvi.SubItems.Add(fz.Id.ToString());
                furnizoriLV.Items.Add(lvi);
            }
        }

        private void addButton_Click(object sender, EventArgs e) {

        }
    }
}
