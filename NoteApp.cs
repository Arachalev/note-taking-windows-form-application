using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace note_taking_app
{
    public partial class NoteApp : Form
    {

        DataTable dataTable;
        public NoteApp()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataTable = new DataTable();
            dataTable.Columns.Add("Title", typeof(string));
            dataTable.Columns.Add("Messages", typeof(string));

            MessageStore.DataSource= dataTable;

            MessageStore.Columns["Messages"].Visible = false;

            MessageStore.Columns["Title"].Width= 206;


        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtTitle.Clear();
            txtMessage.Clear();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
                dataTable.Rows.Add(txtTitle.Text, txtMessage.Text);
                txtTitle.Clear();
                txtMessage.Clear();
            
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            int index = MessageStore.CurrentCell.RowIndex;

            if(index > -1)
            {
                txtTitle.Text = dataTable.Rows[index].ItemArray[0].ToString();
                txtMessage.Text = dataTable.Rows[index].ItemArray[1].ToString();

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = MessageStore.CurrentCell.RowIndex;
            dataTable.Rows[index ].Delete();
            txtMessage.Text = "";
            txtTitle.Text = "";
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
