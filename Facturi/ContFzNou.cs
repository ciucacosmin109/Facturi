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
    public partial class ContFzNou : Form {
        private List<Cont> conturi;
        private List<Banca> banci;

        public ContFzNou(List<Cont> cnt, List<Banca> bnc) {
            InitializeComponent();

            conturi = cnt;
            banci = bnc;

            foreach (Banca b in banci) {
                info_banca.Items.Add(b.Nume);
                foreach(Cont c in b.Conturi)
                    if(c.Moneda != null && !info_moneda.Items.Contains(c.Moneda))
                        info_moneda.Items.Add(c.Moneda);
            } 
        }

        private void cancelButton_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
        private void addButton_Click(object sender, EventArgs e) {
            if (info_banca.SelectedIndex == -1) {
                statusLabel.Text = "Selectati o banca valida !";
                return;
            }
            if (info_iban.Text.Length != 24) {
                statusLabel.Text = "Introduceti un IBAN valid !";
                return;
            }
            if (info_moneda.Text.Length == 0) {
                statusLabel.Text = "Introduceti o moneda valida !";
                return;
            }

            Cont cnt = new Cont {
                Banca = banci.First(b => b.Nume == info_banca.Text),
                IBAN = info_iban.Text,
                Moneda = info_moneda.Text
            };
            if (info_sold.Value != 0)
                cnt.Sold = Convert.ToDouble(info_sold.Value);

            conturi.Add(cnt);

            DialogResult = DialogResult.OK;
        }

    }
}
