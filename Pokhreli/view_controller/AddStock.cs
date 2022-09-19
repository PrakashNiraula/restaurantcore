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
    public partial class AddStock : Form
    {

        module.Ingredients stock;
        DataTable stocklist;
        float quantity;
        float newamount;
        int selected;
        public AddStock()
        {
            InitializeComponent();
            stock = new module.Ingredients();
            stocklist = new DataTable();

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void AddStock_Load(object sender, EventArgs e)
        {

            Task<DataTable> getallingredients = new Task<DataTable>(stock.getallingredients);
            getallingredients.Start();
            stocklist = await getallingredients;
            dataGridView1.DataSource = stocklist;
            panel3.Visible = false;
            //comboBox1.DataSource = stocklist;
            //comboBox1.ValueMember = "id";
            //comboBox1.DisplayMember = "name";
            //comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (stocklist.Rows.Count > 0)
            //{
               
            //    labelunit.Text = stocklist.Rows[comboBox1.SelectedIndex]["unit"].ToString();
            //    currentstock.Text = "Current Stock: " + stocklist.Rows[comboBox1.SelectedIndex]["amount"].ToString() + " "+stocklist.Rows[comboBox1.SelectedIndex]["unit"].ToString();
            //}
        }

        private void txtqty_OnValueChanged(object sender, EventArgs e)
        {
           //if(float.TryParse(txtqty.Text,out quantity))
           // {
           //    newamount = float.Parse(stocklist.Rows[comboBox1.SelectedIndex]["amount"].ToString()) + quantity;

           //     labelnewstock.Text = "New Stock: "+newamount;
           // }else
           // {
           //     labelnewstock.Text = "Invalid Amount";
           // }
        }

        private async void bunifuThinButton22_Click(object sender, EventArgs e)
        {

            //if(txtqty.Text=="" | txtqty.Text==" ")
            //{

            //    labelnewstock.Text = "Enter Amount";
            //    txtqty.Focus();
            //    return;
            //}

            //if (txtprice.Text == "" | txtprice.Text == " ")
            //{

            //    labelnewstock.Text = "Enter Cost price";
            //    txtprice.Focus();
            //    return;
            //}

            //stock.updatequery = "update ingredients set amount='"+newamount+"', updated_on='" + DateTime.Now.ToString("yyyy-MM-dd") + "' where id='" + comboBox1.SelectedValue + "'";
            //Task<int> updateamount = new Task<int>(stock.updaterecord);
            //updateamount.Start();
            // stock.addquery = "insert into purchase values(Null,'"+ stocklist.Rows[comboBox1.SelectedIndex]["name"].ToString() + "','"+ stocklist.Rows[comboBox1.SelectedIndex]["amount"].ToString() + "','"+newamount+"','"+txtprice.Text+"','"+DateTime.Now.ToString("yyyy-MM-dd")+"')";
            //Task<int> addpurchaserecord = new Task<int>(stock.addrecord);
            //addpurchaserecord.Start();
            //if(await updateamount==1 && await addpurchaserecord == 1)
            //{
            //    labelnewstock.Text = "Successfully saved record";
            //}



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int productId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                string command = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (command.ToLower() == "edit")
                {
                    selected = productId;
                    if (panel3.Visible == true)
                    {
                        panel3.Visible = false;
                        return;

                    }
                    panel3.Visible = true;
                }
            }
                   
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (panel3.Visible == true)
            {
                panel3.Visible = false;
                return;
            }
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {

        }

        private async void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            //save records
            
            stock.updatequery = "update ingredients set amount='"+ bunifuMetroTextbox1.Text+ "', updated_on='" + DateTime.Now.ToString("yyyy-MM-dd") + "' where id='" + selected + "'";
            Task<int> updateamount = new Task<int>(stock.updaterecord);
           updateamount.Start();
            var res = await updateamount;
            panel3.Visible = false;
            this.Close();







        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                int productId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                string command = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (command.ToLower() == "edit")
                {
                    selected = productId;
                    if (panel3.Visible == true)
                    {
                        panel3.Visible = false;
                        return;

                    }
                    panel3.Visible = true;
                }
            }
        }
    }
}
