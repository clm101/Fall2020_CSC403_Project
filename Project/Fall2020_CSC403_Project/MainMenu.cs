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
using System.Media;

namespace Fall2020_CSC403_Project
{
    public partial class MainMenu : Form
        
    {
        public SoundPlayer Opening_Theme = new SoundPlayer(Properties.Resources.Starting_Something);
        public SoundPlayer Opening_SFX = new SoundPlayer(Properties.Resources.Opening_Sound_FRuits_of_the_round);
        public SoundPlayer  Gameplay_Music = new SoundPlayer(Properties.Resources.Girl_Power_Dungeon_Theme_2);
        public MainMenu()
        {
            InitializeComponent();
            Opening_SFX.Play();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            //FrmLevel1 f1 = new FrmLevel1();
            FmClasses Cm = new FmClasses();
            Cm.Show(this);
            timer2.Enabled = false;
            Gameplay_Music.PlayLooping();
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
            timer2.Enabled = true;
            Opening_Theme.Play();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Opening_Theme.Play();
        }
    }
}
