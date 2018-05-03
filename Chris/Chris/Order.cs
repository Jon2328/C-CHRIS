using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Chris
{
    public partial class Order : Form
    {

        SqlConnection conn = new SqlConnection();
        SqlCommand comm = new SqlCommand();
        string connstring = @"Data Source=JON-PC\SQLEXPRESS;Initial Catalog=WP2018mayA;Integrated Security=True";
        public Order()
        {
            InitializeComponent();
            conn = new SqlConnection(connstring);
            SqlDataAdapter da = new SqlDataAdapter("Select * from Order_book", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            label10.Hide();
            label13.Hide();
            button5.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 stock = new Form1();
            stock.Show();
            this.Close();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connstring);
            SqlDataAdapter da = new SqlDataAdapter("Select * from Order_book", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            
            string sqlstr10 = "SELECT TOP 1 * FROM Stock_book"+
            " ORDER BY CAST(Book_id AS INT) DESC";
            SqlDataAdapter da = new SqlDataAdapter(sqlstr10, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            String IDS = (dt.Rows[0]["Book_id"].ToString());
            int ID = int.Parse(IDS);
            ID = ID+1;

            string sqlstr5 = "insert into Stock_book values (";
            sqlstr5 = sqlstr5 + "'" + ID + "',";
            sqlstr5 = sqlstr5 + "'" + textBox3.Text + "',";
            sqlstr5 = sqlstr5 + "'" + textBox4.Text + "',";
            sqlstr5 = sqlstr5 + "'',";
            sqlstr5 = sqlstr5 + "'',";
            sqlstr5 = sqlstr5 + "'',";
            sqlstr5 = sqlstr5 + "'" + textBox5.Text + "',";
            sqlstr5 = sqlstr5 + "'" + textBox6.Text + "',";
            sqlstr5 = sqlstr5 + "'" + textBox8.Text + "',";
            sqlstr5 = sqlstr5 + "'',";
            sqlstr5 = sqlstr5 + "'" + "Ordered" + "')";

            string sqlstr = "insert into Order_book values (";
            sqlstr = sqlstr + "'" + textBox1.Text + "',";
            sqlstr = sqlstr + "'" + ID + "',";
            sqlstr = sqlstr + "'" + textBox3.Text + "',";
            sqlstr = sqlstr + "'" + textBox4.Text + "',";
            sqlstr = sqlstr + "'" + textBox5.Text + "',";
            sqlstr = sqlstr + "'" + textBox6.Text + "',";
            sqlstr = sqlstr + "'" + textBox7.Text + "',";
            sqlstr = sqlstr + "'" + textBox8.Text + "')";

            

            comm = new SqlCommand(sqlstr5, conn);

            try
            {
                comm.ExecuteNonQuery();
                MessageBox.Show("Updated in Stock Book");
            }
            catch
            {
                MessageBox.Show("Not Updated in Stock Book");
            }
            comm = new SqlCommand(sqlstr, conn);


            try
            {
                comm.ExecuteNonQuery();
                MessageBox.Show("Placed");
            }
            catch
            {
                MessageBox.Show("Not Placed , Book Id must exist in Stock book\nand check Order ID already exist");
            }
            finally
            {
                conn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            string sqlstr = "Update Stock_Book SET ";
            string sqlstr5 = "select Book_Id from Order_Book ";
            string sqlstr10 = "UPDATE Order_Book SET ";


                sqlstr10 = sqlstr10 + "Order_Count = '0'";
           



            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                sqlstr10 = sqlstr10 + "WHERE Order_Id LIKE '" + textBox1.Text + "'";
                sqlstr5 = sqlstr5 + "WHERE Order_Id LIKE '" + textBox1.Text + "'";

            }
            SqlDataAdapter da = new SqlDataAdapter(sqlstr5, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            String IDS = (dt.Rows[0]["Book_id"].ToString());
            int ID = int.Parse(IDS);
            
            sqlstr = sqlstr + " Book_Status = 'Received' WHERE Book_Id = '"+ID+"'";
            comm = new SqlCommand(sqlstr10, conn);

            try
            {
                comm.ExecuteNonQuery();
                MessageBox.Show("Received");
            }
            catch
            {
                MessageBox.Show("Not Received");
            }

            comm = new SqlCommand(sqlstr, conn);
           
            try
            {
                comm.ExecuteNonQuery();
                MessageBox.Show("Stock status updated");
            }
            catch
            {
                MessageBox.Show("Stock status not updated");
            }


            finally
            {
                conn.Close();
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                label10.Show();
                button5.Show();
                label13.Show();
                
            }
            else if (checkBox1.Checked == false)
            {
                label10.Hide();
                button5.Hide();
                label13.Hide();
                
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connstring);
            conn.Open();

            string sqlstr10 = "UPDATE Order_Book SET ";


            if (!String.IsNullOrEmpty(textBox2.Text))
            {

                sqlstr10 = sqlstr10 + "Book_Id = '" + textBox2.Text + "'";
            }
            if (!String.IsNullOrEmpty(textBox3.Text))
            {

                sqlstr10 = sqlstr10 + "Book_Title = '" + textBox3.Text + "'";
            }
            if (!String.IsNullOrEmpty(textBox4.Text))
            {

                sqlstr10 = sqlstr10 + "Book_Category = '" + textBox4.Text + "'";
            }
            if (!String.IsNullOrEmpty(textBox5.Text))
            {

                sqlstr10 = sqlstr10 + "Book_ISBN = '" + textBox5.Text + "'";
            }
           
            if (!String.IsNullOrEmpty(textBox6.Text))
            {

                sqlstr10 = sqlstr10 + "Book_Supplier = '" + textBox6.Text + "'";
            }
            if (!String.IsNullOrEmpty(textBox7.Text))
            {

                sqlstr10 = sqlstr10 + "Order_cost = '" + textBox7.Text + "'";
            }
            if (!String.IsNullOrEmpty(textBox8.Text))
            {

                sqlstr10 = sqlstr10 + "Order_count = '" + textBox8.Text + "'";
            }



            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                sqlstr10 = sqlstr10 + " WHERE Order_Id LIKE '" + textBox1.Text + "'";

            }

            comm = new SqlCommand(sqlstr10, conn);

            try
            {
                comm.ExecuteNonQuery();
                MessageBox.Show("Edited");
            }
            catch
            {
                MessageBox.Show("Not Edited");
            }
            finally
            {
                conn.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connstring);
            conn.Open();

            string sqlstr10 = "Select * from Order_book where ";
            //char last = StrNo[StrNo.Length - 1];


            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                sqlstr10 = sqlstr10 + "Order_Id LIKE '" + textBox1.Text + "'";

            }
            if (!String.IsNullOrEmpty(textBox2.Text))
            {
                char last = sqlstr10[sqlstr10.Length - 2];
                if (last != 'D')
                {
                    sqlstr10 = sqlstr10 + " AND ";
                }

                sqlstr10 = sqlstr10 + "Book_Id LIKE '" + textBox2.Text + "'";

            }
            if (!String.IsNullOrEmpty(textBox3.Text))
            {
                char last = sqlstr10[sqlstr10.Length - 2];
                if (last != 'D')
                {
                    sqlstr10 = sqlstr10 + " AND ";
                }

                sqlstr10 = sqlstr10 + "Book_Title LIKE '" + textBox3.Text + "'";

            }
            if (!String.IsNullOrEmpty(textBox4.Text))
            {
                char last = sqlstr10[sqlstr10.Length - 2];
                if (last != 'D')
                {
                    sqlstr10 = sqlstr10 + " AND ";
                }

                sqlstr10 = sqlstr10 + "Book_Category LIKE '" + textBox4.Text + "'";

            }
            if (!String.IsNullOrEmpty(textBox5.Text))
            {
                char last = sqlstr10[sqlstr10.Length - 2];
                if (last != 'D')
                {
                    sqlstr10 = sqlstr10 + " AND ";
                }

                sqlstr10 = sqlstr10 + "Book_ISBN LIKE '" + textBox5.Text + "'";

            }
           
            if (!String.IsNullOrEmpty(textBox6.Text))
            {
                char last = sqlstr10[sqlstr10.Length - 2];
                if (last != 'D')
                {
                    sqlstr10 = sqlstr10 + " AND ";
                }

                sqlstr10 = sqlstr10 + "Book_Supplier LIKE '" + textBox6.Text + "'";

            }
            if (!String.IsNullOrEmpty(textBox7.Text))
            {
                char last = sqlstr10[sqlstr10.Length - 2];
                if (last != 'D')
                {
                    sqlstr10 = sqlstr10 + " AND ";
                }

                sqlstr10 = sqlstr10 + "Order_Cost LIKE '" + textBox7.Text + "'";

            }
            if (!String.IsNullOrEmpty(textBox8.Text))
            {
                char last = sqlstr10[sqlstr10.Length - 2];
                if (last != 'D')
                {
                    sqlstr10 = sqlstr10 + " AND ";
                }

                sqlstr10 = sqlstr10 + "Order_Count LIKE '" + textBox8.Text + "'";

            }





            SqlDataAdapter da = new SqlDataAdapter(sqlstr10, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;


           

            try
            {
                comm.ExecuteNonQuery();


            }
            catch
            {
               // MessageBox.Show("Not Found");
            }
            finally
            {
                conn.Close();
            }
        }

        private void Order_Load(object sender, EventArgs e)
        {

        }
    }
}
