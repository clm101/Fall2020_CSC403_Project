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
    public partial class GameOver : Form
    {
        
        public SoundPlayer Ending_Strike = new SoundPlayer(Properties.Resources.Fall);
        public SoundPlayer BGM = new SoundPlayer(Properties.Resources.Bassy);

        public GameOver()
        {
            InitializeComponent();
            Ending_Strike.Play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string resourcesPath = Application.StartupPath + "\\..\\..\\Resources";
            pictureBox1.Image = new Bitmap(resourcesPath + "\\Game_Over_Bounce.gif");
            BGM.PlayLooping();
            timer1.Enabled = false;
        }
    }
}
