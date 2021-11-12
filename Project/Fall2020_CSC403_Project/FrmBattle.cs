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
    public int character_class;

        private FrmBattle() {
      InitializeComponent();
      player = Game.player;
    }

    public void Setup() {
            // update for this enemy
            //enemy.Health = 20;
            //enemy.MaxHealth = 20;
            UpdateHealthBars();
            picEnemy.BackgroundImage = enemy.battleImage;
      picEnemy.Refresh();
      BackColor = enemy.Color;
      picBossBattle.Visible = false;

      string resourcesPath = Application.StartupPath + "\\..\\..\\Resources";

      if (character_class == 0)
            {
                picPlayer.BackgroundImage = new Bitmap(resourcesPath + "\\Orange_Girl_Shimmer.png");
      }
            if (character_class == 1)
            {
                picPlayer.BackgroundImage = new Bitmap(resourcesPath + "\\Apple_Man_Shimmer.png");
            }
            if (character_class == 2)
            {
                picPlayer.BackgroundImage = new Bitmap(resourcesPath + "\\Monk_Man_Shimmer.png");
            }
            if (character_class == 3)
            {
                picPlayer.BackgroundImage = new Bitmap(resourcesPath + "\\Tomato_Girl_Shimmer.png");
            }


            picEnemy.Refresh();

      // Observer pattern
      //enemy.AttackEvent += PlayerDamage;
      //player.AttackEvent += EnemyDamage;

      // show health
    }

    public void SetupForBossBattle() {
      picBossBattle.Location = Point.Empty;
      picBossBattle.Size = ClientSize;
      //picBossBattle.Visible = true;

      SoundPlayer simpleSound = new SoundPlayer(Resources.Dark_Depths);
      simpleSound.PlayLooping();

      //tmrFinalBattle.Enabled = true;
    }

    public static FrmBattle GetInstance(Enemy enemy, int character_class) {
      if (instance == null) {
        instance = new FrmBattle();
        instance.enemy = enemy;
        instance.character_class = character_class;
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

            if (player.Health <= 0)
            {
                //show game over screen
                this.Hide();
                instance = null;
                GameOver GO = new GameOver();
                GO.Show();


            }
            if (enemy.Health <= 0)
            {
                enemy.IsAlive = false;
                instance = null;
                Close();
            }

            UpdateHealthBars();
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
            //this.Hide();
            player.AlterHealth(-1);
            instance = null;
            Close();
        }
    }
}
