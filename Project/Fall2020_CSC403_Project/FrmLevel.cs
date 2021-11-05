using Fall2020_CSC403_Project.code;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Media;
using System.Windows.Media;

namespace Fall2020_CSC403_Project {
    public partial class FrmLevel : Form
    {
        private Player player;
        public int character_class = 0;

        private Enemy enemyPoisonPacket;
        private Enemy bossKoolaid;
        private Enemy enemyCheeto;
        private Character[] walls;

        private DateTime timeBegin;
        private FrmBattle frmBattle;
        private int frames = 0;
        public Bitmap L, LI, R, RI, U, UI, D, DI;
        public SoundPlayer BGM = new SoundPlayer(Properties.Resources.Girl_Power_Dungeon_Theme_2);
        public bool moving = false;

        //public SoundPlayer Footprints = new SoundPlayer(Properties.Resources.Step);

        public FrmLevel()
        {
            InitializeComponent();
        }

        private void FrmLevel_Load(object sender, EventArgs e)
        {
            const int PADDING = 7;
            const int NUM_WALLS = 13;            

            player = new Player(CreatePosition(picPlayer), CreateCollider(picPlayer, PADDING));
            bossKoolaid = new Enemy(CreatePosition(picBossKoolAid), CreateCollider(picBossKoolAid, PADDING));
            enemyPoisonPacket = new Enemy(CreatePosition(picEnemyPoisonPacket), CreateCollider(picEnemyPoisonPacket, PADDING));
            enemyCheeto = new Enemy(CreatePosition(picEnemyCheeto), CreateCollider(picEnemyCheeto, PADDING));
            string resourcesPath = Application.StartupPath + "\\..\\..\\Resources";
            BGM.Play();

            if (character_class == 0)
            {
                L = new Bitmap(resourcesPath + "\\OG_L.gif");
                LI = new Bitmap(resourcesPath + "\\OG_LI.gif"); //new Bitmap(Properties.Resources.OG_L);.OG_LI);
                RI = new Bitmap(resourcesPath + "\\OG_RI.gif"); //new Bitmap(Properties.Resources.OG_L);.OG_RI);
                R = new Bitmap(resourcesPath + "\\OG_R.gif"); //new Bitmap(Properties.Resources.OG_L);.OG_R);
                U = new Bitmap(resourcesPath + "\\OG_U.gif"); //new Bitmap(Properties.Resources.OG_L);.OG_U);
                UI = new Bitmap(resourcesPath + "\\OG_UI.gif"); //new Bitmap(Properties.Resources.OG_L);.OG_UI);
                D = new Bitmap(resourcesPath + "\\OG_D.gif"); //new Bitmap(Properties.Resources.OG_L);.OG_D);
                DI = new Bitmap(resourcesPath + "\\OG_DI.gif"); //new Bitmap(Properties.Resources.OG_L);.OG_DI);
            }
            if (character_class == 1)
            {
                L = new Bitmap(resourcesPath + "\\AM_L.gif"); //new Bitmap(Properties.Resources.AM_L);.AM_L);
                LI = new Bitmap(resourcesPath + "\\AM_LI.gif"); //new Bitmap(Properties.Resources.AM_L);.AM_LI);
                R = new Bitmap(resourcesPath + "\\AM_R.gif"); //new Bitmap(Properties.Resources.AM_L);.AM_R);
                RI = new Bitmap(resourcesPath + "\\AM_RI.gif"); //new Bitmap(Properties.Resources.AM_L);.AM_RI);
                U = new Bitmap(resourcesPath + "\\AM_U.gif"); //new Bitmap(Properties.Resources.AM_L);.AM_U);
                UI = new Bitmap(resourcesPath + "\\AM_UI.gif"); //new Bitmap(Properties.Resources.AM_L);.AM_UI);
                D = new Bitmap(resourcesPath + "\\AM_D.gif"); //new Bitmap(Properties.Resources.AM_L);.AM_D);
                DI = new Bitmap(resourcesPath + "\\AM_DI.gif"); //new Bitmap(Properties.Resources.AM_L);.AM_DI);
            }
            if (character_class == 2)
            {
                L = new Bitmap(resourcesPath + "\\MM_L.gif"); //new Bitmap(Properties.Resources.MM_L);.MM_L);
                LI = new Bitmap(resourcesPath + "\\MM_LI.gif"); //new Bitmap(Properties.Resources.MM_L);.MM_LI);
                R = new Bitmap(resourcesPath + "\\MM_R.gif"); //new Bitmap(Properties.Resources.MM_L);.MM_R);
                RI = new Bitmap(resourcesPath + "\\MM_RI.gif"); //new Bitmap(Properties.Resources.MM_L);.MM_RI);
                U = new Bitmap(resourcesPath + "\\MM_U.gif"); //new Bitmap(Properties.Resources.MM_L);.MM_U);
                UI = new Bitmap(resourcesPath + "\\MM_UI.gif"); //new Bitmap(Properties.Resources.MM_L);.MM_U);
                D = new Bitmap(resourcesPath + "\\MM_D.gif"); //new Bitmap(Properties.Resources.MM_L);.MM_D);
                DI = new Bitmap(resourcesPath + "\\MM_DI.gif"); //new Bitmap(Properties.Resources.MM_L);.MM_DI);
            }
            if (character_class == 3)
            {
                L = new Bitmap(resourcesPath + "\\TG_L.gif"); //new Bitmap(Properties.Resources.TG_L);.TG_L);
                LI = new Bitmap(resourcesPath + "\\TG_LI.gif"); //new Bitmap(Properties.Resources.TG_L);.TG_LI);
                R = new Bitmap(resourcesPath + "\\TG_R.gif"); //new Bitmap(Properties.Resources.TG_L);.TG_R);
                RI = new Bitmap(resourcesPath + "\\TG_RI.gif"); //new Bitmap(Properties.Resources.TG_L);.TG_RI);
                U = new Bitmap(resourcesPath + "\\TG_U.gif"); //new Bitmap(Properties.Resources.TG_L);.TG_U);
                UI = new Bitmap(resourcesPath + "\\TG_UI.gif"); //new Bitmap(Properties.Resources.TG_L);.TG_UI);
                D = new Bitmap(resourcesPath + "\\TG_D.gif"); //new Bitmap(Properties.Resources.TG_L);.TG_D);
                DI = new Bitmap(resourcesPath + "\\TG_DI.gif"); //new Bitmap(Properties.Resources.TG_L);.TG_DI);
            }

            bossKoolaid.Img = picBossKoolAid.BackgroundImage;
            enemyPoisonPacket.Img = picEnemyPoisonPacket.Image;
            enemyCheeto.Img = picEnemyCheeto.Image;

            //bossKoolaid.Color = Color.Red;
            //enemyPoisonPacket.Color = Color.Green;
            //enemyCheeto.Color = Color.FromArgb(255, 245, 161);
            picPlayer.Image = DI;

            walls = new Character[NUM_WALLS];
            for (int w = 0; w < NUM_WALLS; w++)
            {
                PictureBox pic = Controls.Find("picWall" + w.ToString(), true)[0] as PictureBox;
                walls[w] = new Character(CreatePosition(pic), CreateCollider(pic, PADDING));
            }

            Game.player = player;
            timeBegin = DateTime.Now;
        }

        private Vector2 CreatePosition(PictureBox pic)
        {
            return new Vector2(pic.Location.X, pic.Location.Y);
        }

        private void Music_restarter_Tick(object sender, EventArgs e)
        {
            BGM.Play();
        } 

        private Collider CreateCollider(PictureBox pic, int padding)
        {
            Rectangle rect = new Rectangle(pic.Location, new Size(pic.Size.Width - padding, pic.Size.Height - padding));
            return new Collider(rect);
        }


        private void picEnemyCheeto_Click(object sender, EventArgs e)
        {

        }


        private void tmrUpdateInGameTime_Tick(object sender, EventArgs e)
        {
            TimeSpan span = DateTime.Now - timeBegin;
            string time = span.ToString(@"hh\:mm\:ss");
            lblInGameTime.Text = "Time: " + time.ToString();
            frames++;
        }

        private void tmrPlayerMove_Tick(object sender, EventArgs e)
        {
            // move player
            player.Move();

            // check collision with walls
            if (HitAWall(player))
            {
                player.MoveBack();
            }

            // check collision with enemies
            if (HitAChar(player, enemyPoisonPacket))
            {
                Fight(enemyPoisonPacket);
            }
            else if (HitAChar(player, enemyCheeto))
            {
                Fight(enemyCheeto);
            }
            if (HitAChar(player, bossKoolaid))
            {
                Fight(bossKoolaid);
            }
            

            // update player's picture box
            picPlayer.Location = new Point((int)player.Position.x, (int)player.Position.y);
        }

        private bool HitAWall(Character c)
        {
            bool hitAWall = false;
            for (int w = 0; w < walls.Length; w++)
            {
                if (c.Collider.Intersects(walls[w].Collider))
                {
                    hitAWall = true;
                    break;
                }
            }
            return hitAWall;
        }

        private bool HitAChar(Character you, Character other)
        {
            return you.Collider.Intersects(other.Collider);
        }

        private void Fight(Enemy enemy)
        {
            player.ResetMoveSpeed();
            player.MoveBack();
            frmBattle = FrmBattle.GetInstance(enemy);
            frmBattle.Show();

            if (enemy == bossKoolaid)
            {
                frmBattle.SetupForBossBattle();
            }
        }

        private void FrmLevel_KeyDown(object sender, KeyEventArgs e)
        {
            frames++;
            switch (e.KeyCode)
            {
                case Keys.Left:
                    //what_direction = L_frames;
                    if (!moving)
                    {
                        picPlayer.Image = L;

                        moving = true;
                    }
                    player.GoLeft();
                    break;


                case Keys.Right:
                    if (!moving)
                    {
                        picPlayer.Image = R;
                        moving = true;
                    }
                    player.GoRight();
                    break;

                case Keys.Up:
                    //what_direction = U_frames;
                    if (!moving)
                    {
                        picPlayer.Image = U;
                        moving = true;
                    }
                    player.GoUp();
                    break;

                case Keys.Down:
                    //what_direction = D_frames;
                    if (!moving)
                    {
                        picPlayer.Image = D;
                        moving = true;
                    }
                    player.GoDown();

                    break;

                default:
                    player.ResetMoveSpeed();
                    frames = 0;
                    break;
            }
        }
        private void FrmLevel_KeyUp(object sender, KeyEventArgs e)
        {
            //player.ResetMoveSpeed();
            switch (e.KeyCode)
            {
                case Keys.Left:
                    picPlayer.Image = LI;
                    moving = false;
                    player.ResetMoveSpeed();
                    break;

                case Keys.Right:
                    //player.GoRight();
                    picPlayer.Image = RI;
                    moving = false;

                    ////AnimTimer.Stop();
                    player.ResetMoveSpeed();


                    break;

                case Keys.Up:
                    picPlayer.Image = UI;
                    player.ResetMoveSpeed();
                    moving = false;

                    break;

                case Keys.Down:
                    picPlayer.Image = DI;
                    moving = false;
                    player.ResetMoveSpeed();


                    break;

                default:

                    player.ResetMoveSpeed();


                    break;
            }
        }

        private void lblInGameTime_Click(object sender, EventArgs e)
        {

        }

        private void picPlayer_Click(object sender, EventArgs e)
        {

        }


    }
}
