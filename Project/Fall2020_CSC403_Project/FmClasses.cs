using Fall2020_CSC403_Project.code;
using Fall2020_CSC403_Project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project
{
    public partial class FmClasses : Form
    {
        
        public int playerClass = 0;
        public FmClasses()
        {
            InitializeComponent();
        }

        
     
        
        /*Basic Class*/
        private void button1_Click(object sender, EventArgs e)
        {
        
            playerClass = 0;
            new FrmLevel().Show();
            
            Close();             
          
        }

        /*Paladin Class*/
        private void button2_Click(object sender, EventArgs e)
        {
            playerClass = 1;
            Close();
        }


        /*Monk Class*/
        private void button3_Click(object sender, EventArgs e)
        {
            playerClass = 2;
            Close();
            Application.Run(new FrmLevel());
        }


        /*Theif Class*/
        private void button4_Click(object sender, EventArgs e)
        {
            playerClass = 3;
            Close();
            Application.Run(new FrmLevel());
        }
    }
}
