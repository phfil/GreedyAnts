using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreedyAnts
{
    public partial class GUIStartmenu : Form
    {
        public GUIStartmenu()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            GUIAntAlgorithm form2 = new GUIAntAlgorithm();
            form2.Show();
            this.Hide();
        }
    }
}
