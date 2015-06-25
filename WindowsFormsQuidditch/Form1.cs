using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WcfServiceLibrary;

namespace WindowsFormsQuidditch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonMatch_Click(object sender, EventArgs e)
        {
            this.listBoxMatch.Visible = true;
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            ICollection<CompositeType> matchs = (ICollection<CompositeType>) client.GetMatchs();
            foreach (CompositeType match in matchs)
            {
                listBoxMatch.Items.Add(match.ToString());
            }
        }
    }
}
