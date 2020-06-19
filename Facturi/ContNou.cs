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
    public partial class ContNou : Form {
        private List<Cont> conturi;
        private List<Banca> banci;

        public ContNou(List<Cont> cnt, List<Banca> bnc) {
            InitializeComponent();

            conturi = cnt;
            banci = bnc;

            foreach (Banca b in banci) {
                info_banca.Items.Add(b.Nume);
                foreach (Cont c in b.Conturi)
                    if (c.Moneda != null && !info_moneda.Items.Contains(c.Moneda))
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
            if (info_sold.Value == 0) { 
                statusLabel.Text = "Introduceti un sold !";
                return;
            }
            if (info_costProcentual.Value == 0)
                info_isPercent.Checked = false;
            if (info_costFix.Value == 0)
                info_isFix.Checked = false;

            Cont cnt = new Cont {
                BancaId = banci.First(b => b.Nume == info_banca.Text).Id,
                IBAN = info_iban.Text,
                Moneda = info_moneda.Text,
                DataDeschideriiContului = DateTime.Now,
                DataSold = DateTime.Now,
                Sold = Convert.ToDouble(info_sold.Value),
                SoldInitial = Convert.ToDouble(info_sold.Value),

                ListaOperatiuni = new List<Operatiune> {
                    new Operatiune {
                        Denumire = MeniuPrincipal.DENUMIRE_OP_PLATA_FACTURA,
                        isFix = info_isFix.Checked,
                        isPercentage = info_isPercent.Checked
                    }                
                }
            };
            if (info_isFix.Checked)
                cnt.ListaOperatiuni[0].CostFix = (double)info_costFix.Value;
            if (info_isPercent.Checked)
                cnt.ListaOperatiuni[0].PercentageValue = (double)info_costProcentual.Value/100;
             
            conturi.Add(cnt); 
            DialogResult = DialogResult.OK;
        }
    }
}
