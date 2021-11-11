using Fall2020_CSC403_Project.code;
using Fall2020_CSC403_Project.Properties;
using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project {
  public partial class FrmBattle : Form {
    public static FrmBattle instance = null;
    private Enemy enemy;
    private Player player;

    private FrmBattle() {
      InitializeComponent();
      player = Game.player;
    }

    public void Setup() {
      // update for this enemy
      picEnemy.BackgroundImage = enemy.Img;
      picEnemy.Refresh();
      BackColor = enemy.Color;
      picBossBattle.Visible = false;

      string resourcesPath = Application.StartupPath + "\\..\\..\\Resources";

      
      picPlayer.BackgroundImage = new Bitmap(resourcesPath + "\\Tomato_Girl_Shimmer.png");
      picEnemy.Refresh();

      // Observer pattern
      //enemy.AttackEvent += PlayerDamage;
      //player.AttackEvent += EnemyDamage;

      // show health
      UpdateHealthBars();
    }

    public void SetupForBossBattle() {
      picBossBattle.Location = Point.Empty;
      picBossBattle.Size = ClientSize;
      picBossBattle.Visible = true;

      SoundPlayer simpleSound = new SoundPlayer(Resources.final_battle);
      simpleSound.Play();

      tmrFinalBattle.Enabled = true;
    }

    public static FrmBattle GetInstance(Enemy enemy) {
      if (instance == null) {
        instance = new FrmBattle();
        instance.enemy = enemy;
        instance.Setup();
      }
      return instance;
    }

    private void UpdateHealthBars() {
            float playerHealthPer;
            float enemyHealthPer = enemy.Health / (float)enemy.MaxHealth;
            if (player.Health > player.MaxHealth)
            {
                playerHealthPer = player.Health / (float)player.Health;
            }
            else
            {
                playerHealthPer = player.Health / (float)player.MaxHealth;
            }

      const int MAX_HEALTHBAR_WIDTH = 226;
      lblPlayerHealthFull.Width = (int)(MAX_HEALTHBAR_WIDTH * playerHealthPer);
      lblEnemyHealthFull.Width = (int)(MAX_HEALTHBAR_WIDTH * enemyHealthPer);

      lblPlayerHealthFull.Text = player.Health.ToString();
      lblEnemyHealthFull.Text = enemy.Health.ToString();
    }

    private void btnAttack_Click(object sender, EventArgs e) {
      player.OnAttack(-2);
      if (enemy.Health > 0) {
        enemy.OnAttack(-4);
      }

      UpdateHealthBars();
            if (enemy.Health <= 0)
            {
                enemy.IsAlive = false;
                instance = null;
                Close();
            }
            if (player.Health <= 0)
            {
                //show game over screen
                this.Hide();
                instance = null;
                GameOver GO = new GameOver();
                GO.Show();


            }
        }

    private void EnemyDamage(int amount) {
      enemy.AlterHealth(amount);
    }

    private void PlayerDamage(int amount) {
      player.AlterHealth(amount);
    }

    private void tmrFinalBattle_Tick(object sender, EventArgs e) {
      picBossBattle.Visible = false;
      tmrFinalBattle.Enabled = false;
    }

        private void FrmBattle_Load(object sender, EventArgs e)
        {

        }

        private void picPlayer_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            /* //this.Hide();
             player.AlterHealth(-1);
             instance = null;
             Close();
            */
            OnEscape();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OnDefend(-4);
        }

        public void OnDefend(int damage)
        {
            int ClassID = 1;
            double defense = 0.0;
            if (ClassID == 1)
            {
                defense = 0.75;
            }

            else
            {
                defense = 0.5;
            }
            DefenseCalc(damage, defense);
        }

        public void DefenseCalc(int damage, double defense)
        {
            double DamageReduction = (damage * defense);
            double TotalDamage = (damage - DamageReduction);
            //convert double to int
            int fuckshit = (int)(Math.Floor(TotalDamage));
            player.AlterHealth(fuckshit);
            enemy.AlterHealth(fuckshit*2);
            UpdateHealthBars();

            if (enemy.Health <= 0)
            {
                enemy.IsAlive = false;
                instance = null;
                Close();
            }
            if (player.Health <= 0)
            {
                //show game over screen
                this.Hide();
                instance = null;
                GameOver GO = new GameOver();
                GO.Show();
            }

            //find thing that update visual then do

            //use this for Default class because Gun.
            //           enemy.AlterHealth(-20);

        }

        public void OnEscape()
        {
            Random PlayerR = new Random();
            Random EnemyR = new Random();

            int PlayerEscapeChance = PlayerR.Next(1, 5);
            int EnemyPursuitChance = PlayerR.Next(1, 5);

            int ClassID = 1;

            if (ClassID == 3)
            {
                PlayerEscapeChance += 1;
                EscapeRoute(PlayerEscapeChance, EnemyPursuitChance);
            }

            else
            {
                EscapeRoute(PlayerEscapeChance, EnemyPursuitChance);
            }
        }

        //Optimize usage of the method for closing the window
        public void EscapeRoute(int PlayerEscapeChance, int EnemyPursuitChance)
        {
            if (PlayerEscapeChance > EnemyPursuitChance)
            {
                instance = null;
                this.Hide();
            }

            else if (EnemyPursuitChance > PlayerEscapeChance)
            {
                //remove the multiplier
                int PursuitDamage = (0 - ((EnemyPursuitChance - PlayerEscapeChance) * 2));
                //send to the alter player health thing
                player.AlterHealth(PursuitDamage);
                UpdateHealthBars();
                instance = null;
                this.Hide();
            }

            else
            {
                double fuckshit2 = (0 - (PlayerEscapeChance / 2));
                int EscapeDamage = (int)Math.Floor(fuckshit2);
                //send to the alter player health thing
                player.AlterHealth(EscapeDamage);
                UpdateHealthBars();
                instance = null;
                this.Hide();
            }

            if (player.Health <= 0)
            {
                //show game over screen
                this.Hide();
                instance = null;
                GameOver GO = new GameOver();
                GO.Show();


            }
        }

        
    }
}
