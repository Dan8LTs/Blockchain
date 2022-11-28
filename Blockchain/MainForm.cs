using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blockchain
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private Chain _chain = new Chain();
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            _chain.Add(textBox1.Text, "User");
            foreach (var block in _chain.Blocks)
            {
                listBox1.Items.Add(block);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            listBox1.Items.AddRange(_chain.Blocks.ToArray());
        }
    }
}
