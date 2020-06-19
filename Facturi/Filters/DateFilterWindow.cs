using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Filters {
    public partial class DateFilterWindow : Form {

        public DateTime[] Filtru { get; private set; }

        public DateFilterWindow() {
            InitializeComponent();
        } 
        private void DateFilterWindow_ShowAtMouse(object sender, EventArgs e) => SetBounds(Cursor.Position.X + 1, Cursor.Position.Y + 1, this.Width, this.Height);
        private void dateTimePickers_ValueChanged(object sender, EventArgs e) => maxDateTimePicker.MinDate = minDateTimePicker.Value.AddDays(1);

        public DialogResult Show(DateTime[] filtru) {
            if (filtru == null || filtru.Length != 2) {
                minDateTimePicker.Value = new DateTime(1970,1,1);
                maxDateTimePicker.Value = new DateTime(9000, 1, 1);
            } else { 
                minDateTimePicker.Value = filtru[0];
                minDateTimePicker.Value = filtru[1];
            } 

            return ShowDialog();
        }

        private void cancelButton_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
        private void okButton_Click(object sender, EventArgs e) {
            Filtru = new DateTime[] { minDateTimePicker.Value, maxDateTimePicker.Value };
            DialogResult = DialogResult.OK;
        }
        private void resetButton_Click(object sender, EventArgs e) {
            Filtru = null;
            DialogResult = DialogResult.OK;
        }
    
    }
}
