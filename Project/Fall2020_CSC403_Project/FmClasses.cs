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
        public FrmLevel1 level; 
        public FmClasses()
        {
            InitializeComponent();
        }

        
     
        
        /*Basic Class*/
        private void button1_Click(object sender, EventArgs e)
        {
            level = new FrmLevel1();
            level.character_class = 0;
            level.Show();
            
            this.Close();             
          
        }

        /*Paladin Class*/
        private void button2_Click(object sender, EventArgs e)
        {
            level = new FrmLevel1();
            level.character_class = 1;
            
            level.Show();
            this.Close();

        }


        /*Monk Class*/
        private void button3_Click(object sender, EventArgs e)
        {
            level = new FrmLevel1();
            level.character_class = 2;
            level.Show();
            this.Close();

        }


        /*Thief Class*/
        private void button4_Click(object sender, EventArgs e)
        {
            level = new FrmLevel1();
            level.character_class = 3;
            level.Show();
            this.Close(); 

        }
    }
}
