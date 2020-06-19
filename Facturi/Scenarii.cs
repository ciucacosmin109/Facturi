using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.WindowsAPICodePack.Dialogs;


//react + redux js node.js npm 

namespace Facturi {
    public partial class Scenarii : Form {
        private List<Cont> conturiBifate;
        private List<Factura> facturiBifate;
        private int criteriuOrdonareFacturi;

        private List<List<Tranzactie>> scenarii;

        public Scenarii(List<Cont> conturiBifate, List<Factura> facturiBifate, int criteriuOrdF) {
            InitializeComponent();
            this.scenarii = new List<List<Tranzactie>>();
            this.conturiBifate = conturiBifate;
            this.facturiBifate = facturiBifate;
            this.criteriuOrdonareFacturi = criteriuOrdF;

            // Ordoneaza facturile in functie de criteriul ales
            ordoneazaFacturi();

            // Calculeaza toate scenariile
            calculeazaToateScenariile();
        }

        private void ordoneazaFacturi() {
            // Ordoneaza facturile in functie de criteriul ales
            if (criteriuOrdonareFacturi == 0)
                this.facturiBifate = facturiBifate.OrderBy(f => f.Furnizor.Prioritate).ToList();
            else if (criteriuOrdonareFacturi == 1)
                this.facturiBifate = facturiBifate.OrderBy(f => f.DataScadenta).ToList();
            else if (criteriuOrdonareFacturi == 2)
                this.facturiBifate = facturiBifate.OrderByDescending(f => f.Valoare).ToList();
        }

        private void calculeazaToateScenariile() {
            // Calculeaza toate scenariile
            scenariiTabControl.TabPages.Clear();
            centralizatorLV.Items.Clear();
            scenarii.Clear();
            for (int i = 0; i < conturiBifate.Count; i++) {
                List<Tranzactie> scenariu = calculeazaScenariu(i);
                if (scenariu.Count != 0)
                    scenarii.Add(scenariu);
            }
            if (scenarii.Count == 0)
                throw new FaraScenariiException();

            // Ordoneaza scenariile dupa cost
            scenarii = scenarii.OrderBy(s => s.Sum(t => t.TotalCost) ?? 0).ToList();
            // Elimina duplicatele
            for (int i = 0; i < scenarii.Count - 1; i++) {
                if (scenariiEgale(scenarii[i], scenarii[i + 1])) {
                    scenarii.RemoveAt(i + 1);
                    i--;
                }
            }

            // Adauga scenariile in UI 
            scenarii.ForEach(s => adaugaScenariuInTab(s, conturiBifate));


            //Point point = lv.PointToClient(Cursor.Position); 
            toolTip1.SetToolTip(nextButton, "Click me.");
        }

        private List<Tranzactie> calculeazaScenariu(int contStart = 0) {
            // Calculeaza scenariul care incepe platile cu contul care are id 'contStart'

            List<Cont> conturiModificabile = new List<Cont>(conturiBifate.Select(x => (Cont)x.Clone()));

            List<Tranzactie> tranzactii = new List<Tranzactie>();
            foreach (var factura in facturiBifate) {
                bool gasit = false;
                for (int i = contStart; i < conturiModificabile.Count; i++) {
                    if (gasit) break;
                    gasit = adaugaTranzactie(tranzactii, conturiModificabile[i], factura);
                }
                for (int i = 0; i < contStart; i++) {
                    if (gasit) break;
                    gasit = adaugaTranzactie(tranzactii, conturiModificabile[i], factura);
                }
                if (!gasit)
                    adaugaTranzactieNula(tranzactii, factura);

            }
            return tranzactii;
        }
        private static bool adaugaTranzactie(List<Tranzactie> tranzactii, Cont cont, Factura factura) {
            // Adauga tranzactia de plata a facturii 'factura' din contul 'cont' 
            Operatiune op;
            try {
                op = cont.ListaOperatiuni.First(o => o.Denumire == MeniuPrincipal.DENUMIRE_OP_PLATA_FACTURA);
            }
            catch {
                return false;
            }
            // Verifica daca contul suporta DENUMIRE_OP_PLATA_FACTURA
            if (op == null) return false;

            // Scadem tranzactiile partiale care s-au facut
            double valoareDePlata = factura.Valoare;
            if (factura.ListaTranzactii != null && factura.ListaTranzactii.Count != 0)
                valoareDePlata -= factura.ListaTranzactii.Sum(t => t.ValoareFactura);

            // Calc. costul
            double costOp = op.CostCalculat(valoareDePlata);

            // Verifica daca se poate platii
            if (factura.Moneda == cont.Moneda && valoareDePlata + costOp <= cont.Sold) {
                cont.Sold -= valoareDePlata + costOp;
                //cont.DataSold = DateTime.Now; 

                tranzactii.Add(new Tranzactie {
                    Id = factura.Id, // Id e FK
                    ValoareFactura = valoareDePlata,
                    ValoareTotala = valoareDePlata + costOp,
                    Data = DateTime.Now,
                    Factura = factura,

                    ContClient = cont,
                    ContClientId = cont.Id,//(Cont)cont.Clone(),
                    ContFurnizor = factura.Furnizor.ListaConturi.First(),
                    ContFurnizorId = factura.Furnizor.ListaConturi.First().Id,

                    Moneda = factura.Moneda,
                    isProcesata = false,
                    TipOperatiune = op.Denumire,
                    Costuri = new List<Cost>()
                });
                tranzactii.Last().AdaugaCost(op);

                return true;
            }
            return false;
        }
        private static void adaugaTranzactieNula(List<Tranzactie> tranzactii, Factura factura) {
            // Scadem tranzactiile partiale care s-au facut
            double valoareDePlata = factura.Valoare;
            if (factura.ListaTranzactii != null && factura.ListaTranzactii.Count != 0)
                valoareDePlata -= factura.ListaTranzactii.Sum(t => t.ValoareFactura);

            tranzactii.Add(new Tranzactie {
                Id = factura.Id, // Id e FK
                ValoareFactura = valoareDePlata,
                ValoareTotala = valoareDePlata,
                Data = DateTime.Now,
                Factura = factura,

                ContClient = null,
                ContClientId = null,
                ContFurnizor = factura.Furnizor.ListaConturi.First(),
                ContFurnizorId = factura.Furnizor.ListaConturi.First().Id,

                Moneda = factura.Moneda,
                isProcesata = false,
                TipOperatiune = MeniuPrincipal.DENUMIRE_OP_PLATA_FACTURA,
                Costuri = new List<Cost>()
            });

        }
        private void adaugaScenariuInTab(List<Tranzactie> scenariu, List<Cont> conturiOriginale) {
            // Creeaza un tab nou si afiseaza scenariul din parametru 
            scenariiTabControl.TabPages.Add(new TabPage($"Scenariul {scenariiTabControl.TabCount + 1}"));
            ListView lv = new ListView();

            lv.View = View.Details;
            lv.FullRowSelect = true;
            lv.GridLines = true;

            // Copiaza formatul coloanelor
            foreach (ColumnHeader col in scenariiLV.Columns) {
                ColumnHeader columnHeader = new ColumnHeader();
                columnHeader.Width = col.Width;
                columnHeader.Text = col.Text;
                lv.Columns.Add(columnHeader);
            }

            // Adauga pe rand liniile
            List<Cont> conturiModificabile = new List<Cont>(conturiBifate.Select(x => (Cont)x.Clone()));
            for (int i = 0; i < scenariu.Count; i++) {// var tranz in scenariu) {
                var tranz = scenariu[i];
                if (tranz.ContClient == null || tranz.ValoareTotala == 0)
                    continue;

                Cont contAferent = conturiModificabile.First(c => c.Id == tranz.ContClientId);
                contAferent.Sold -= tranz.ValoareTotala;
                contAferent.DataSold = DateTime.Now;

                ListViewItem lvi = new ListViewItem(new string[]{
                    tranz.Factura.Furnizor.Nume,
                    tranz.Factura.Furnizor.Prioritate.ToString(),
                    tranz.Factura.Valoare.ToString("N2"),
                    "###############", // valoare ramasa
                    tranz.Moneda,
                    " ",
                    tranz.TotalCost?.ToString("N2"),
                    " ",
                    contAferent.IBAN,
                    "###############", //conturiBifate.First(c=>c.IBAN == contAferent.IBAN).Sold?.ToString("N2"),//-------
                    contAferent.Sold?.ToString("N2"),
                    tranz.ContClient.Moneda,
                    tranz.ContClient.Banca.Nume
                });
                lvi.SubItems[3].Text = tranz.ValoareFactura.ToString("N2");

                // calculeaza valoarea care trebuie pusa in sold initial
                // prin scaderea tranzactiilor presupuse (fara modificare de cont)
                double cheltuialaTrecuta = 0;
                for (int j = 0; j < i; j++) {
                    var tranzT = scenariu[j];
                    if (tranzT.ContClient == null)
                        continue;

                    if (tranzT.ContClient.IBAN == tranz.ContClient.IBAN)
                        cheltuialaTrecuta += tranzT.ValoareTotala;
                }
                lvi.SubItems[9].Text = (conturiBifate.First(c => c.IBAN == contAferent.IBAN).Sold - cheltuialaTrecuta)?.ToString("N2");

                // e pt gruparea costurilor
                lvi.SubItems[6].Tag = "costuri";
                lv.Items.Add(lvi);
            }
            lv.Items.Add(" ");

            string[] monede = scenariu.Select(s => s.Moneda).Distinct().ToArray();
            for (int i = 0; i < monede.Count(); i++) {
                // Calculeaza totaluri
                double totalFactura = scenariu.Where(s => s.Moneda == monede[i]).Sum(t => t.ValoareFactura);
                double totalCosturi = scenariu.Where(s => s.Moneda == monede[i]).Sum(t => t.TotalCost) ?? 0;

                // Linia cu total
                ListViewItem lviT = new ListViewItem(new string[] {
                    "TOTAL","-","-",
                    totalFactura.ToString("N2"),
                    monede[i],
                    " ",
                    totalCosturi.ToString("N2"),
                    " ",
                    "-","-","-","-","-"
                });
                lv.Items.Add(lviT);
            }

            // Adauga listView ul creat la ultima pagina
            scenariiTabControl.TabPages[scenariiTabControl.TabPages.Count - 1].Controls.Add(lv);
            lv.Dock = DockStyle.Fill;
            lv.MouseMove += Lv_MouseMove;
            //lv.MouseClick += Lv_MouseClick;

            string totalCosturiS = "";
            string totalPlataS = "";
            for (int i = 0; i < monede.Count(); i++) {
                // Calculeaza totaluri
                double totalFactura = scenariu.Where(s => s.Moneda == monede[i]).Sum(t => t.ValoareFactura);
                double totalCosturi = scenariu.Where(s => s.Moneda == monede[i]).Sum(t => t.TotalCost) ?? 0;

                totalCosturiS += totalCosturi.ToString("N2") + $" {monede[i]} " + (i < monede.Count() - 1 ? " | " : "");
                totalPlataS += (totalFactura + totalCosturi).ToString("N2") + $" {monede[i]} " + (i < monede.Count() - 1 ? " | " : "");
            }
            // Linia din tabelul centralizator 
            ListViewItem lviC = new ListViewItem(new string[] {
                scenariiTabControl.TabCount.ToString(),
                totalCosturiS,
                totalPlataS,
                String.Join(" | ",monede)
                //scenariu.First().Factura.Moneda.ToString()
            });
            centralizatorLV.Items.Add(lviC);
        }

        private bool tranzactiiEgale(Tranzactie tranz1, Tranzactie tranz2) {
            bool conturiEgale = (tranz1.ContClient != null && tranz2.ContClient != null &&
                                tranz1.ContClient.IBAN == tranz2.ContClient.IBAN) ||
                                (tranz1.ContClient == null && tranz2.ContClient == null);

            if (conturiEgale &&
                tranz1.ContFurnizor.IBAN == tranz2.ContFurnizor.IBAN &&
                tranz1.Factura.Valoare == tranz2.Factura.Valoare &&
                tranz1.TotalCost == tranz2.TotalCost &&
                tranz1.Moneda == tranz2.Moneda &&
                tranz1.TipOperatiune == tranz2.TipOperatiune &&
                tranz1.ValoareTotala == tranz2.ValoareTotala)
                return true;

            return false;
        }
        private bool scenariiEgale(List<Tranzactie> scenariu1, List<Tranzactie> scenariu2) {
            if (scenariu1.Count == 0 && scenariu2.Count == 0) return true;
            if (scenariu1.Count != scenariu2.Count) return false;
            return tranzactiiEgale(scenariu1[0], scenariu2[0]);
        }


        private void centralizatorLV_SelectedIndexChanged(object sender, EventArgs e) {
            scenariiTabControl.SelectedIndexChanged -= scenariiTabControl_SelectedIndexChanged;
            if (centralizatorLV.FocusedItem != null)
                scenariiTabControl.SelectedIndex = centralizatorLV.FocusedItem.Index;
            scenariiTabControl.SelectedIndexChanged += scenariiTabControl_SelectedIndexChanged;
        }
        private void scenariiTabControl_SelectedIndexChanged(object sender, EventArgs e) {
            centralizatorLV.SelectedIndexChanged -= centralizatorLV_SelectedIndexChanged;
            centralizatorLV.SelectedItems.Clear();
            centralizatorLV.Items[scenariiTabControl.SelectedIndex].Focused = true;
            centralizatorLV.Items[scenariiTabControl.SelectedIndex].Selected = true;
            centralizatorLV.SelectedIndexChanged += centralizatorLV_SelectedIndexChanged;
        }

        private Point oldPoint = new Point(0, 0);
        private void Lv_MouseMove(object sender, MouseEventArgs e) {
            if (e.Location != oldPoint) {
                ListView lv = ((ListView)sender);
                ListViewItem item = lv.GetItemAt(e.X, e.Y);
                ListViewHitTestInfo info = lv.HitTest(e.X, e.Y);

                Point point = e.Location;// lv.PointToClient(Cursor.Position);
                point.X += 10;
                point.Y += 20;

                if ((item != null) && (info.SubItem != null) && (info.SubItem.Tag != null) && (info.SubItem.Tag.ToString() == "costuri")) {
                    int indexScenariu = scenariiTabControl.SelectedIndex;
                    int indexTranzactie = lv.Items.IndexOf(item);

                    // caluculez indexul din memorie
                    int i; 
                    for (i = 0; i < scenarii[indexScenariu].Count && (indexTranzactie > 0 || scenarii[indexScenariu][i].ContClient == null); i++) {//; indexTranzactieMem++) 
                        //indexTranzactieMem++;
                        if (scenarii[indexScenariu][i].ContClient != null) {
                            indexTranzactie--; 
                        } 
                    }
                    int indexTranzactieMem = i;

                    // afisez costuri
                    string str = "Costuri:\n";
                    foreach (Cost c in scenarii[indexScenariu][indexTranzactieMem].Costuri) {
                        str += $"{c.Denumire}, {c.Valoare} {c.Moneda}\n";
                    }

                    toolTip1.Active = true;
                    toolTip1.Show(str, lv, point);
                }
                else {
                    toolTip1.Active = false;
                }
                oldPoint = e.Location;
            }
        }



        public static void salveazaScenariuInBd(List<Tranzactie> scenariu) {
            using (FacturiContext context = new FacturiContext()) {

                // Exporta in fisier (TUDOR) 
                /*CommonOpenFileDialog dialog = new CommonOpenFileDialog();
                dialog.InitialDirectory = "C:";
                dialog.IsFolderPicker = true;
                dialog.ShowDialog();*/
                /* if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                 {
                     MessageBox.Show("You selected: " + dialog.FileName);
                 }*/


                //Dictionary<int, List<Tranzactie>> TranzactiiBanci = new Dictionary<int, List<Tranzactie>>();

                foreach (var tranz in scenariu) {
                    if (tranz.ContClient == null || tranz.ValoareTotala == 0)
                        continue;

                    // Actualizez cont
                    Cont cont = context.Conturi
                        .First(c => c.Id == tranz.ContClient.Id);
                    cont.Sold = tranz.ContClient.Sold;
                    cont.DataSold = DateTime.Now;

                    // leg tranzactia de celelalte obiecte din baza de date
                    tranz.Factura = context.Facturi.First(f => f.Id == tranz.Factura.Id);
                    tranz.ContClient = context.Conturi.First(c => c.Id == tranz.ContClient.Id);
                    tranz.ContFurnizor = context.Conturi.First(c => c.Id == tranz.ContFurnizor.Id);
                    tranz.ContClient.Banca = context.Banci.First(b => b.Id == tranz.ContClient.BancaId);

                    // Atasez tranzactia la baza de date
                    context.Entry<Tranzactie>(tranz).State = System.Data.Entity.EntityState.Added;

                    //export
                    /*if (!TranzactiiBanci.ContainsKey(tranz.ContClient.BancaId)) {
                        TranzactiiBanci.Add(tranz.ContClient.BancaId, new List<Tranzactie>());
                    }
                    TranzactiiBanci[tranz.ContClient.BancaId].Add(tranz);*/
                }

                /*foreach (var i in TranzactiiBanci.Keys) {
                    try { exportaTranzCsv(dialog.FileName + $@"\{NumeBanca(i, TranzactiiBanci[i].Select(x => x.ContClient.Banca).ToList())}" + ".csv", TranzactiiBanci[i]); }
                    catch { }
                }*/

                /* SAU: -------------------------------------------------------------------------------------------------
                context.Conturi.AddOrUpdate(x=>x.Id,scenarii[index].Select(t => t.ContClient).ToArray());

                // tranzactiile(si atrib. din ele) din scenarii[index] sunt detached fata de baza de date
                foreach(var tranz in scenarii[index]){
                    tranz.Factura = context.Facturi.First(f => f.Id == tranz.Factura.Id);
                    tranz.ContClient = context.Conturi.First(c => c.Id == tranz.ContClient.Id);
                    tranz.ContFurnizor = context.Conturi.First(c => c.Id == tranz.ContFurnizor.Id);
                }
                context.Tranzactii.AddOrUpdate(t => t.Id, scenarii[index].ToArray());
                */

                context.SaveChanges();
            }
        }


        private void prevButton_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
        private void nextButton_Click(object sender, EventArgs e) {
            //Debug.WriteLine(scenarii[0].Max(s => s.ContClient.Sold));

            DialogResult res = MessageBox.Show("Aplicati scenariul curent de tranzactii in baza de date?", "Salvare",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);

            if (res == DialogResult.Yes) {
                // Actualizare baza de date 
                int index = scenariiTabControl.SelectedIndex;
                salveazaScenariuInBd(scenarii[index]);


                this.DialogResult = DialogResult.OK;
            }
        }
        public static string NumeBanca(int id, List<Banca> banci) {
            return banci.First(x => x.Id == id).Nume;
        }
        public static void exportaTranzCsv(string filepath, List<Tranzactie> listaTranzactii) {
            using (StreamWriter file = new StreamWriter(filepath, false)) {
                foreach (var x in listaTranzactii) {
                    file.WriteLine(x.Id + "," + x.ContClient.IBAN + "," + x.ContFurnizor.IBAN + "," + x.ValoareTotala + "," + x.Moneda + "," + "Plata Factura: " + x.Factura.Id + "," + x.Data.Day + "." + x.Data.Month + "." + x.Data.Year);

                    //Stringbuilder
                    //Clasa pt template banca
                    //Template Nume Fisier
                    //generare ordine de plata nu neaparat pe baza buton salvare in baza de date
                }
            }

        }

        private void editButton_Click(object sender, EventArgs e) {
            int index = scenariiTabControl.SelectedIndex;

            /*foreach(var factura in facturiBifate) {
                Tranzactie t;
                try {
                    t = scenarii[index].First(tr => tr.FacturaId == factura.Id);
                } catch { t = null; } 
                if (t != null) continue;


                // Scadem tranzactiile partiale care s-au facut
                double valoareDePlata = factura.Valoare;
                if (factura.ListaTranzactii != null && factura.ListaTranzactii.Count != 0)
                    valoareDePlata -= factura.ListaTranzactii.Sum(tr => tr.ValoareFactura);


                scenarii[index].Add(new Tranzactie {
                    Id = factura.Id, // Id e FK
                    ValoareFactura = valoareDePlata,
                    ValoareTotala = valoareDePlata,
                    Data = DateTime.Now,
                    Factura = factura,

                    ContClient = null,
                    ContClientId = null, 
                    ContFurnizor = factura.Furnizor.ListaConturi.First(),
                    ContFurnizorId = factura.Furnizor.ListaConturi.First().Id,

                    Moneda = factura.Moneda,
                    isProcesata = false,
                    TipOperatiune = MeniuPrincipal.DENUMIRE_OP_PLATA_FACTURA,
                    Costuri = new List<Cost>()
                });
            }*/

            // afisare editor de scenariu 
            using (Form frm = new EditareScenariu(scenarii[index], conturiBifate)) {
                if (frm.ShowDialog() == DialogResult.OK) {
                    // Actualizare baza de date  
                    //salveazaScenariuInBd(scenarii[index]);

                    // Adauga scenariile in UI 
                    scenariiTabControl.SelectedIndexChanged -= scenariiTabControl_SelectedIndexChanged;
                    centralizatorLV.SelectedIndexChanged -= centralizatorLV_SelectedIndexChanged;

                    scenariiTabControl.TabPages.Clear();
                    centralizatorLV.Items.Clear();
                    scenarii.ForEach(s => adaugaScenariuInTab(s, conturiBifate));

                    scenariiTabControl.SelectedIndexChanged += scenariiTabControl_SelectedIndexChanged;
                    centralizatorLV.SelectedIndexChanged += centralizatorLV_SelectedIndexChanged;


                    //this.DialogResult = DialogResult.OK;
                }
                else {

                    scenariiTabControl.SelectedIndexChanged -= scenariiTabControl_SelectedIndexChanged;
                    centralizatorLV.SelectedIndexChanged -= centralizatorLV_SelectedIndexChanged;
                    ordoneazaFacturi();
                    calculeazaToateScenariile();

                    scenariiTabControl.SelectedIndexChanged += scenariiTabControl_SelectedIndexChanged;
                    centralizatorLV.SelectedIndexChanged += centralizatorLV_SelectedIndexChanged;
                }
            }
        }
    }
}
