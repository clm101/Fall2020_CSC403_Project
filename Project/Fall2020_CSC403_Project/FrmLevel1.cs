using Fall2020_CSC403_Project.code;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Media;
using System.Windows.Media;

namespace Fall2020_CSC403_Project {
    public partial class FrmLevel1 : Form
    {
        private Player player;
        public int character_class;

        private Character[] walls;
        private Enemy[] LevelEnemies;

        private Character door;
        private Character heart;

        private DateTime timeBegin;
        private FrmBattle frmBattle;
        public Bitmap L, LI, R, RI, U, UI, D, DI;
        public SoundPlayer BGM = new SoundPlayer(Properties.Resources.Girl_Power_Dungeon_Theme_2);
        public bool moving = false;
        public Random rd = new Random();
        public bool combat = false;

        public int Health;
        public int MaxHealth;

        //public SoundPlayer Footprints = new SoundPlayer(Properties.Resources.Step);

        public FrmLevel1()
        {
            InitializeComponent();
            player = Game.player;
            
        }

        private void FrmLevel_Load(object sender, EventArgs e)
        {
            const int PADDING = 7;
            const int NUM_WALLS = 11;

            string resourcesPath = Application.StartupPath + "\\..\\..\\Resources";
            player = new Player(CreatePosition(picPlayer), CreateCollider(picPlayer, PADDING));
            if (character_class == 0)
            {
                player.Health = 20;
                player.MaxHealth = 20;
                L = new Bitmap(resourcesPath + "\\OG_L.gif");
                LI = new Bitmap(resourcesPath + "\\OG_LI.gif");
                RI = new Bitmap(resourcesPath + "\\OG_RI.gif");
                R = new Bitmap(resourcesPath + "\\OG_R.gif");
                U = new Bitmap(resourcesPath + "\\OG_U.gif");
                UI = new Bitmap(resourcesPath + "\\OG_UI.gif");
                D = new Bitmap(resourcesPath + "\\OG_D.gif");
                DI = new Bitmap(resourcesPath + "\\OG_DI.gif");
            }
            if (character_class == 1)
            {
                player.Health = 25;
                player.MaxHealth = 25;
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
                player.Health = 15;
                player.MaxHealth = 15;
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
                player.Health = 10;
                player.MaxHealth = 10;
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
            picPlayer.Image = DI;
            //player.Health = 20;
           // player.MaxHealth = 20;

            door = new Character(CreatePosition(picDoor), CreateCollider(picDoor, PADDING));
            heart = new Character(CreatePosition(picHealth), CreateCollider(picHealth, PADDING));

            // Instantiate enemies
            Enemy stalker = new Enemy(CreatePosition(stalkerSprite), CreateCollider(stalkerSprite, PADDING), new Point(505, 316), new Point(788, 316));
            stalker.set_battle_image(new Bitmap(resourcesPath + "\\Stalker.png"));
            stalker.set_sprite_image(Controls.Find("stalkerSprite", true)[0] as PictureBox);

            Enemy batastrophe = new Enemy(CreatePosition(batastropheSprite), CreateCollider(batastropheSprite, PADDING));
            batastrophe.set_battle_image(new Bitmap(resourcesPath + "\\Batastrophe.png"));
            batastrophe.set_sprite_image(Controls.Find("batastropheSprite", true)[0] as PictureBox);
            LevelEnemies = new Enemy[] { stalker, batastrophe };

            // Instantiate walls
            walls = new Character[NUM_WALLS];
            for (int w = 0; w < NUM_WALLS; w++)
            {
                PictureBox pic = Controls.Find("picWall" + w.ToString(), true)[0] as PictureBox;
                walls[w] = new Character(CreatePosition(pic), CreateCollider(pic, PADDING));
            }
            
            Game.player = player;
            timeBegin = DateTime.Now;

            

            //player.Health = 20;
            //player.MaxHealth = 20;
        }

        private Vector2 CreatePosition(PictureBox pic)
        {
            return new Vector2(pic.Location.X, pic.Location.Y);
        }

        private void Music_restarter_Tick(object sender, EventArgs e)
        {
            //BGM.Play();
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

                if (picDoor.Visible)
                {
                    if (HitADoor(player, door))
                    {
                        picDoor.Visible = false;
                        combat = true;
                        this.Close();
                        FrmLevel2 f2 = new FrmLevel2();
                        f2.character_class = character_class;
                        f2.Health = player.Health;
                        f2.MaxHealth = player.MaxHealth;
                        f2.Show();
                    }
                }
                if (picHealth.Visible)
                {
                    if (HitAHeart(player, heart))
                    {
                        picHealth.Visible = false;
                        player.AlterHealth(10);
                        player.AlterMaxHealth(10);
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

        private void picEnemyPoisonPacket_Click(object sender, EventArgs e)
        {

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

        private void picWall10_Click(object sender, EventArgs e)
        {

        }

        private bool HitAChar(Character you, Character other)
        {
            return you.Collider.Intersects(other.Collider);
        }

        private bool HitADoor(Character you, Character other)
        {
            return you.Collider.Intersects(other.Collider);
        }
        private bool HitAHeart(Character you, Character other)
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
