using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace Facturi
{
    public partial class MeniuPrincipal : Form {
        public const string NUME_COMPANIE = "Practica 2020 S.R.L.";
        public const string DENUMIRE_OP_PLATA_FACTURA = "Plata Factura";
        
        private readonly Color FILTER_ACTIVE_COLOR = Color.Green;
        private readonly Color FILTER_INACTIVE_COLOR = Color.Black;

        // Date (conturi, facturiDePlata)
        private List<Cont> conturi;
        private ListView.ListViewItemCollection conturiItemsLV;
        private List<Factura> facturiDePlata;
        private ListView.ListViewItemCollection facturiItemsLV;

        private List<Factura> facturi;
        private List<Companie> furnizori;

        private List<Banca> banci;

        // Context baza de date
        private FacturiContext fc;

        // Filtre
        private Filters.ListFilterWindow listFilter;
        private Filters.RangeFilterWindow rangeFilter;
        private Filters.DateFilterWindow dateFilter;

        // Filtre conturi
        private int[] filtruSold;
        private List<string> filtruMonedaC;
        private List<string> filtruBanca;

        // Filtre facturiDePlata
        private List<string> filtruFurnizor;
        private List<string> filtruPrioritate;
        private int[] filtruSumaTotala;
        private int[] filtruSumaDePlata;
        private List<string> filtruMonedaF;
        private DateTime[] filtruDataE;
        private DateTime[] filtruDataS;
         
        //======================================================================================
        public MeniuPrincipal() {
            InitializeComponent();
            listFilter = new Filters.ListFilterWindow();
            rangeFilter = new Filters.RangeFilterWindow();
            dateFilter = new Filters.DateFilterWindow();
            refreshData();

        } 
        private void refreshData() {
            ordonareFacturiCB.SelectedIndex = 0;
            conturiLV.Items.Clear();
            facturiLV.Items.Clear();
            resetareFiltreC();
            resetareFiltreF();

            fc = new FacturiContext();

            conturi =
                fc.Conturi
                .Include(c => c.Banca)
                .Include(c => c.Companie)
                .Include(c => c.ListaOperatiuni)
                .Include(c => c.ListaTranzactii_Client)
                .Include(c => c.ListaTranzactii_Furnizor)
                .Where(c => c.Companie.Nume == NUME_COMPANIE)
                .ToList();
            banci =
                fc.Banci
                .Include(b => b.Conturi) 
                .ToList();
            facturi =
                fc.Facturi
                .Include(fa => fa.Furnizor)
                .Include(fa => fa.Furnizor.ListaConturi)
                .Where(fa => fa.Client.Nume == NUME_COMPANIE)
                .ToList();
            facturiDePlata = 
                facturi
                .Where(fa => fa.ListaTranzactii == null || 
                             fa.ListaTranzactii.Count == 0 || 
                             fa.ListaTranzactii.Sum(t=>t.ValoareFactura) < fa.Valoare)
                .ToList();
            furnizori =
                fc.Companii
                .Include(c => c.ListaConturi)
                .Where(c => c.Nume != NUME_COMPANIE)
                .ToList();

            foreach (var cont in conturi) {
                ListViewItem lvi = new ListViewItem(cont.IBAN);
                    lvi.SubItems.Add(cont.Sold?.ToString("N2"));
                    lvi.SubItems.Add(cont.DataSold?.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(cont.Moneda);
                lvi.SubItems.Add(cont.Banca.Nume);
                lvi.SubItems.Add(cont.Id.ToString());
                lvi.Checked = true;
                this.conturiLV.Items.Add(lvi);
            }
            foreach (var f in facturiDePlata) {
                ListViewItem lvi = new ListViewItem(f.Furnizor.Nume);
                lvi.SubItems.Add(f.Furnizor.Prioritate.ToString());

                lvi.SubItems.Add(f.Valoare.ToString("N2")); 

                if(f.ListaTranzactii != null && f.ListaTranzactii.Count != 0)
                   lvi.SubItems.Add((f.Valoare - f.ListaTranzactii.Sum(t => t.ValoareFactura)).ToString("N2"));
                else lvi.SubItems.Add(f.Valoare.ToString("N2"));

                lvi.SubItems.Add(f.Moneda);
                lvi.SubItems.Add(f.DataEmitere.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(f.DataScadenta.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(f.Id.ToString());
                lvi.Checked = true;
                this.facturiLV.Items.Add(lvi);
            }
            fc.Dispose();

            conturiItemsLV = Filters.ListFilterWindow.cloneItems(conturiLV.Items);
            facturiItemsLV = Filters.ListFilterWindow.cloneItems(facturiLV.Items);

            validareFiltreConturi();
            validareFiltreFacturi();
        }
        private void refreshToolStripMenuItem1_Click(object sender, EventArgs e) => refreshData();

        private void nextButton_Click(object sender, EventArgs e) {
            List<Cont> conturiBifate = new List<Cont>();
            List<Factura> facturiBifate = new List<Factura>();

            {/*// Fara filtrare
            for (int i = 0; i < conturi.Count; i++)
                if (conturiLV.Items[i].Checked)
                    conturiBifate.Add(conturi[i]);

            for (int i = 0; i < facturiDePlata.Count; i++)
                if (facturiLV.Items[i].Checked)
                    facturiBifate.Add(facturiDePlata[i]);
            */}
           
            foreach (ListViewItem item in conturiLV.Items) {
                if (item.Checked) {
                    Cont cont = conturi.First(c => c.Id.ToString() == item.SubItems[conturiLV.Columns.Count].Text);
                    if (cont != null) conturiBifate.Add(cont);
                }
            }
            foreach (ListViewItem item in facturiLV.Items) {
                if (item.Checked) {
                    Factura factura = facturiDePlata.First(f => f.Id.ToString() == item.SubItems[facturiLV.Columns.Count].Text);
                    if (factura != null) facturiBifate.Add(factura);
                }
            }

            
            try {
                using (Form frm = new Scenarii(conturiBifate, facturiBifate, ordonareFacturiCB.SelectedIndex)) {
                    if (frm.ShowDialog() == DialogResult.OK)
                        refreshData();
                }
            } catch(FaraScenariiException) { 
                MessageBox.Show(
                    "Nu se poate plati nicio factura din conturile selectate",
                    "Fara Scenarii",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                ); 
            }
            
        }

        // FILTRARE 
        private void resetareFiltreC() {
            filtruSold = null;
            filtruMonedaC = null;
            filtruBanca = null;
        }
        private void resetareFiltreF() {
            filtruFurnizor=null;
            filtruPrioritate=null;
            filtruSumaTotala = null;
            filtruSumaDePlata = null;
            filtruMonedaF =null;
            filtruDataE=null;
            filtruDataS = null;
        }

        private void repopulareConturi() {
            conturiLV.Items.Clear();
            foreach (ListViewItem itm in conturiItemsLV)
                conturiLV.Items.Add(Filters.ListFilterWindow.cloneItem(itm)).Checked = true;
        }
        private void repopulareFacturi() {
            facturiLV.Items.Clear();
            foreach (ListViewItem itm in facturiItemsLV)
                facturiLV.Items.Add(Filters.ListFilterWindow.cloneItem(itm)).Checked = true;
        }

        private void validareFiltreConturi() { 
            repopulareConturi();
            
            if (filtruSold != null) {
                filtrareSold.ForeColor = FILTER_ACTIVE_COLOR;
                foreach (ListViewItem itm in conturiLV.Items) {
                    double value = Convert.ToDouble(itm.SubItems[1].Text);
                    if (value < filtruSold[0] || value > filtruSold[1])
                        conturiLV.Items.Remove(itm);
                }
            }
            else filtrareSold.ForeColor = FILTER_INACTIVE_COLOR;

            if (filtruMonedaC != null) {
                filtrareMonedaC.ForeColor = FILTER_ACTIVE_COLOR;
                foreach (ListViewItem itm in conturiLV.Items) {
                    if (!filtruMonedaC.Contains(itm.SubItems[3].Text))
                        conturiLV.Items.Remove(itm);
                }
            }
            else filtrareMonedaC.ForeColor = FILTER_INACTIVE_COLOR;

            if (filtruBanca != null) {
                filtrareBanca.ForeColor = FILTER_ACTIVE_COLOR;
                foreach (ListViewItem itm in conturiLV.Items) {
                    if (!filtruBanca.Contains(itm.SubItems[4].Text))
                        conturiLV.Items.Remove(itm);
                }
            }
            else filtrareBanca.ForeColor = FILTER_INACTIVE_COLOR;
        }
        private void validareFiltreFacturi() { 
            repopulareFacturi();
            // ....
            if (filtruFurnizor != null) {
                filtrareFurnizor.ForeColor = FILTER_ACTIVE_COLOR;
                foreach (ListViewItem itm in facturiLV.Items) {
                    if (!filtruFurnizor.Contains(itm.SubItems[0].Text))
                        facturiLV.Items.Remove(itm);
                }
            } 
            else filtrareFurnizor.ForeColor = FILTER_INACTIVE_COLOR;
            
            if (filtruPrioritate != null) {
                filtrarePrioritate.ForeColor = FILTER_ACTIVE_COLOR;
                foreach (ListViewItem itm in facturiLV.Items) {
                    if (!filtruPrioritate.Contains(itm.SubItems[1].Text))
                        facturiLV.Items.Remove(itm);
                }
            }
            else filtrarePrioritate.ForeColor = FILTER_INACTIVE_COLOR;

            if (filtruSumaTotala != null) {
                filtrareSumaTotala.ForeColor = FILTER_ACTIVE_COLOR;
                foreach (ListViewItem itm in facturiLV.Items) {
                    double value = Convert.ToDouble(itm.SubItems[2].Text);
                    if (value < filtruSumaTotala[0] || value > filtruSumaTotala[1])
                        facturiLV.Items.Remove(itm);
                }
            }
            else filtrareSumaTotala.ForeColor = FILTER_INACTIVE_COLOR;

            if (filtruSumaDePlata != null) {
                filtrareSumaDePlata.ForeColor = FILTER_ACTIVE_COLOR;
                foreach (ListViewItem itm in facturiLV.Items) {
                    double value = Convert.ToDouble(itm.SubItems[3].Text);
                    if (value < filtruSumaDePlata[0] || value > filtruSumaDePlata[1])
                        facturiLV.Items.Remove(itm);
                }
            }
            else filtrareSumaDePlata.ForeColor = FILTER_INACTIVE_COLOR;

            if (filtruMonedaF != null) {
                filtrareMonedaF.ForeColor = FILTER_ACTIVE_COLOR;
                foreach (ListViewItem itm in facturiLV.Items) {
                    if (!filtruMonedaF.Contains(itm.SubItems[4].Text))
                        facturiLV.Items.Remove(itm);
                }
            }
            else filtrareMonedaF.ForeColor = FILTER_INACTIVE_COLOR;
            
            if (filtruDataE != null) {
                filtrareDataE.ForeColor = FILTER_ACTIVE_COLOR;
                foreach (ListViewItem itm in facturiLV.Items) {
                    DateTime value = Convert.ToDateTime(itm.SubItems[5].Text);
                    if (value < filtruDataE[0] || value > filtruDataE[1])
                        facturiLV.Items.Remove(itm);
                }
            }
            else filtrareDataE.ForeColor = FILTER_INACTIVE_COLOR;
            
            if (filtruDataS != null) {
                filtrareDataS.ForeColor = FILTER_ACTIVE_COLOR;
                foreach (ListViewItem itm in facturiLV.Items) {
                    DateTime value = Convert.ToDateTime(itm.SubItems[6].Text);
                    if (value < filtruDataS[0] || value > filtruDataS[1])
                        facturiLV.Items.Remove(itm);
                }
            }
            else filtrareDataS.ForeColor = FILTER_INACTIVE_COLOR;
        }

        // FILTRARE CONTURI
        private void filtrareSold_Click(object sender, EventArgs e) { 
            if (rangeFilter.Show(filtruSold) == DialogResult.OK) {
                filtruSold = rangeFilter.Filtru;
                validareFiltreConturi();
            }
        }

        private void filtrareMonedaC_Click(object sender, EventArgs e) { 
            DialogResult res = listFilter.Show(conturiLV.Items, conturiItemsLV, 3);
            if (res == DialogResult.OK) {
                filtruMonedaC = listFilter.Filtru;
                validareFiltreConturi();
            }
        }

        private void filtrareBanca_Click(object sender, EventArgs e) {  
            DialogResult res = listFilter.Show(conturiLV.Items, conturiItemsLV, 4);
            if (res == DialogResult.OK) {
                filtruBanca = listFilter.Filtru;
                validareFiltreConturi();
            }
        }

        private void resetFiltreConturiButton_Click(object sender, EventArgs e) {
            resetareFiltreC();
            validareFiltreConturi();
        }
        
        // FILTRARE FACTURI
        private void filtrareFurnizor_Click(object sender, EventArgs e) { 
            DialogResult res = listFilter.Show(facturiLV.Items, facturiItemsLV, 0);
            if (res == DialogResult.OK) {
                filtruFurnizor = listFilter.Filtru;
                validareFiltreFacturi();
            }
        }

        private void filtrarePrioritate_Click(object sender, EventArgs e) {  
            DialogResult res = listFilter.Show(facturiLV.Items, facturiItemsLV, 1);
            if (res == DialogResult.OK) {
                filtruPrioritate = listFilter.Filtru;
                validareFiltreFacturi();
            }
        }

        private void filtrareSumaTotala_Click(object sender, EventArgs e) { 
            if (rangeFilter.Show(filtruSumaTotala) == DialogResult.OK) {
                filtruSumaTotala = rangeFilter.Filtru;
                validareFiltreFacturi();
            }
        }
        private void filtrareSumaDePlata_Click(object sender, EventArgs e) {
            if (rangeFilter.Show(filtruSumaDePlata) == DialogResult.OK) {
                filtruSumaDePlata = rangeFilter.Filtru;
                validareFiltreFacturi();
            }
        }

        private void filtrareMonedaF_Click(object sender, EventArgs e) {
            DialogResult res = listFilter.Show(facturiLV.Items, facturiItemsLV, 4);
            if (res == DialogResult.OK) {
                filtruMonedaF = listFilter.Filtru;
                validareFiltreFacturi();
            }
        }

        private void filtrareDataE_Click(object sender, EventArgs e) {
            if (dateFilter.Show(filtruDataE) == DialogResult.OK) {
                filtruDataE = dateFilter.Filtru;
                validareFiltreFacturi();
            }
        }

        private void filtrareDataS_Click(object sender, EventArgs e) { 
            if (dateFilter.Show(filtruDataS) == DialogResult.OK) {
                filtruDataS = dateFilter.Filtru;
                validareFiltreFacturi();
            }
        }

        private void resetFiltreFacturiButton_Click(object sender, EventArgs e) {
            resetareFiltreF();
            validareFiltreFacturi();
        }

        //====================================================================================

        private void adaugaFacturaToolStripMenuItem_Click(object sender, EventArgs e) {
            using (Form frm = new FacturaNoua(facturi, furnizori)) {
                if(frm.ShowDialog() == DialogResult.OK) {
                    facturi.Last().Client = conturi[0].Companie;
                    Factura f = facturi.Last();

                    using (FacturiContext fc = new FacturiContext()) {
                        fc.Entry<Companie>(f.Client).State = EntityState.Unchanged;
                        fc.Entry<Companie>(f.Furnizor).State = EntityState.Unchanged;
                        fc.Facturi.Add(f);
                        fc.SaveChanges();
                    }
                    refreshData();

                    /*
                    ListViewItem lvi = new ListViewItem(f.Furnizor.Nume);
                    lvi.SubItems.Add(f.Furnizor.Prioritate.ToString());
                    lvi.SubItems.Add(f.Valoare.ToString("N2"));
                    lvi.SubItems.Add(f.Valoare.ToString("N2"));
                    lvi.SubItems.Add(f.Moneda);
                    lvi.SubItems.Add(f.DataEmitere.ToString("dd/MM/yyyy"));
                    lvi.SubItems.Add(f.DataScadenta.ToString("dd/MM/yyyy"));
                    lvi.SubItems.Add(f.Id.ToString());
                    lvi.Checked = true;
                    this.facturiLV.Items.Add(lvi);*/
                }

            }

        }
        private void vizualizeazaToolStripMenuItem2_Click(object sender, EventArgs e) { 
            using (Form frm = new Furnizori(furnizori)) {
                frm.ShowDialog();

                using (FacturiContext fc = new FacturiContext()) {
                    List<Companie> furnizoriBd =
                        fc.Companii
                        .Include(c => c.ListaConturi)
                        .Where(c => c.Nume != NUME_COMPANIE)
                        .ToList();
                    foreach(Companie fz in furnizori) {
                        if (!furnizoriBd.Select(f => f.Nume).Contains(fz.Nume)) {
                            fc.Companii.Add(fz);
                            fc.SaveChanges();
                        }
                    }

                }
                

            }
        }
        private void adaugaToolStripMenuItem2_Click(object sender, EventArgs e) {
            // adauga furnizor nou
            using (Form frm = new FurnizorNou(furnizori, banci)) {
                if (frm.ShowDialog() == DialogResult.OK) { 
                    Companie fz = furnizori.Last();

                    using (FacturiContext fc = new FacturiContext()) {
                        foreach (Cont c in fz.ListaConturi)
                            fc.Entry<Banca>(c.Banca).State = EntityState.Unchanged; 
                        
                        fc.Entry<Companie>(fz).State = EntityState.Added; 
                        fc.SaveChanges();
                    } 
                }

            }
        }

        private void adaugaContToolStripMenuItem_Click(object sender, EventArgs e) {
            using (Form frm = new ContNou(conturi, banci)) {
                if (frm.ShowDialog() == DialogResult.OK) {
                    Cont c = conturi.Last(); 

                    using (FacturiContext fc = new FacturiContext()) { 
                        c.CompanieId = fc.Companii.First(co => co.Nume == NUME_COMPANIE).Id;


                        //fc.Entry<Companie>(c.Companie).State = EntityState.Unchanged; 
                        //fc.Entry<Banca>(c.Banca).State = EntityState.Modified;
                        //foreach (Cont cn in c.Banca.Conturi)
                        //    fc.Entry<Cont>(cn).State = EntityState.Unchanged;

                        fc.Entry<Cont>(c).State = EntityState.Added;
                        
                        fc.SaveChanges();
                    }

                    /*
                    ListViewItem lvi = new ListViewItem(new string[]{
                        c.IBAN,
                        c.Sold.ToString(),
                        c.DataSold.ToString(),
                        c.Moneda, 
                        banci.First(b=>b.Id == c.BancaId).Nume 
                    });
                    conturiLV.Items.Add(lvi);*/

                    refreshData();

                }

            }
        }

        // Madalina
        #region Import date 
        private void populareLvFacturiDePlata() {
            facturiLV.Items.Clear();
            foreach (var fr in facturiDePlata) {
                ListViewItem lvi = new ListViewItem(fr.Furnizor.Nume);
                lvi.SubItems.Add(fr.Furnizor.Prioritate.ToString());
                lvi.SubItems.Add(fr.Valoare.ToString("N2"));
                lvi.SubItems.Add(fr.Moneda);
                lvi.SubItems.Add(fr.DataEmitere.ToString("dd/MM/yyyy"));
                lvi.SubItems.Add(fr.DataScadenta.ToString("dd/MM/yyyy"));

                this.facturiLV.Items.Add(lvi);
            }
        }
        private void populareListViewConturi() {
            conturiLV.Items.Clear();
            foreach (var cont in conturi) {
                ListViewItem lvi = new ListViewItem(cont.IBAN);
                lvi.SubItems.Add(cont.Sold.ToString());
                lvi.SubItems.Add(cont.DataSold.ToString());
                lvi.SubItems.Add(cont.Moneda);
                lvi.SubItems.Add(cont.Banca.Nume);
                lvi.Checked = true;
                this.conturiLV.Items.Add(lvi);
            }
        }
        private void importaFacturiToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Importa facturi din csv";
            ofd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK) {
                StreamReader sr = new StreamReader(ofd.FileName);
                while (!sr.EndOfStream) {
                    String line = sr.ReadLine();
                    String[] temp = line.Split(',');
                    Factura f = new Factura();
                    f.Furnizor = new Companie();
                    f.Furnizor.Nume = temp[0];
                    int.TryParse(temp[1], out int pr);
                    f.Furnizor.Prioritate = pr;
                    double.TryParse(temp[2], out double sum);
                    f.Valoare = sum;
                    f.Moneda = temp[3];
                    DateTime.TryParse(temp[4], out DateTime emitere);
                    f.DataEmitere = emitere;
                    DateTime.TryParse(temp[5], out DateTime scadenta);
                    f.DataScadenta = scadenta;
                    facturiDePlata.Add(f);

                }
                populareLvFacturiDePlata();
                //repopulareFacturi();
                sr.Close();
                //buttonSave_Click(sender, e);
            }
        }

        private void importaSolduricsvToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Importa conturi din csv";
            ofd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK) {
                StreamReader sr = new StreamReader(ofd.FileName);
                while (!sr.EndOfStream) {
                    String line = sr.ReadLine();
                    String[] temp = line.Split(',');
                    Cont c = new Cont();
                    c.IBAN = temp[0];
                    double.TryParse(temp[1], out double sold);
                    c.Sold = sold;
                    DateTime.TryParse(temp[2], out DateTime dataSold);
                    c.DataSold = dataSold;
                    c.Moneda = temp[3];
                    c.Banca = new Banca();
                    c.Banca.Nume = temp[4];
                    conturi.Add(c);


                }
                populareListViewConturi();
                //repopulareConturi();
                sr.Close();
                //buttonSave_Click(sender, e);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Doriti sa salvati datele importate?", "Salvare date", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes) {  // refreshData();
                using (FacturiContext ctx = new FacturiContext()) {
                    foreach (var co in conturi)
                        if(!ctx.Conturi.Contains(co))
                            ctx.Conturi.Add(co);
                    foreach (var fa in facturiDePlata)
                        if (!ctx.Facturi.Contains(fa))
                            ctx.Facturi.Add(fa);

                    ctx.SaveChanges();
                }
            }

        }
        #endregion

        private void buttonTranz_Click(object sender, EventArgs e) {
            using (FormTranzactii tranz = new FormTranzactii()) {
                tranz.ShowDialog();

            }
        }

        private void adaugaToolStripMenuItem1_Click(object sender, EventArgs e) {

        }
    }
}
