using Fall2020_CSC403_Project.code;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Media;
using System.Windows.Media;

namespace Fall2020_CSC403_Project {
    public partial class FrmLevel4 : Form
    {
        private Player player;
        public int character_class = 1;

        private Character[] walls;
        private Enemy[] LevelEnemies;
  
        private DateTime timeBegin;
        private FrmBattle frmBattle;
        public Bitmap L, LI, R, RI, U, UI, D, DI;
        public SoundPlayer BGM = new SoundPlayer(Properties.Resources.Girl_Power_Dungeon_Theme_2);
        public bool moving = false;
        public Random rd = new Random();
        public bool combat = false;

        public int Health;
        public int MaxHealth;

        public FrmLevel4()
        {
            InitializeComponent();
            //player.ClassId = character_class;
        }

        private void FrmLevel_Load(object sender, EventArgs e)
        {
            const int PADDING = 7;
            const int NUM_WALLS = 13;
            
            string resourcesPath = Application.StartupPath + "\\..\\..\\Resources";
            BGM.Play();
           // player.ClassId = character_class;
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
                //picPlayer.Img = picBossKoolAid.BackgroundImage;
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

            // Instantiate player and door
            player = new Player(CreatePosition(picPlayer), CreateCollider(picPlayer, PADDING));
            picPlayer.Image = DI;
            player.Health = Health;
            player.MaxHealth = MaxHealth;

            // Instantiate enemies
            Enemy stalker = new Enemy(CreatePosition(stalkerSprite), CreateCollider(stalkerSprite, PADDING));
            stalker.set_battle_image(new Bitmap(resourcesPath + "\\Stalker.png"));
            stalker.set_sprite_image(Controls.Find("stalkerSprite", true)[0] as PictureBox);

            Enemy batastrophe = new Enemy(CreatePosition(batastropheSprite), CreateCollider(batastropheSprite, PADDING));
            batastrophe.set_battle_image(new Bitmap(resourcesPath + "\\Batastrophe.png"));
            batastrophe.set_sprite_image(Controls.Find("batastropheSprite", true)[0] as PictureBox);

            Enemy unfathomable = new Enemy(CreatePosition(unfathomableSprite), CreateCollider(unfathomableSprite, PADDING));
            unfathomable.set_battle_image(unfathomableSprite.BackgroundImage);
            unfathomable.set_sprite_image(Controls.Find("unfathomableSprite", true)[0] as PictureBox);
            LevelEnemies = new Enemy[] { stalker, batastrophe, unfathomable }; // boss battle goes with last enemy

            // Instantiate walls
            walls = new Character[NUM_WALLS];
            for (int w = 0; w < NUM_WALLS; w++)
            {
                PictureBox pic = Controls.Find("picWall" + w.ToString(), true)[0] as PictureBox;
                walls[w] = new Character(CreatePosition(pic), CreateCollider(pic, PADDING));
            }

            Game.player = player;
            timeBegin = DateTime.Now;
            //player.ClassId = character_class;
            //player.Health = Health;
            //player.MaxHealth = MaxHealth;
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
        }

        private void tmrPlayerMove_Tick(object sender, EventArgs e)
        {
            player.Move();

            // check collision with walls
            if (HitAWall(player))
            {
                player.MoveBack();
            }

            if (!combat)
            {
                // check collision with enemies
                foreach (Enemy enemy in LevelEnemies)
                {
                    if (enemy.IsAlive && HitAChar(player, enemy))
                    {

                        Fight(enemy);
                    }
                }
            }
            // update player's picture box
            picPlayer.Location = new Point((int)player.Position.x, (int)player.Position.y);
        }

        private void Snail_detection_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Enemy enemy in LevelEnemies)
            {
                if (!enemy.IsAlive)
                {
                    enemy.Visible = false;
                }
                else
                {
                    if (!combat)
                    {
                        enemy.EnemyMove();
                    }
                }
            }
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
                picPlayer.Image = DI;
                enemy.MoveBack();
                frmBattle = FrmBattle.GetInstance(enemy, character_class);
                moving = false;
                combat = true;
                frmBattle.ShowDialog();
            

            if (enemy == LevelEnemies[LevelEnemies.Length - 1])
            {
                frmBattle.SetupForBossBattle();
            }
        }

        private void FrmLevel_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (!moving)
                    {
                        picPlayer.Image = L;
                        combat = false;
                        moving = true;
                    }
                    player.GoLeft();
                    break;

                case Keys.Right:
                    if (!moving)
                    {
                        picPlayer.Image = R;
                        combat = false;
                        moving = true;
                    }
                    player.GoRight();
                    break;

                case Keys.Up:
                    if (!moving)
                    {
                        picPlayer.Image = U;
                        combat = false;
                        moving = true;
                    }
                    player.GoUp();
                    break;

                case Keys.Down:
                    if (!moving)
                    {
                        picPlayer.Image = D;
                        combat = false;
                        moving = true;
                    }
                    player.GoDown();

                    break;

                default:
                    player.ResetMoveSpeed();
                    break;
            }
        }
        private void FrmLevel_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    picPlayer.Image = LI;
                    moving = false;
                    player.ResetMoveSpeed();
                    break;

                case Keys.Right:
                    picPlayer.Image = RI;
                    moving = false;
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
