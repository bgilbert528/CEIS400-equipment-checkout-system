using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CEIS400_ECS
{
    public partial class ConditionPromptcs : Form
    {
        private CheckoutRecord record;

        public ConditionPromptcs(ITrackable trackable, string recordID)
        {
            InitializeComponent();

            // Get the record
            record = trackable.CheckoutRecords.FirstOrDefault(r => r.RecordID == recordID);

            if (record == null)
            {
                MessageBox.Show("Record not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Optionally prefill the textbox with the current condition
            richTextBoxCondition.Text = record.Condition ?? "";
        }

        private void btnConOk_Click(object sender, EventArgs e)
        {
            // Default to "Good" if nothing entered
            record.Condition = string.IsNullOrWhiteSpace(richTextBoxCondition.Text)
                ? "Good"
                : richTextBoxCondition.Text.Trim();

            this.DialogResult = DialogResult.OK; // OK to store data
            this.Close(); // Close the form
        }
    }
}
