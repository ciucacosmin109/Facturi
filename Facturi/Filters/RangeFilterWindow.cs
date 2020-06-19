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

namespace Filters{
    public partial class RangeFilterWindow : Form {  

        public int[] Filtru { get; private set; }

        public RangeFilterWindow() {
            InitializeComponent();
        }  
        private void RangeFilterWindow_ShowAtMouse(object sender, EventArgs e) => SetBounds(Cursor.Position.X+1, Cursor.Position.Y+1,this.Width, this.Height);


        public DialogResult Show(int[] filtru) {
            if (filtru == null || filtru.Length != 2) {
                minimUpDown.Value = 0;
                maximUpDown.Value = int.MaxValue; 
            } else {
                minimUpDown.Value = filtru[0];
                maximUpDown.Value = filtru[1];
            }
            return ShowDialog();
        }
        public DialogResult Show(ListView.ListViewItemCollection lvItems, ListView.ListViewItemCollection allItems, int index) {
            if (lvItems.Count == 0 || allItems.Count == 0) {
                minimUpDown.Value = 0;
                maximUpDown.Value = int.MaxValue;

                return ShowDialog();
            } 

            int min, max;
            min = max = Convert.ToInt32(lvItems[0].SubItems[index].Text);
            foreach (ListViewItem itm in lvItems) {
                int nr = Convert.ToInt32(itm.SubItems[index].Text);
                if (nr < min) min = nr;
                if (nr > max) max = nr;
            }
            minimUpDown.Value = min;
            maximUpDown.Value = max + 1;

            return ShowDialog();
        }

        private void cancelButton_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
        private void okButton_Click(object sender, EventArgs e) {
            Filtru = new int[] { Convert.ToInt32(minimUpDown.Value), Convert.ToInt32(maximUpDown.Value) };
            DialogResult = DialogResult.OK;
        }
        private void resetButton_Click(object sender, EventArgs e) {
            Filtru = null;
            DialogResult = DialogResult.OK;
        }

    }
}
