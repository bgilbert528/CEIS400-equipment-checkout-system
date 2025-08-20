using System.Data;

namespace CEIS400_ECS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Search the database for the given equipment's ID
            string equipID = textBox.Text;
            DatabaseAccess dbAccess = new DatabaseAccess("test"); // not sure what to pass in here so just "test" and "dbAccess" for names - Bryan
            DataTable dTable = dbAccess.Query($"SELECT * FROM Equipment WHERE ID = {equipID};");
            Console.WriteLine(dTable);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
