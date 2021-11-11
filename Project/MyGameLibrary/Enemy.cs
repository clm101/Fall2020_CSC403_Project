using System.Drawing;

namespace Fall2020_CSC403_Project.code {
  /// <summary>
  /// This is the class for an enemy
  /// </summary>
  public class Enemy : BattleCharacter {
        /// <summary>
        /// THis is the image for an enemy
        /// </summary>
        /// 
        private const int GO_INC = 3;


        public Vector2 EnemyMoveSpeed { get; private set; }
        public Vector2 EnemyLastPosition { get; private set; }
        public Vector2 EnemyPosition { get; private set; }
        public Collider EnemyCollider { get; private set; }



        public void EnemyMove()
        {
            EnemyLastPosition = EnemyPosition;
            EnemyPosition = new Vector2(EnemyPosition.x + EnemyMoveSpeed.x, EnemyPosition.y + EnemyMoveSpeed.y);
            EnemyCollider.MovePosition((int)EnemyPosition.x, (int)EnemyPosition.y);
        }

        public void EnemyMoveBack()
        {
            EnemyPosition = EnemyLastPosition;
        }

        public void EnemyGoLeft()
        {
            EnemyMoveSpeed = new Vector2(-GO_INC, 0);
        }
        public void EnemyGoRight()
        {
            EnemyMoveSpeed = new Vector2(+GO_INC, 0);
        }
        public void EnemyGoUp()
        {
            EnemyMoveSpeed = new Vector2(0, -GO_INC);
        }
        public void EnemyGoDown()
        {
            EnemyMoveSpeed = new Vector2(0, +GO_INC);
        }

        public Image Img { get; set; }
        public int Dir { get; set; }
        public int Walkspan { get; set; }
        /// <summary>
        /// this is the background color for the fight form for this enemy
        /// </summary>
        public Color Color { get; set; }

        public bool IsAlive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="initPos">this is the initial position of the enemy</param>
        /// <param name="collider">this is the collider for the enemy</param>
        public Enemy(Vector2 initPos, Collider collider) : base(initPos, collider) {
            EnemyPosition = initPos;
            EnemyCollider = collider;
            IsAlive = true;
    }
  }
}
