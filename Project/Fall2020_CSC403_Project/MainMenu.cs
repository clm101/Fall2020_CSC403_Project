using Fall2020_CSC403_Project.code;
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
    public partial class MainMenu : Form
        
    {
       
        public MainMenu()
        {
            InitializeComponent();



        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            //FrmLevel1 f1 = new FrmLevel1();
            FmClasses cm = new FmClasses();
            cm.Show(this);

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void Game_Over()
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string resourcesPath = Application.StartupPath + "\\..\\..\\Resources";
            pictureBox2.Image = new Bitmap(resourcesPath + "\\Fruits_Of_The Round_Title_Animation.gif");
            timer1.Enabled = false;
        }
    }
}
