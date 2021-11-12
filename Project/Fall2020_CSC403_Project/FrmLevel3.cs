using Fall2020_CSC403_Project.code;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Media;
using System.Windows.Media;

namespace Fall2020_CSC403_Project {
    public partial class FrmLevel3 : Form
    {
        private Player player;
        public CharacterType characterType;
        private Character[] walls;
        private Enemy[] LevelEnemies;
        private Character door;
        private Character heart;
        private DateTime timeBegin;
        private FrmBattle frmBattle;
        public SoundPlayer BGM = new SoundPlayer(Properties.Resources.Girl_Power_Dungeon_Theme_2);
        public bool moving = false;
        public Random rd = new Random();
        public bool combat = false;

        public FrmLevel3()
        {
            InitializeComponent();

        }

        private void FrmLevel_Load(object sender, EventArgs e)
        {
            const int PADDING = 7;
            const int NUM_WALLS = 13;

            // Instantiate player sprite
            player = Game.player;
            player.set_position(picPlayer.Location.X, picPlayer.Location.Y);
            picPlayer.Image = player.downIdle;

            door = new Character(CreatePosition(picDoor), CreateCollider(picDoor, PADDING));
            heart = new Character(CreatePosition(picHealth), CreateCollider(picHealth, PADDING));

            // Instantiate enemies
            string resourcesPath = Application.StartupPath + "\\..\\..\\Resources";

            Enemy stalker = new Enemy(CreatePosition(stalkerSprite), CreateCollider(stalkerSprite, PADDING), new Point(800, 200), new Point(800, 500), 4);
            stalker.set_battle_image(new Bitmap(resourcesPath + "\\Stalker.png"));
            stalker.set_sprite_image(Controls.Find("stalkerSprite", true)[0] as PictureBox);

            Enemy batastrophe = new Enemy(CreatePosition(batastropheSprite), CreateCollider(batastropheSprite, PADDING), new Point(150, 217), new Point(150, 500), 4);
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

            BGM.Play();
            timeBegin = DateTime.Now;
        }

        private Vector2 CreatePosition(PictureBox pic)
        {
            return new Vector2(pic.Location.X, pic.Location.Y);
        }

        private void Music_restarter_Tick(object sender, EventArgs e)
        {
            
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
                        FrmLevel4 f4 = new FrmLevel4();
                        f4.Show();
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

        private void picWall3_Click(object sender, EventArgs e)
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
            picPlayer.Image = player.downIdle;
            enemy.MoveBack();
            frmBattle = FrmBattle.GetInstance(enemy);
            moving = false;
            combat = true;
            frmBattle.ShowDialog();
        }

        private void FrmLevel_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    combat = true;
                    VerifyExit e3 = new VerifyExit();
                    e3.Show(this);
                    break;
                        
                case Keys.Left:
                    if (!moving)
                    {
                        picPlayer.Image = player.left;
                        combat = false;
                        moving = true;
                    }
                    player.GoLeft();
                    break;

                case Keys.Right:
                    if (!moving)
                    {
                        picPlayer.Image = player.right;
                        combat = false;
                        moving = true;
                    }
                    player.GoRight();
                    break;

                case Keys.Up:
                    if (!moving)
                    {
                        picPlayer.Image = player.up;
                        combat = false;
                        moving = true;
                    }
                    player.GoUp();
                    break;

                case Keys.Down:
                    if (!moving)
                    {
                        picPlayer.Image = player.down;
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
                    picPlayer.Image = player.leftIdle;
                    moving = false;
                    player.ResetMoveSpeed();
                    break;

                case Keys.Right:
                    picPlayer.Image = player.rightIdle;
                    moving = false;
                    player.ResetMoveSpeed();
                    break;

                case Keys.Up:
                    picPlayer.Image = player.upIdle;
                    player.ResetMoveSpeed();
                    moving = false;
                    break;

                case Keys.Down:
                    picPlayer.Image = player.downIdle;
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
