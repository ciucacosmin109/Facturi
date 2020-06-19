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
    public partial class FacturaNoua : Form {
        private const string NUME_COMPANIE = "Practica 2020 S.R.L.";

        private List<Factura> facturi;
        private List<Companie> furnizori;

        public FacturaNoua(List<Factura> facturi, List<Companie> furnizori) {
            InitializeComponent();
            this.facturi = facturi;
            this.furnizori = furnizori;

            if (facturi.Count > 0) {
                info_moneda.Items.AddRange(facturi.Select(f => f.Moneda).Distinct().ToArray());
                info_furnizor.Items.AddRange(furnizori.Select(f => f.Nume).Distinct().ToArray());
            }
            statusLabel.Text = "Introduceti datele facturii";
            info_dataE.Value = DateTime.Now;
        }

        private void cancelButton_Click(object sender, EventArgs e) => this.DialogResult = DialogResult.Cancel; 
        private void addButton_Click(object sender, EventArgs e) {
            if (info_furnizor.SelectedIndex == -1) {
                statusLabel.Text = "Selectati furnizorul !";
                return;
            }
            if (info_moneda.Text.Length == 0) {
                statusLabel.Text = "Introduceti o moneda !";
                return;
            }
            if(info_valoare.Value == 0) {
                statusLabel.Text = "Introduceti o valoare !";
                return;
            }

            facturi.Add(new Factura {
                DataEmitere = info_dataE.Value, DataScadenta = info_dataS.Value,
                Furnizor = furnizori[info_furnizor.SelectedIndex],
                Moneda= info_moneda.Text,
                Valoare= Convert.ToDouble(info_valoare.Value)
            }) ;

            this.DialogResult = DialogResult.OK;
        }
         

        private void info_data_ValueChanged(object sender, EventArgs e) {
            info_dataS.MinDate = info_dataE.Value;
        } 
        private void info_moneda_KeyUp(object sender, KeyEventArgs e) { 
            ComboBox cb = ((ComboBox)sender);
            int caretPosition = cb.SelectionStart;

            cb.Text = cb.Text.ToUpper();
            cb.SelectionStart = caretPosition++;
        }

    }
}
