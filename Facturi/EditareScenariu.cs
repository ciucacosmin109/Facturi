using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facturi {
    public partial class EditareScenariu : Form {
        private List<Tranzactie> scenariu;
        private List<Cont> conturiModificabile;
        private List<string> monedeScenariu;
         
        private double backupValue = 0;

        private readonly int[] pctStart = { 6, 9 }; // linii, coloane
        private readonly int randSoldRamas = 4; // pt conturi
        private readonly int coloanaValoare = 6; // pt facturi

        private readonly Color culoareZonaHeader = Color.LightGray;
        private readonly Color culoareZonaInactiva = Color.FromArgb(160, 160, 160);
        private readonly Color culoareZonaEditabila = Color.White;
        private readonly Color culoareZonaNonEditabila = Color.FromArgb(245, 245, 245);

        public EditareScenariu(List<Tranzactie> scen, List<Cont> conturiOrig) {
            InitializeComponent();
            scenariuDGV.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            scenariu = scen;
            conturiModificabile = new List<Cont>(conturiOrig.Select(x => (Cont)x.Clone()));

            // Empty 
            scenariuDGV.Columns.Add("Furnizor", "Furnizor");
            scenariuDGV.Columns.Add("Cont destinatie", "Cont destinatie");
            scenariuDGV.Columns.Add("Banca destinatie", "Banca destinatie");

            scenariuDGV.Columns.Add("Data facturii", "Data facturii");
            scenariuDGV.Columns[scenariuDGV.Columns.Count - 1].Width =
                (int)(scenariuDGV.Columns[scenariuDGV.Columns.Count - 1].Width * 0.7);

            scenariuDGV.Columns.Add("Data scadenta", "Data scadenta");
            scenariuDGV.Columns[scenariuDGV.Columns.Count - 1].Width =
                (int)(scenariuDGV.Columns[scenariuDGV.Columns.Count - 1].Width * 0.7);

            scenariuDGV.Columns.Add("Valoare factura", "Valoare factura");
            scenariuDGV.Columns[scenariuDGV.Columns.Count - 1].Width =
                (int)(scenariuDGV.Columns[scenariuDGV.Columns.Count - 1].Width * 0.7);

            scenariuDGV.Columns.Add("Valoare de plata", "Valoare de plata");
            scenariuDGV.Columns[scenariuDGV.Columns.Count - 1].Width =
                (int)(scenariuDGV.Columns[scenariuDGV.Columns.Count - 1].Width * 0.7);

            scenariuDGV.Columns.Add("Moneda", "Moneda");
            scenariuDGV.Columns[scenariuDGV.Columns.Count - 1].Width =
                (int)(scenariuDGV.Columns[scenariuDGV.Columns.Count - 1].Width * 0.5);

            scenariuDGV.Columns.Add("Header conturi", "Header conturi");
            scenariuDGV.Columns[scenariuDGV.Columns.Count - 1].Width =
                (int)(scenariuDGV.Columns[scenariuDGV.Columns.Count - 1].Width * 0.6);

            // Adauga header conturi 
            scenariuDGV.Rows.Add(5);
            // Populeaza header conturi
            scenariuDGV.Rows[0].Cells[scenariuDGV.Columns.Count - 1].Value = "Banca";
            scenariuDGV.Rows[1].Cells[scenariuDGV.Columns.Count - 1].Value = "IBAN";
            scenariuDGV.Rows[2].Cells[scenariuDGV.Columns.Count - 1].Value = "Moneda";
            scenariuDGV.Rows[3].Cells[scenariuDGV.Columns.Count - 1].Value = "Sold initial";
            scenariuDGV.Rows[4].Cells[scenariuDGV.Columns.Count - 1].Value = "Sold final";

            // Adauga si populeaza header facturi
            scenariuDGV.Rows.Add(
                "Furnizor",
                "Cont destinatie",
                "Banca destinatie",
                "Data facturii",
                "Data scadenta",
                "Valoare factura",
                "Valoare de plata",
                "Moneda",
                ""
            );
            // ------------------------------------------------------------------------------------

            // selectare monede unice 
            monedeScenariu = scenariu.Select(s => s.Moneda).Distinct().ToList();

            // selectare conturi unice 
            /*conturiModificabile = *new List<Cont>();
            foreach (Tranzactie t in scenariu) {
                if (!conturiModificabile.Select(c => c.IBAN).Contains(t.ContClient.IBAN))
                    conturiModificabile.Add(t.ContClient);
            }*/

            // conturi
            populareConturi(conturiModificabile); 
            // facturi
            populareFacturi(scenariu);

            // coloreaza
            coloreazaTabel();

            //------------------ 
            scenariuDGV.CellValidated += ScenariuDGV_CellValidated;
            scenariuDGV.CellMouseDoubleClick += ScenariuDGV_CellMouseDoubleClick;
            //------------------



        }
         


        //--------------------------------------------------------------------------------------

        private void populareConturi(List<Cont> con) {
            for (int i = pctStart[1]; i < scenariuDGV.ColumnCount; i++)
                scenariuDGV.Columns.RemoveAt(i--);

            foreach (Cont c in con) {
                scenariuDGV.Columns.Add("", "");
                scenariuDGV.Rows[0].Cells[scenariuDGV.ColumnCount - 1].Value = c.Banca.Nume;
                scenariuDGV.Rows[1].Cells[scenariuDGV.ColumnCount - 1].Value = c.IBAN;
                scenariuDGV.Rows[2].Cells[scenariuDGV.ColumnCount - 1].Value = c.Moneda;
                scenariuDGV.Rows[3].Cells[scenariuDGV.ColumnCount - 1].Value = conturiModificabile.First(co => co.IBAN == c.IBAN).Sold?.ToString("N2");
                scenariuDGV.Rows[4].Cells[scenariuDGV.ColumnCount - 1].Value = conturiModificabile.First(co => co.IBAN == c.IBAN).Sold?.ToString("N2"); // "##########";// c.Sold; // de modificat
            }
            scenariuDGV.Columns.Add("", "");

            for (int i = 0; i < monedeScenariu.Count(); i++) { 
                // calculeaza totalSoldInitial pe baza tabeluului
                double totalSoldInitial = 0;
                for (int j = pctStart[1]; j < pctStart[1] + conturiModificabile.Count; j++) {
                    if (scenariuDGV.Rows[randSoldRamas-2].Cells[j].Value.ToString() == monedeScenariu[i]) {
                        totalSoldInitial += Convert.ToDouble(scenariuDGV.Rows[randSoldRamas-1].Cells[j].Value);
                    }
                }

                // Col cu total
                scenariuDGV.Columns.Add("", "");
                scenariuDGV.Rows[0].Cells[scenariuDGV.ColumnCount - 1].Value = "TOTAL "+monedeScenariu[i];
                scenariuDGV.Rows[1].Cells[scenariuDGV.ColumnCount - 1].Value = "-";
                scenariuDGV.Rows[2].Cells[scenariuDGV.ColumnCount - 1].Value = monedeScenariu[i];
                scenariuDGV.Rows[3].Cells[scenariuDGV.ColumnCount - 1].Value = totalSoldInitial.ToString("N2");
                scenariuDGV.Rows[4].Cells[scenariuDGV.ColumnCount - 1].Value = totalSoldInitial.ToString("N2");  // "###########";

                scenariuDGV.Rows[3].Cells[scenariuDGV.ColumnCount - 1].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                scenariuDGV.Rows[4].Cells[scenariuDGV.ColumnCount - 1].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }


        }
        private void populareFacturi(List<Tranzactie> tranz) {
            for (int i = pctStart[0]; i < scenariuDGV.Rows.Count; i++)
                scenariuDGV.Rows.RemoveAt(i--);

            for (int i = 0; i < tranz.Count; i++) { // Tranzactie t in tranz) {
                Tranzactie t = tranz[i];
                scenariuDGV.Rows.Add(
                    t.Factura.Furnizor.Nume,
                    t.ContFurnizor.IBAN,
                    t.ContFurnizor.Banca.Nume,
                    t.Factura.DataEmitere.ToString("dd/MM/yyyy"),
                    t.Factura.DataScadenta.ToString("dd/MM/yyyy"),
                    t.Factura.Valoare.ToString("N2"), // val facturii
                    t.ValoareFactura.ToString("N2"),  // val pe care vreau sa o platesc
                    t.Moneda,
                    " "
                );

                if (t.ContClient == null) {
                    scenariuDGV.Rows[scenariuDGV.Rows.Count - 1].Cells[coloanaValoare].Value = "";
                    continue;
                }


                int indexCont = conturiModificabile.FindIndex(c => c.IBAN == t.ContClient.IBAN);
                valoareFacturaCont(i, indexCont, t.ValoareTotala);

                if (soldCont(indexCont) == -1)
                    soldCont(indexCont, soldInitialCont(indexCont) - t.ValoareTotala);
                else soldCont(indexCont, soldCont(indexCont) - t.ValoareTotala);

                
                // calculeaza totalSoldFinal pe baza tabeluului
                double totalSoldFinal = 0;
                string monedaC = conturiModificabile[indexCont].Moneda;
                for (int j = pctStart[1]; j < pctStart[1] + conturiModificabile.Count; j++) {
                    if (scenariuDGV.Rows[randSoldRamas - 2].Cells[j].Value.ToString() == monedaC) {
                        //Debug.WriteLine(scenariuDGV.Rows[randSoldRamas].Cells[j].Value.ToString());
                        totalSoldFinal += Convert.ToDouble(scenariuDGV.Rows[randSoldRamas].Cells[j].Value);
                    }
                }
                totalSoldRamas(monedeScenariu.IndexOf(monedaC), totalSoldFinal);
            }

            // Adauga totaluri
            scenariuDGV.Rows.Add();

            for (int i = 0; i < monedeScenariu.Count(); i++) {
                // Calculeaza totaluri
                double totalFactura = scenariu.Where(s => s.Moneda == monedeScenariu[i]).Sum(t => t.Factura.Valoare);
                double totalCosturi = scenariu.Where(s => s.Moneda == monedeScenariu[i]).Sum(t => t.TotalCost) ?? 0;

                // calculeaza total de plata pe baza tabeluului
                double v_totalDePlata = 0;
                for(int j = pctStart[0];j < pctStart[0]+scenariu.Count;j++) {
                    if(scenariuDGV.Rows[j].Cells[coloanaValoare+1].Value.ToString() == monedeScenariu[i]) { 
                        if (Double.TryParse(scenariuDGV.Rows[j].Cells[coloanaValoare].Value.ToString(), out double v))
                            v_totalDePlata += v; 
                    }
                }

                // Linia cu total
                scenariuDGV.Rows.Add(
                    "TOTAL "+ monedeScenariu[i], "-", "-", "-", "-", 
                    totalFactura.ToString("N2"),
                    v_totalDePlata, // total de plata
                    monedeScenariu[i]
                );
                //lv.Items.Add(lviT);
                totalDePlata(i, v_totalDePlata);
            }
        }

        private void coloreazaTabel() { // + alinierea nr la dreapta
            // Coloreaza zona neutilizata
            for (int i = 0; i < pctStart[0] - 1; i++) {
                for (int j = 0; j < pctStart[1] - 1; j++) {
                    scenariuDGV.Rows[i].Cells[j].Style.BackColor = culoareZonaInactiva;
                    scenariuDGV.Rows[i].Cells[j].Style.SelectionBackColor = culoareZonaInactiva;
                }
            }

            // Coloreaza header conturi
            for (int i = 0; i < scenariuDGV.Rows.Count; i++)
                scenariuDGV.Rows[i].Cells[pctStart[1] - 1].Style.BackColor = culoareZonaHeader;

            // Coloreaza h. facturi
            for (int i = 0; i < scenariuDGV.Columns.Count; i++)
                scenariuDGV.Rows[pctStart[0] - 1].Cells[i].Style.BackColor = culoareZonaHeader;

            // Coloreaza zona editabila si noneditabila
            for (int i = pctStart[0]; i < scenariuDGV.Rows.Count; i++) {
                for (int j = 0; j < scenariuDGV.Columns.Count; j++) {
                    if (i < scenariu.Count + pctStart[0] && (j == coloanaValoare || (j >= pctStart[1] && j < pctStart[1]+conturiModificabile.Count))) {
                        scenariuDGV.Rows[i].Cells[j].Style.BackColor = culoareZonaEditabila;
                        scenariuDGV.Rows[i].Cells[j].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                    else if (j != pctStart[1] - 1) {
                        scenariuDGV.Rows[i].Cells[j].Style.BackColor = culoareZonaNonEditabila;
                        if (j == coloanaValoare - 1)
                            scenariuDGV.Rows[i].Cells[j].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                }
                //---------------
            }
            for (int j = pctStart[1]; j < scenariuDGV.Columns.Count; j++) {
                //scenariuDGV.Rows[randSoldRamas].Cells[j].Style = new DataGridViewCellStyle { BackColor = culoareZonaEditabila };
                for (int i = 0; i < pctStart[0] - 1; i++) {

                    scenariuDGV.Rows[i].Cells[j].Style.BackColor = culoareZonaNonEditabila;
                    if (i == randSoldRamas || i == randSoldRamas - 1) {
                        scenariuDGV.Rows[i].Cells[j].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                }
            }

            // Totaluri 
            for (int i = 0; i < pctStart[1] + conturiModificabile.Count + 1; i++)
                scenariuDGV.Rows[pctStart[0] + scenariu.Count].Cells[i].Style.BackColor = culoareZonaHeader;

            for (int i = 0; i < pctStart[0] + scenariu.Count + 1; i++)
                scenariuDGV.Rows[i].Cells[pctStart[1] + conturiModificabile.Count].Style.BackColor = culoareZonaHeader;
            scenariuDGV.Columns[pctStart[1] + conturiModificabile.Count].Width = 30;

        }

        //--------------------------------------------------------------------------------------

        private double soldInitialCont(int index) {
            try {
                return Convert.ToDouble(scenariuDGV.Rows[randSoldRamas - 1].Cells[pctStart[1] + index].Value);
            }
            catch { return -1; }
        }
        private double soldCont(int index) {
            try {
                return Convert.ToDouble(scenariuDGV.Rows[randSoldRamas].Cells[pctStart[1] + index].Value);
            }
            catch { return -1; }
        }
        private void soldCont(int index, double newValue) {
            scenariuDGV.Rows[randSoldRamas].Cells[pctStart[1] + index].Value = newValue.ToString("N2");
        }

        private double valoareFactura(int index) {
            try {
                return Convert.ToDouble(scenariuDGV.Rows[pctStart[0] + index].Cells[coloanaValoare].Value);
            }
            catch { return -1; }
        }
        private void valoareFactura(int index, double? newValue) {
            scenariuDGV.Rows[pctStart[0] + index].Cells[coloanaValoare].Value = newValue != null ? newValue?.ToString("N2") : "";
        }

        private double valoareFacturaCont(int indexF, int indexC) {
            try {
                return Convert.ToDouble(scenariuDGV.Rows[pctStart[0] + indexF].Cells[pctStart[1] + indexC].Value);
            }
            catch { return -1; }
        }
        private void valoareFacturaCont(int indexF, int indexC, double? newValue) {
            scenariuDGV.Rows[pctStart[0] + indexF].Cells[pctStart[1] + indexC].Value = newValue != null ? newValue?.ToString("N2") : "";
            scenariuDGV.Rows[pctStart[0] + indexF].Cells[pctStart[1] + indexC].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }


        private void totalDePlata(int indexTot, double totalDePlata) {
            scenariuDGV.Rows[pctStart[0] + scenariu.Count + 1 + indexTot].Cells[pctStart[1] - 3].Value = totalDePlata.ToString("N2");
            scenariuDGV.Rows[pctStart[0] + scenariu.Count + 1 + indexTot].Cells[pctStart[1] - 3].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void totalSoldRamas(int indexTot, double totalSoldFinal) {
            scenariuDGV.Rows[randSoldRamas].Cells[pctStart[1] + conturiModificabile.Count + 1 + indexTot].Value = totalSoldFinal.ToString("N2");
            scenariuDGV.Rows[randSoldRamas].Cells[pctStart[1] + conturiModificabile.Count + 1 + indexTot].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        //--------------------------------------------------------------------------------------

        private void scenariuDGV_CellEnter(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= pctStart[0] && e.RowIndex < scenariu.Count + pctStart[0] && (e.ColumnIndex == coloanaValoare /*|| e.ColumnIndex >= pctStart[1]*/)) {
                scenariuDGV.Columns[e.ColumnIndex].ReadOnly = false;
                backupValue = valoareFactura(e.RowIndex - pctStart[0]); 
            }
            else scenariuDGV.Columns[e.ColumnIndex].ReadOnly = true;
        }
        private void ScenariuDGV_CellValidated(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= pctStart[0] && e.RowIndex < scenariu.Count + pctStart[0] && (e.ColumnIndex == coloanaValoare /*|| e.ColumnIndex >= pctStart[1]*/)) {
                if(Double.TryParse(scenariuDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(),out double v))
                    scenariuDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Convert.ToDouble(v).ToString("N2");
                updateCells(e.RowIndex - pctStart[0]);
            }
        }

        private void updateCells(int indexF) {
            if(scenariu[indexF].ContClient == null) { 
                MessageBox.Show("Nu a fost selectat un cont.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                scenariuDGV.CurrentCell.Value = "";
                return;
            }
            //----------------------------------------
             
            int indexCont;
            try {
                indexCont = conturiModificabile.FindIndex(c => c.IBAN == scenariu[indexF].ContClient.IBAN);
            } catch { return; }

            // Valoarea pe care vreau sa o platesc + cost
            double valDePlata = valoareFactura(indexF);
            Operatiune op = scenariu[indexF].ContClient.ListaOperatiuni.First(o => o.Denumire == MeniuPrincipal.DENUMIRE_OP_PLATA_FACTURA);

            double percentCost = (op.PercentageValue ?? 0) * (valDePlata);
            double costOp = (op.CostFix ?? 0) + (percentCost > (op.CostMinim ?? 0) ? percentCost : op.CostMinim ?? 0); 
            //double costOp = (op.CostFix ?? 0) + (op.PercentageValue ?? 0) * ((op.CostMinim ?? 0) > valDePlata ? (op.CostMinim ?? 0) : valDePlata);

            double valExtrasaDinCont = valDePlata + costOp;
            double valVecheExtrasaDinCont = valoareFacturaCont(indexF, indexCont);
            if (valVecheExtrasaDinCont == -1) valVecheExtrasaDinCont = 0;

            //double soldInitial = soldInitialCont(indexCont);
            double soldRamas = soldCont(indexCont);

            if (valExtrasaDinCont <= soldRamas + valVecheExtrasaDinCont && valDePlata != -1) {
                valoareFacturaCont(indexF, indexCont, valExtrasaDinCont);
                soldCont(indexCont, soldRamas + valVecheExtrasaDinCont - valExtrasaDinCont);



                Tranzactie t = scenariu[indexF]; 

                t.ValoareFactura = valoareFactura(indexF);
                t.ValoareTotala = valoareFacturaCont(indexF, indexCont);
                t.ContClient.Sold = soldCont(indexCont);
                t.ContClient.DataSold = DateTime.Now;

                t.Costuri.Clear();
                t.AdaugaCost(op); 


                scenariuDGV.Rows[indexF + pctStart[0]].Cells[coloanaValoare].Style.BackColor = culoareZonaEditabila;
            }
            else {
                valoareFactura(indexF, backupValue);
                scenariuDGV.Rows[indexF + pctStart[0]].Cells[coloanaValoare].Style.BackColor = Color.Red;
            }


            // calculeaza totalSoldFinal pe baza tabeluului-----------------------------
            for (int i = 0; i < monedeScenariu.Count; i++) {
                double totalSoldFinal = 0; 
                for (int j = pctStart[1]; j < pctStart[1] + conturiModificabile.Count; j++) {
                    if (scenariuDGV.Rows[randSoldRamas - 2].Cells[j].Value.ToString() == monedeScenariu[i]) {
                        if (Double.TryParse(scenariuDGV.Rows[randSoldRamas].Cells[j].Value.ToString(), out double v))
                            totalSoldFinal += v;
                    }
                }
                totalSoldRamas(i, totalSoldFinal);
            }

            // Valoare totala ----------------------------------------------------
            string moneda = scenariuDGV.Rows[indexF + pctStart[0]].Cells[coloanaValoare + 1].Value.ToString();
            int idxTot = monedeScenariu.IndexOf(moneda); 
            // calculeaza total de plata pe baza tabeluului
            double tdp = 0;
            for (int j = pctStart[0]; j < pctStart[0] + scenariu.Count; j++) {
                if (scenariuDGV.Rows[j].Cells[coloanaValoare + 1].Value.ToString() == moneda) {
                    if(Double.TryParse(scenariuDGV.Rows[j].Cells[coloanaValoare].Value.ToString(), out double v))
                        tdp += v;
                }
            }
            totalDePlata(idxTot, tdp);
            //-------------------------------------------------------------------------


        }



        private void ScenariuDGV_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.RowIndex < scenariu.Count + pctStart[0] && e.ColumnIndex >= pctStart[1] && e.ColumnIndex < pctStart[1] + conturiModificabile.Count) {
                statusLabel.Text += ".";

                int indexF = e.RowIndex - pctStart[0];
                int indexCnou = e.ColumnIndex - pctStart[1];
                int indexCvechi;
                try {
                    indexCvechi = conturiModificabile.FindIndex(cs => scenariu[indexF].ContClient!=null && cs.IBAN == scenariu[indexF].ContClient.IBAN);
                } catch { indexCvechi = -1; }

                if (scenariu[indexF].Moneda == conturiModificabile[indexCnou].Moneda) {
                    if (indexCvechi != -1) {
                        // Adaugam valoarea inapoi in contul vechi 
                        double valVeche = valoareFacturaCont(indexF, indexCvechi);
                        soldCont(indexCvechi, soldCont(indexCvechi) + valVeche);

                        // Stergem acea val din tabel 
                        valoareFacturaCont(indexF, indexCvechi, null);
                    }
                    
                    // Resetam contul tranz 
                    scenariu[indexF].ContClient = null;
                    scenariu[indexF].ContClientId = null; 
                    scenariu[indexF].Costuri.Clear();

                    valoareFactura(indexF, null);
 
                    // Daca este de fapt un schimb la alt cont ...
                    if (indexCnou != indexCvechi) {
                        Cont cont = conturiModificabile[indexCnou];
                        Operatiune op;

                        try { op = cont.ListaOperatiuni.First(o => o.Denumire == MeniuPrincipal.DENUMIRE_OP_PLATA_FACTURA); }
                        catch {
                            MessageBox.Show("Contul nu suporta operatiunea de plata a facturilor.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; 
                        } 
                        // Verifica daca contul suporta DENUMIRE_OP_PLATA_FACTURA
                        if (op == null) {
                            MessageBox.Show("Contul nu suporta operatiunea de plata a facturilor.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; 
                        } 

                        // Verifica daca se poate platii
                        double costOp = op.CostCalculat(0); 
                        if (costOp <= cont.Sold) { 
                            // Schimbam contul tranz 
                            scenariu[indexF].ContClient = cont;
                            scenariu[indexF].ContClientId = cont.Id;

                            scenariu[indexF].AdaugaCost(op); // se adauga oricum in Scenarii.cs cand adaugam in tab

                            // Adaugam o val noua de plata (0) din noul cont
                            DataGridViewCell bak = scenariuDGV.CurrentCell;
                            scenariuDGV.CurrentCell = scenariuDGV.Rows[pctStart[0] + indexF].Cells[coloanaValoare];
                            valoareFactura(indexF, 0);
                            scenariuDGV.CurrentCell = bak;
                        } else MessageBox.Show("Sold prea mic.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                         
                    }
                }
                else MessageBox.Show("Nu poti plati o factura dintr-un cont cu o alta moneda.", "Eroare",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        //--------------------------------------------------------------------------------------

        private void backButton_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
        private void nextButton_Click(object sender, EventArgs e) {
            // Salveaza in BD - 
            DialogResult res = MessageBox.Show("Modificati scenariul?", "Salvare",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question,
               MessageBoxDefaultButton.Button1);

            if (res == DialogResult.Yes) {
                 
                // Inchide
                DialogResult = DialogResult.OK;
            }

        }

        //--------------------------------------------------------------------------------------



        //=========


    }
}
