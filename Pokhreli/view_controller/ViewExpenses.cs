//using FoodieCore.view_controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokhreli.view_controller
{
    public partial class ViewExpenses : Form
    {
        module.expenses expenses;
        DataTable records;
        public ViewExpenses()
        {
            InitializeComponent();
            expenses = new module.expenses();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Expenses exp = new Expenses();
            exp.ShowDialog();
            loaddata();


        }

        private async void ViewExpenses_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private async void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            loaddata();
        }

       public async void loaddata()
        {
            expenses.date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            Task<DataTable> loaddata = new Task<DataTable>(expenses.searchbydate);
            loaddata.Start();
            records = await loaddata;
            dataGridView1.DataSource = records;
            float sum = 0;
            foreach (DataRow dr in records.Rows)
            {

                sum += float.Parse(dr["amount"].ToString());
            }
            labeltotal.Text = "Total: Nrs " + sum;

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            //AddStock as
        }

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            AddStock ap = new AddStock();
            ap.ShowDialog();
            loaddata();
        }

        private void bunifuCustomLabel7_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

     

        private void labeltotal_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel13_Click(object sender, EventArgs e)
        {

        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                int productId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                string command = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (command.ToLower() == "delete")
                {
                    if (MessageBox.Show("Are you sure you want to delete this expense record ?  \n ", "Confirm to delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        expenses.id = productId;
                        Task<int> deleteproduct = new Task<int>(expenses.deleterecord);
                        
                        deleteproduct.Start();
                   

                        int res = await deleteproduct;
                       

                        if (res > 0)
                        {

                           // MessageBox.Show("Deleted successfully");
                            loaddata();
                        }


                    }


                }
            }





        }
    }
}
