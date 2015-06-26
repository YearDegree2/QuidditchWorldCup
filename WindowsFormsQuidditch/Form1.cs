using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            ServiceReference1.ServiceClient client = new ServiceReference1.ServiceClient();
            ICollection<ServiceReference1.CompositeType> matchs = (ICollection<ServiceReference1.CompositeType>)client.GetMatchs();
            foreach (ServiceReference1.CompositeType match in matchs)
            {
                listBoxMatch.Items.Add(String.Format("{0} ({1}) : {2} {3} - {4} {5}", match.Coupe, match.Date, match.EquipeDomicile, match.ScoreEquipeDomicile, match.ScoreEquipeVisiteur, match.EquipeVisiteur));
            }
        }
    }
}
