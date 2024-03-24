using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Diagnostics.Eventing.Reader;
using Microsoft.Identity.Client;


namespace View
{
    public partial class Form1 : Form
    {
        private SqlConnection connection;
        private SqlCommand command;
        private Opit2 bookBusiness = new Opit2();
        private int editId = 0;
        private void UpdateGrid() { dataGridView1.DataSource = bookBusiness.GetAll(); 
            dataGridView1.ReadOnly = true; dataGridView1.SelectionMode = 
                DataGridViewSelectionMode.FullRowSelect; }

        public int ValidateM() 
        { 
            int flag = 0; if (textBox1.Text == "") 
            { textBox1.Focus(); errorProvider1.SetError(textBox1, 
                MessageBox.Show("Please enter title", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error).ToString()); flag = 1; } return flag; }
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                BtnShowData.Text = "Enter";
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                BtnShowData.Text = "Order";
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void BtnShowData_Click(object sender, EventArgs e)
        {
            
            if (radioButton2.Checked == true)
            {
                Book book = new Book();
                book.Title = textBox1.Text;
                book.Author = textBox2.Text;

                bookBusiness.Add(book);
            }
            if (radioButton1.Checked == true)
            {
                int id = 0;
                string title = textBox1.Text;
                double price = Convert.ToDouble(textBox4.Text);
               
            }

            

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    var item = dataGridView1.SelectedRows[0].Cells;
                    var id = int.Parse(item[0].Value.ToString());
                    editId = id; UpdateTextboxes(id); DisableSelect();
                }
            }
        }
            private void UpdateTextboxes(int id) 
            { Book update = bookBusiness.Get(id); 
                textBox1.Text = update.Title;
                textBox2.Text = update.Author;
                textBox3.Text = update.Genre; 
                textBox4.Text = update.Price.ToString(); }
            private void DisableSelect() { dataGridView1.Enabled = false; }
            private void ResetSelect() { dataGridView1.ClearSelection(); 
                dataGridView1.Enabled = true; }
        

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            { if (ValidateM() == 1) return; 
                else errorProvider1.Clear(); 
                var title = textBox1.Text; var author = textBox2.Text;
                var genre = textBox3.Text; 
                int price = 0; int.TryParse(textBox4.Text, out price); 
                Book book = new Book(); 
                book.Title = title; 
                book.Author = author;
                book.Genre = genre; 
                book.Price = price; bookBusiness.Add(book);
                UpdateGrid();  }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            { if (dataGridView1.SelectedRows.Count > 0) 
                { var selectedRow = dataGridView1.SelectedRows[0]; 
                    var id = int.Parse(selectedRow.Cells["Id"].Value.ToString()); 
                    bookBusiness.Delete(id);
                    UpdateGrid(); 
                     }
                else { MessageBox.Show("Please select a book to delete."); 
        }
    }
}

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
       

    }



}

