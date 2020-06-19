using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facturi
{
    public partial class FormTranzactii : Form
    {
        private const string DateFormat = "yyyy-MM-dd";
        private FacturiContext context;

        private List<Tranzactie> ListaTranzactii;
        private TemplateExportBanci templateBanci = new TemplateExportBanci(); 
        private Dictionary<string, int> indexiListBox = new Dictionary<string, int>();
         
        public FormTranzactii()
        {
            InitializeComponent();

            comboBox1.SelectedIndex = 0;
            PopuleazaLista();

            List<string> ListaBanci = context.Banci.Select(x => x.Nume).ToList(); 
            foreach (var x in ListaBanci) 
                comboBox1.Items.Add(x); 

            indexiListBox["Nume Platitor"] = 0;
            indexiListBox["Nume Beneficiar"] = 1;
            indexiListBox["IBAN Platitor"] = 2;
            indexiListBox["IBAN Beneficiar"] = 3;
            indexiListBox["Valoare"] = 4;
            indexiListBox["Moneda"] = 5;
            indexiListBox["Data"] = 6;

        }

        private void PopuleazaLista()
        {
            listView1.Items.Clear();
            this.listView1.CheckBoxes = false;

            context = new FacturiContext();

            ListaTranzactii = context.Tranzactii
                .Include(x => x.ContClient.Companie)
                .Include(x => x.ContFurnizor.Companie)
                .Include(x => x.ContClient.Banca)
                .Include(x => x.ContClient)
                .Include(x => x.ContFurnizor)
                .ToList();

            foreach (var x in ListaTranzactii) {
                ListViewItem Lvi = new ListViewItem(x.Id.ToString());
                Lvi.SubItems.Add(x.ContClient.Companie.Nume);
                Lvi.SubItems.Add(x.ContFurnizor.Companie.Nume);
                Lvi.SubItems.Add(x.ContClient.IBAN);
                Lvi.SubItems.Add(x.ContFurnizor.IBAN);
                Lvi.SubItems.Add(x.ValoareTotala.ToString("N2"));
                Lvi.SubItems.Add(x.Moneda);
                Lvi.SubItems.Add(x.Data.ToString("dd/MM/yyyy")); 
                Lvi.SubItems.Add(x.ContClient.Banca.Nume);

                this.listView1.Items.Add(Lvi);
            }

            /*context.Dispose();*/
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listBox1.SelectedItems.Clear();
            if (comboBox1.Text == "Toate") {
                PopuleazaLista();

                this.listBox1.Enabled = false;
                this.button1.Enabled = false; 
                this.button2.Enabled = false;
            } else { 
                this.listView1.CheckBoxes = true;

                foreach (var x in ListaTranzactii) {
                    if (x.ContClient.Banca.Nume == comboBox1.Text) {
                        ListViewItem Lvi = new ListViewItem(x.Id.ToString());
                        Lvi.SubItems.Add(x.ContClient.Companie.Nume);
                        Lvi.SubItems.Add(x.ContFurnizor.Companie.Nume);
                        Lvi.SubItems.Add(x.ContClient.IBAN);
                        Lvi.SubItems.Add(x.ContFurnizor.IBAN);
                        Lvi.SubItems.Add(x.ValoareTotala.ToString("N2"));
                        Lvi.SubItems.Add(x.Moneda);
                        Lvi.SubItems.Add(x.Data.ToString(DateFormat));

                        Lvi.SubItems.Add(x.ContClient.Banca.Nume); 
                         
                        Lvi.Checked = true;
                        this.listView1.Items.Add(Lvi);

                    }
                }

                this.listBox1.Enabled = true;
                this.button1.Enabled = true; 
                this.button2.Enabled = true;

            }

            using (FacturiContext context = new FacturiContext()) {
                try {
                    templateBanci = context.TemplateExportBanci.Where(x => x.NumeBanca.Equals(comboBox1.Text)).First();
                } catch { 
                    templateBanci = null; 
                }
                 
                if (templateBanci != null) 
                    foreach (var x in templateBanci.Template.Split(',')) 
                        listBox1.SelectedIndex = indexiListBox[x];  
            }

        }

        private void button1_Click(object sender, EventArgs e) { 
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = "C:";
            dialog.DefaultExt = ".csv";
            dialog.AddExtension = true;
            dialog.FileName = $@"{comboBox1.Text}{DateTime.Today.Day}-{DateTime.Today.Month}-{DateTime.Today.Year}";
            dialog.Filter = "CSV files (*.csv)|*.csv|All files(*.*)|*.*";
            if (dialog.ShowDialog() != DialogResult.OK) 
                return; 

            List<string> ListaTranz = new List<string>();

            List<string> header = new List<string>(); 
            foreach (int y in listBox1.SelectedIndices) 
                header.Add(listView1.Columns[y + 1].Text);
             
            ListaTranz.Add(string.Join(",", header)); 
            foreach (ListViewItem x in listView1.Items) {

                if (x.Checked == true && x.SubItems[8].Text == comboBox1.Text) {
                    List<string> ListaTemp = new List<string>();
                    foreach (int y in listBox1.SelectedIndices)
                        ListaTemp.Add(x.SubItems[y + 1].Text.Replace(',','.'));

                    ListaTranz.Add(string.Join(",", ListaTemp));
                }
            } 

            exportaTranzCsv(dialog.FileName, ListaTranz); 
        } 
        public static void exportaTranzCsv(string filepath, List<string> listaTranz)  {
            try {
                using (StreamWriter file = new StreamWriter(filepath, false)) 
                    foreach (var x in listaTranz) 
                        file.WriteLine(x); 
                     
                MessageBox.Show("S-a salvat cu succes!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            } catch (Exception e) {
                MessageBox.Show(e.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            if (listBox1.SelectedIndices == null) {
                MessageBox.Show("Nu ati selectat niciun element!", "Atentie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                
            using (FacturiContext context = new FacturiContext()) {
                DialogResult result = MessageBox.Show("Sunteti sigur ca doriti salvarea template-ului in baza de date?", "Template", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK) {
                    TemplateExportBanci temp = new TemplateExportBanci();
                    List<string> elementeSelectate = new List<string>();
                    foreach (int x in listBox1.SelectedIndices) 
                        elementeSelectate.Add(listBox1.Items[x].ToString()); 

                    temp.Template = string.Join(",", elementeSelectate);

                    if (templateBanci == null) 
                        templateBanci = new TemplateExportBanci();
                    
                    templateBanci.Template = temp.Template;
                    templateBanci.NumeBanca = comboBox1.Text;

                    if (context.TemplateExportBanci.Any(x => x.NumeBanca == comboBox1.Text))
                        context.Entry<TemplateExportBanci>(templateBanci).State = System.Data.Entity.EntityState.Modified;
                    else context.Entry<TemplateExportBanci>(templateBanci).State = System.Data.Entity.EntityState.Added;

                    context.SaveChanges();

                } 
            } 
        }


    }
}
