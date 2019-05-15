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
    public partial class addElement : Form
    {
        string V;
        string connStr = "Server=localhost;Port=5432;User=postgres;Password=Qwertasdfum12;Database=qwertyuio;";

        public addElement(string v)
        {
            InitializeComponent();
            V = v;
            Text += " '" + v + "'";

           
        }

        private void close_B_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void add_B_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            NpgsqlCommand command2;
            string q = "INSERT INTO public.elements_storage(name_e, type_of_e, cost_e, importance_e, number_e)VALUES ('" + name_TB.Text + "', '" + V + "', " + cost_TB.Text + ", " + importance_TB.Text + ", (select case when (max(number_e)) is null then 0 else (max(number_e)+1) end from elements_storage));";//
            command2 = new NpgsqlCommand(q, conn);
            conn.Open();
            // Выполнение запроса
            command2.ExecuteNonQuery();
            conn.Close();
            Close();
        }
    }
}
