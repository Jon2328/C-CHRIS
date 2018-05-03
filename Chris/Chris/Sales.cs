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
    public partial class Sales : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand comm = new SqlCommand();
        string connstring = @"Data Source=JON-PC\SQLEXPRESS;Initial Catalog=WP2018mayA;Integrated Security=True";
        public Sales()
        {
            InitializeComponent();
            conn = new SqlConnection(connstring);
            SqlDataAdapter da = new SqlDataAdapter("Select Book_id,Book_Title,Book_Category,Book_Author,Book_Stock,Book_Cost from Stock_book WHERE book_status != 'ordered'", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connstring);
            SqlDataAdapter da = new SqlDataAdapter("Select Book_id,Book_Title,Book_Category,Book_Author,Book_Stock,Book_Cost from Stock_book WHERE book_status != 'ordered'", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            conn = new SqlConnection(connstring);
            conn.Open();
            string sqlstr10 = "Select Book_id,Book_Title,Book_Category,Book_Author,Book_Stock,Book_Cost,Book_Status from Stock_book WHERE book_status != 'ordered' ";

            if (!String.IsNullOrEmpty(textBox1.Text))
            {

                sqlstr10 = sqlstr10 + " AND Book_Id LIKE '" + textBox1.Text + "'";

            }

            if (!String.IsNullOrEmpty(textBox2.Text))
            {
                
               
                
                    sqlstr10 = sqlstr10 + " AND Book_Title LIKE '" + textBox2.Text + "'";

                


            }

           /* if (!String.IsNullOrEmpty(textBox7.Text))
            {
                
                
                
                    sqlstr10 = sqlstr10 + " AND Book_status LIKE '" + textBox7.Text + "'";

                


            }*/



           
            SqlDataAdapter da = new SqlDataAdapter(sqlstr10, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            textBox4.Text = (dt.Rows[0]["Book_Cost"]).ToString();
            textBox6.Text = (dt.Rows[0]["Book_Stock"]).ToString();
            textBox7.Text = (dt.Rows[0]["Book_Status"]).ToString();

            try
            {
                int a = int.Parse(textBox3.Text);
                int b = int.Parse(textBox4.Text);
                textBox5.Text = (a * b).ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please fill in count,count has been set to 1");
                textBox3.Text = "1";
                int a = int.Parse(textBox3.Text);
                int b = int.Parse(textBox4.Text.ToString());
                textBox5.Text = (a * b).ToString();
            }

           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connstring);
            conn.Open();

            if (String.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.Text = "1";
            }

            string sqlstr = "SELECT TOP 1 * FROM report_book" +
            " ORDER BY CAST(Sales_id AS INT) DESC";
            string sqlstr15 = "select Order_Book.Order_Id from order_Book where Book_Id LIKE '"+textBox1.Text+"'";
            string sqlstr20 = "select order_cost from order_book ";
            string sqlstr25 = "select book_cost from stock_book ";

            if (!String.IsNullOrEmpty(textBox1.Text))
            {

                sqlstr20 = sqlstr20 + " WHERE Book_Id LIKE '" + textBox1.Text + "'";
                sqlstr25 = sqlstr25 + " WHERE Book_Id LIKE '" + textBox1.Text + "'";

            }

            if (!String.IsNullOrEmpty(textBox2.Text))
            {
                if (String.IsNullOrEmpty(textBox1.Text))
                {
                    sqlstr20 = sqlstr20 + " WHERE Book_Title LIKE '" + textBox2.Text + "'";
                    sqlstr25 = sqlstr25 + " WHERE Book_Title LIKE '" + textBox2.Text + "'";
                }
                else
                {
                    sqlstr20 = sqlstr20 + " AND Book_Title LIKE '" + textBox2.Text + "'";
                    sqlstr25 = sqlstr25 + " AND Book_Title LIKE '" + textBox2.Text + "'";
                }
            }
            
            SqlDataAdapter dc = new SqlDataAdapter(sqlstr20, conn);
            DataTable dg = new DataTable();
            dc.Fill(dg);
            int ordercost = Convert.ToInt32(dg.Rows[0]["Order_cost"]);

            SqlDataAdapter dd = new SqlDataAdapter(sqlstr25, conn);
            DataTable df = new DataTable();
            dd.Fill(df);
            int bookcost = Convert.ToInt32(df.Rows[0]["book_cost"]);

            int profit = (bookcost * int.Parse(textBox3.Text)) - (ordercost * int.Parse(textBox3.Text)) ;


            SqlDataAdapter da = new SqlDataAdapter(sqlstr, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            String IDS = (dt.Rows[0]["sales_id"].ToString());
            int ID = int.Parse(IDS);
            ID = ID + 1;

            SqlDataAdapter db = new SqlDataAdapter(sqlstr15, conn);
            DataTable dr = new DataTable();
            db.Fill(dr);
            String IDS1 = (dt.Rows[0]["Order_id"].ToString());
            int ID1 = int.Parse(IDS1);
            

            





            string sqlstr10;
            sqlstr10 = "Update Stock_Book SET ";
            sqlstr10 = sqlstr10 + "Book_Stock = Book_Stock - ";

            if (!String.IsNullOrEmpty(textBox3.Text))
            {
                sqlstr10 = sqlstr10 + textBox3.Text;


            }
            if (!String.IsNullOrEmpty(textBox1.Text))
            {

                sqlstr10 = sqlstr10 +  " WHERE Book_Id LIKE '" + textBox1.Text + "'";

            }

            if (!String.IsNullOrEmpty(textBox2.Text))
            {
                if (String.IsNullOrEmpty(textBox1.Text))
                {
                    sqlstr10 = sqlstr10 + " WHERE Book_Title LIKE '" + textBox2.Text + "'";

                }
                else
                {
                    sqlstr10 = sqlstr10 + " AND Book_Title LIKE '" + textBox2.Text + "'";

                }
            }
            sqlstr10 = sqlstr10 + " AND Book_Stock > 0";
           
            comm = new SqlCommand(sqlstr10, conn);

            string sqlstr5 = "insert into report_book values (";
            sqlstr5 = sqlstr5 + "'" + ID + "',";
            sqlstr5 = sqlstr5 + "'" + ID1 + "',";
            sqlstr5 = sqlstr5 + "'" + textBox1.Text + "',";
            sqlstr5 = sqlstr5 + "'" + textBox3.Text + "',";
            sqlstr5 = sqlstr5 + "'" + DateTime.Today.ToString("yyyy-MM-dd") + "',";
            sqlstr5 = sqlstr5 + "'" + profit + "')";

            try
            {
                comm.ExecuteNonQuery();
                MessageBox.Show("Sales processed");
               // button4.PerformClick();
               
                
            }
            catch
            {
                MessageBox.Show("Sales Error");
            }
            comm = new SqlCommand(sqlstr5, conn);
            MessageBox.Show(sqlstr5);
            try
            {
                comm.ExecuteNonQuery();
                MessageBox.Show("Sales recorded");
                button4.PerformClick();

            }
            catch
            {
                MessageBox.Show("Sales record Error");
            }
            finally
            {
               
                conn.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }
    }
}
