using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DataGridVieww
{
    public partial class Form1 : Form
    {
        bool flag = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Columns.Count > 0) return;
            string path = "data.dat";
            int[] nember = new int[20];
            using (BinaryReader reader = new BinaryReader(File.Open("data.dat", FileMode.Open)))
            {
                int i = 0;
                while (i < 20)
                {
                    nember[i] = reader.ReadInt32();
                    i++;
                }
                reader.Close();
            }
            int min = nember[0];
            for(int i = 0; i < nember.Length;i++)
            {
                if (min > nember[i]) min = nember[i];
            }
            for (int i = 1; i < nember.Length; i=i+2)
            {
                nember[i] = min;
            }
            var column1 = new DataGridViewColumn();
            column1.HeaderText = "";
            column1.Name = "nember";
            column1.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView1.Columns.Add(column1);
            for (int i = 0; i < 19; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1["nember", i].Value = nember[i];
            }
            dataGridView1["nember",19].Value = nember[19];
            flag = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (flag) return;
            for(int i = 0;i<20;i++)
            {
                chart1.Series["Series1"].Points.Add((int)dataGridView1["nember", i].Value);
            }
            flag = true;
        }
    }
}
