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

namespace Filters {
    public partial class ListFilterWindow : Form { 
        private int INDEX;

        public List<string> Filtru { get; private set; }

        public ListFilterWindow() {
            InitializeComponent();
        } 
        //private void ListFilterWindow_Hide(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
        private void ListFilterWindow_ShowAtMouse(object sender, EventArgs e) => SetBounds(Cursor.Position.X+1, Cursor.Position.Y+1,this.Width, this.Height);
        

        public DialogResult Show(ListView.ListViewItemCollection lvItems, ListView.ListViewItemCollection allItems, int index/*, int indexUnic*/ ) {
            this.INDEX = index;

            listView1.Items.Clear();
            foreach (ListViewItem itm in allItems) { 
                if (listView1.FindItemWithText(itm.SubItems[INDEX].Text) == null) {
                    listView1.Items.Add(itm.SubItems[INDEX].Text);

                    foreach (ListViewItem lvi in lvItems)
                        if (lvi.SubItems[INDEX].Text == itm.SubItems[INDEX].Text)
                            listView1.Items[listView1.Items.Count - 1].Checked = true;
                }
            }
            
            return ShowDialog();
        }

        private void cancelButton_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
        private void okButton_Click(object sender, EventArgs e) {
            if (listView1.Items.Count != 0) {
                Filtru = new List<string>();
                foreach (ListViewItem itm in listView1.Items) {
                    if (itm.Checked) {
                        Filtru.Add(itm.Text);
                    }
                }
                if (Filtru.Count() == 0) Filtru = null;
            } else Filtru = null;

            DialogResult = DialogResult.OK;
        }
        private void resetButton_Click(object sender, EventArgs e) {
            Filtru = null;
            DialogResult = DialogResult.OK;
        }

        /*private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e) {
            if (e.Item.Checked) { // afiseaza
                for (int i = 0; i < this.ALL_ITEMS.Count; i++) {
                    //MessageBox.Show(itm.SubItems[INDEX].Text);
                    if (this.ALL_ITEMS[i].SubItems[INDEX].Text == e.Item.Text) {
                        LV_ITEMS.Add(this.ALL_ITEMS[i].Text);
                        for(int j = 1;j< this.ALL_ITEMS[i].SubItems.Count;j++)
                            LV_ITEMS[LV_ITEMS.Count - 1].SubItems.Add(this.ALL_ITEMS[i].SubItems[j].Text);
                        LV_ITEMS[LV_ITEMS.Count - 1].Checked = false; 
                    }
                }
            } else { // ascunde
                foreach (ListViewItem lvi in LV_ITEMS)
                    if (lvi.SubItems[INDEX].Text == e.Item.Text)
                        LV_ITEMS.Remove(lvi); 
            }
        }*/

        public static ListView.ListViewItemCollection cloneItems(ListView.ListViewItemCollection items) {
            ListView.ListViewItemCollection newItems = new ListView.ListViewItemCollection(new ListView());

            foreach (ListViewItem listViewItem in items) 
                newItems.Add(cloneItem(listViewItem));  

            return newItems;
        }
        public static ListViewItem cloneItem(ListViewItem item) {
            ListViewItem newItem = new ListViewItem(item.Text);
            for (int i = 1; i < item.SubItems.Count; i++)
                newItem.SubItems.Add(item.SubItems[i].Text);

            return newItem;
        }

    }
}
