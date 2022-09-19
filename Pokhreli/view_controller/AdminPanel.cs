using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pokhreli.view_controller;
using System.Threading;
//using FoodieCore.view_controller;

namespace Pokhreli.view_controller
{
    public partial class AdminPanel : Form
    {
        DataTable guestlist;
        module.guestEntry ge;
        public AdminPanel()
        {
            InitializeComponent();
            guestlist = new DataTable();
            ge = new module.guestEntry();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void AdminPanel_Load(object sender, EventArgs e)
        {

            Task<DataTable> getallguest = new Task<DataTable>(ge.getallguests);
            getallguest.Start();
                   
            loadpanel("Home");
            guestlist = await getallguest;

         

        }

        public void loadpanel(String name)
        {
            panel4.Controls.Clear();
            if (name == "Home")   
            {
                Home h = new Home();
              // bunifuTileButton1.BackColor=Color.CornflowerBlue;
                highliter.Top = bunifuImageButton2.Top;
                h.TopLevel = false;
                panel4.Controls.Add(h);
                h.Dock = DockStyle.Fill;
                h.Show();


            }
            else if (name == "GuestBill")
            {
                GuestBill gb = new GuestBill();
                highliter.Top = bunifuImageButton8.Top;
                // bunifuTileButton4.BackColor = Color.CornflowerBlue;
                gb.TopLevel = false;
                panel4.Controls.Add(gb);
                gb.Dock = DockStyle.Fill;
                gb.Show();

            }
            else if (name == "Stock")
            {

                
                ViewStock stock = new ViewStock();
                highliter.Top = bunifuImageButton3.Top;
                stock.TopLevel = false;
                panel4.Controls.Add(stock);
                stock.Dock = DockStyle.Fill;
                stock.Show();
              


            }
            else if (name == "Product")
            {


                ViewMyProducts prod = new ViewMyProducts();
                highliter.Top = bunifuImageButton4.Top;
                prod.TopLevel = false;
                panel4.Controls.Add(prod);
                prod.Dock = DockStyle.Fill;
                prod.Show();



            }
            else if (name == "Expenses")
            {


                ViewExpenses exp = new ViewExpenses();
                highliter.Top = bunifuImageButton9.Top;
                exp.TopLevel = false;
                panel4.Controls.Add(exp);
                exp.Dock = DockStyle.Fill;
                exp.Show();



            }
            else if (name == "Tables")
            {


                MyTables exp = new MyTables();
                highliter.Top = bunifuImageButton7.Top;
                exp.TopLevel = false;
                panel4.Controls.Add(exp);
                exp.Dock = DockStyle.Fill;
                exp.Show();



            }
            else if (name == "Rooms")
            {


                Room exp = new Room();
                highliter.Top = bunifuImageButton5.Top;
                exp.TopLevel = false;
                panel4.Controls.Add(exp);
                exp.Dock = DockStyle.Fill;
                exp.Show();



            }
            else if (name == "Guestentry")
            {


                GuestEntry exp = new GuestEntry();
                highliter.Top = bunifuImageButton6.Top;
                exp.TopLevel = false;
                panel4.Controls.Add(exp);
                exp.Dock = DockStyle.Fill;
                exp.Show();



            }

            else
            {
                ViewData vd = new ViewData();
               // bunifuTileButton4.BackColor = Color.CornflowerBlue; ;
                highliter.Top = bunifuImageButton10.Top;
                vd.TopLevel = false;
                panel4.Controls.Add(vd);
                vd.Dock = DockStyle.Fill;
                vd.Show();


            }

        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            loadpanel("Home");

        }

      

        private void bunifuTileButton4_Click(object sender, EventArgs e)
        {
            loadpanel("GuestBill");

        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            loadpanel("View");
        }

       

        private void bunifuTileButton5_Click(object sender, EventArgs e)
        {
            loadpanel("Room");
        }

        private void bunifuTileButton6_Click(object sender, EventArgs e)
        {
            loadpanel("Stock");
        }

        private void bunifuTileButton7_Click(object sender, EventArgs e)
        {
            loadpanel("Product");
        }

        private void bunifuTileButton8_Click(object sender, EventArgs e)
        {
            loadpanel("Expenses");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyTables mt = new MyTables();
            mt.ShowDialog();
        }

        private void bunifuTileButton9_Click(object sender, EventArgs e)
        {
            loadpanel("Tables");
        }

        private void bunifuTileButton2_Click_1(object sender, EventArgs e)
        {
            loadpanel("Guestentry");
        }

        private void bunifuTileButton5_Click_1(object sender, EventArgs e)
        {
            loadpanel("Rooms");
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            loadpanel("Home");
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            loadpanel("Stock");

        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            loadpanel("Product");
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            loadpanel("Rooms");
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            loadpanel("Guestentry");
        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            loadpanel("Tables");
        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            loadpanel("GuestBill");
        }

        private void bunifuImageButton9_Click(object sender, EventArgs e)
        {
            loadpanel("Expenses");
        }

        private void bunifuImageButton10_Click(object sender, EventArgs e)
        {
            loadpanel("View");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
