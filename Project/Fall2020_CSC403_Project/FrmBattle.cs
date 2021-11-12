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
            //enemy.Health = 20;
            //enemy.MaxHealth = 20;
            UpdateHealthBars();
            picEnemy.BackgroundImage = enemy.battleImage;
            picEnemy.Refresh();
            BackColor = enemy.Color;
            picBossBattle.Visible = false;

            picPlayer.BackgroundImage = player.battleImage;

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
            player.OnAttack();
            if (enemy.Health > 0) {
                enemy.OnAttack(player.attack);
            }

            UpdateHealthBars();
    //private void btnAttack_Click(object sender, EventArgs e) {

    //    if (character_class == 0)
    //    {
    //        player.OnAttack(-4);
    //        if (enemy.Health > 0)
    //        {
    //            enemy.OnAttack(-20);
    //        }
    //    }
    //    else if (character_class == 3)
    //    {
    //        player.OnAttack(-4);
    //        if (enemy.Health > 0)
    //        {
    //            enemy.OnAttack(-10);
    //        }
    //    }
    //    else
    //    {
    //        player.OnAttack(-2);
    //        if (enemy.Health > 0)
    //        {
    //            enemy.OnAttack(-4);
    //        }
    //    }
    //  UpdateHealthBars();

            if (player.Health <= 0)
            {
                //show game over screen
                this.Hide();
                instance = null;
                GameOver GO = new GameOver();
                GO.ShowDialog();


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

        private void button1_Click(object sender, EventArgs e)
        {
            DefenseCalc(-4, player.defense);
        }

        public void DefenseCalc(int damage, double defense)
        {
            double DamageReduction = (damage * defense);
            double TotalDamage = (damage - DamageReduction);
            //convert double to int
            int DamageDone = (int)(Math.Floor(TotalDamage));
            player.AlterHealth(DamageDone);
            enemy.AlterHealth(DamageDone * 2);
            UpdateHealthBars();

            if (enemy.Health <= 0)
            {
                enemy.IsAlive = false;
                instance = null;
                Close();
            }
            if (player.Health <= 0)
            {
                this.Hide();
                instance = null;
                GameOver GO = new GameOver();
                GO.Show();
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            OnEscape();
        }

        public void OnEscape()
        {
            Random PlayerR = new Random();
            Random EnemyR = new Random();

            int PlayerEscapeChance = PlayerR.Next(1, 5);
            int EnemyPursuitChance = PlayerR.Next(1, 5);

            PlayerEscapeChance += player.escapeChanceIncrease;
            //int ClassID = 1;

            //if (character_class == 3)
            //{
            //    PlayerEscapeChance += 1;
            //    EscapeRoute(PlayerEscapeChance, EnemyPursuitChance);
            //}

            //else
            //{
            //    EscapeRoute(PlayerEscapeChance, EnemyPursuitChance);
            //}
            EscapeRoute(PlayerEscapeChance, EnemyPursuitChance);
        }

        
        public void EscapeRoute(int PlayerEscapeChance, int EnemyPursuitChance)
        {
            if (PlayerEscapeChance > EnemyPursuitChance)
            {
                instance = null;
                this.Hide();
            }

            else if (EnemyPursuitChance > PlayerEscapeChance)
            {
                int PursuitDamage = (0 - ((EnemyPursuitChance - PlayerEscapeChance) * 2));
                //send to the alter player health thing
                player.AlterHealth(PursuitDamage);
                UpdateHealthBars();
                instance = null;
                this.Hide();
            }

            else
            {
                double EscDamCalc = (0 - (PlayerEscapeChance / 2));
                int EscapeDamage = (int)Math.Floor(EscDamCalc);
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

    private void lblPlayerHealthFull_Click(object sender, EventArgs e)
        {

        }

        
    }
}
