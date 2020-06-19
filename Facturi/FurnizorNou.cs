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
    public partial class FurnizorNou : Form {
        private List<Companie> furnizori;
        private Companie fzNou;

        private List<Banca> banci;

        public FurnizorNou(List<Companie> fz, List<Banca> bnc) {
            InitializeComponent();
            info_prioritate.SelectedIndex = info_prioritate.Items.Count - 1;

            furnizori = fz;
            fzNou = new Companie { ListaConturi = new List<Cont>() };

            banci = bnc;
        }


        private void cancelButton_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
        private void addButton_Click(object sender, EventArgs e) {
            if (info_prioritate.SelectedIndex == -1) {
                statusLabel.Text = "Selectati o prioritate !";
                return;
            }
            if (info_nume.Text.Length == 0) {
                statusLabel.Text = "Introduceti un nume !";
                return;
            }
            if (info_email.Text.Length == 0) {
                statusLabel.Text = "Introduceti un email !";
                return;
            }
            if(info_conturiLV.Items.Count == 0 || fzNou.ListaConturi.Count == 0) {
                statusLabel.Text = "Introduceti minim un cont - click  !";
                return;
            }

            fzNou.Nume = info_nume.Text;
            fzNou.Email = info_email.Text;
            fzNou.Prioritate = Convert.ToInt32(info_prioritate.Text.Substring(0, 1));

            furnizori.Add(fzNou);

            this.DialogResult = DialogResult.OK;
        }

        private void adaugaUnContToolStripMenuItem_Click(object sender, EventArgs e) {
            using (Form frm = new ContFzNou(fzNou.ListaConturi, banci)) {
                if (frm.ShowDialog() == DialogResult.OK) {
                    Cont c = fzNou.ListaConturi.Last();

                    ListViewItem lvi = new ListViewItem(new string[]{
                        c.IBAN,
                        c.Moneda,
                        c.Banca.Nume
                    });
                    info_conturiLV.Items.Add(lvi);

                }

            }
        } 
        private void stergeToolStripMenuItem_Click(object sender, EventArgs e) {
            if (info_conturiLV.SelectedIndices.Count == 0) return;
            if (fzNou.ListaConturi.Count == 0) {
                info_conturiLV.Items.Clear();
                return;
            }

            int index = info_conturiLV.SelectedIndices[0];
            info_conturiLV.Items.RemoveAt(index);
            fzNou.ListaConturi.RemoveAt(index); 
        }
    }
}
