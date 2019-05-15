using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using Npgsql;

namespace ZijaevPV
{
    public partial class addU : Form
    {

        string connStr = "Server=localhost;Port=5432;User=postgres;Password=Qwertasdfum12;Database=qwertyuio;";

        public addU()
        {
            InitializeComponent();

            checkedListBox1.Items.Clear();
            string q = "SELECT name_e FROM public.elements_storage where type_of_e = '" + comboBox1.Text + "'";
            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            NpgsqlCommand SqlCommand = new NpgsqlCommand(q, conn);
            conn.Open();
            using (NpgsqlDataReader qqqq = SqlCommand.ExecuteReader())
            {
                //if (qqq.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in qqqq)
                    {
                        checkedListBox1.Items.Add(Convert.ToString(dbDataRecord["name_e"]));
                    }
                }
            }
            conn.Close();
        }

        private void add_B_Click(object sender, EventArgs e)
        {
            string q = "INSERT INTO public.vulnerability(" +
                "name_v, object_v, privacy_violation, integrity_violation, " +
                "availability_violation, cvss_v3_rating, description_v, number_v) " +
                "VALUES ('" + name_TB.Text + "', '" + comboBox1.Text + "', " + ((checkBox1.Checked) ? "1" : "0") + ", " + ((checkBox2.Checked) ? "1" : "0") + ", " +
                "" + ((checkBox3.Checked) ? "1" : "0") + ", " + cvss_ud.Value.ToString().Replace(",", ".") + ", '" + textBox1.Text + "', (select case when (max(number_v)) is null then 0 else (max(number_v)+1) end from vulnerability));";
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                q += "\n\nINSERT INTO public.e_v_whose_vulnerability (number_e, number_v) " +
                    "VALUES ((select number_e from elements_storage where name_e = '" + checkedListBox1.CheckedItems[i].ToString() + "')" +
                    ", (select number_v from vulnerability where name_v = '" + name_TB.Text + "'));";
            }
            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            NpgsqlCommand command2;
            command2 = new NpgsqlCommand(q, conn);
            conn.Open();
            command2.ExecuteNonQuery();
            conn.Close();

            Close();
        }

        private void close_B_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            string q = "SELECT name_e FROM public.elements_storage where type_of_e = '" + comboBox1.Text + "'";
            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            NpgsqlCommand SqlCommand = new NpgsqlCommand(q, conn);
            conn.Open();
            using (NpgsqlDataReader qqqq = SqlCommand.ExecuteReader())
            {
                //if (qqq.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in qqqq)
                    {
                        checkedListBox1.Items.Add(Convert.ToString(dbDataRecord["name_e"]));
                    }
                }
            }
            conn.Close();
        }
    }
}
