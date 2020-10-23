using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdonetProje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductDal productDal = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {

            GettAll();
        }

        private void GettAll()
        {
            dataGridView1.DataSource = productDal.GetAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            productDal.Added(new Product
            {
                Name = nametxt.Text,
                UnitPrice = Convert.ToDecimal(unittxt.Text),
                StockAmount = Convert.ToInt32(stocktxt.Text),


            });
            GettAll();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            nameUpdate.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            unitUpdaate.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            StockUpdate.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            productDal.Update(new Product
            {
                Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                Name = nameUpdate.Text,
                UnitPrice = Convert.ToDecimal(unitUpdaate.Text),
                StockAmount = Convert.ToInt32(StockUpdate.Text)
            });
            GettAll();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            productDal.Deleted(id);
            GettAll();
        }
    }
}
