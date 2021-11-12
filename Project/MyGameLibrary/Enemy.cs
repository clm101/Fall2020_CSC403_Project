using System.Drawing;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project.code {
    /// <summary>
    /// This is the class for an enemy
    /// </summary>
    /// 
    enum MoveDirection
    {
        Horizontal, Vertical
    }

    public class Enemy : BattleCharacter {
        // Movement
        public Vector2 EnemyMoveSpeed { get; private set; }
        public Vector2 EnemyLastPosition { get; private set; }
        public Vector2 EnemyPosition { get; private set; }
        public Collider EnemyCollider { get; private set; }
        private int[] m_enemyBoundaries;
        private bool m_isMoving;
        private MoveDirection m_moveDirection;

        // Battle art
        private Image m_battleImage;
        public Image battleImage { get { return m_battleImage; } private set { m_battleImage = value; } }
        public void set_battle_image(Image battleImage)
        {
            m_battleImage = battleImage;
        }

        // Walking art
        private PictureBox m_spriteImage;
        public PictureBox spriteImage { get { return m_spriteImage; } private set { m_spriteImage = value; } }
        public void set_sprite_image(System.Windows.Forms.PictureBox spriteImage)
        {
            m_spriteImage = spriteImage;
        }
        public bool Visible
        {
            get
            {
                return m_spriteImage.Visible;
            }
            set
            {
                m_spriteImage.Visible = value;
            }
        }

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
        public Enemy(Vector2 initPos, Collider collider, Point boundary1 = default(Point), Point boundary2 = default(Point)) : base(initPos, collider) {
            EnemyPosition = initPos;
            EnemyCollider = collider;
            IsAlive = true;
            if(boundary1 == default(Point) && boundary2 == default(Point))
            {
                m_isMoving = false;
            }
            else
            {
                m_isMoving = true;
                if (boundary1.X == boundary2.X)
                {
                    m_moveDirection = MoveDirection.Vertical;
                    m_enemyBoundaries = new int[2] { boundary1.Y, boundary2.Y };
                    EnemyMoveSpeed = new Vector2(0, 2);
                }
                else
                {
                    m_moveDirection = MoveDirection.Horizontal;
                    m_enemyBoundaries = new int[2] { boundary1.X, boundary2.X };
                    EnemyMoveSpeed = new Vector2(2, 0);
                }
            }
        }

        public void EnemyMove()
        {
            if (m_isMoving)
            {
                EnemyLastPosition = EnemyPosition;
                Vector2 nextEnemyPosition;
                if (m_moveDirection == MoveDirection.Horizontal)
                {
                    nextEnemyPosition = new Vector2(EnemyPosition.x + EnemyMoveSpeed.x, EnemyPosition.y);
                    if (nextEnemyPosition.x - m_enemyBoundaries[0] < 0)
                    {
                        nextEnemyPosition.x = m_enemyBoundaries[0];
                        EnemyMoveSpeed = new Vector2(EnemyMoveSpeed.x * -1, EnemyMoveSpeed.y);
                    }
                    else if (nextEnemyPosition.x + EnemyCollider.rect.Width - m_enemyBoundaries[1] > 0)
                    {
                        nextEnemyPosition.x = m_enemyBoundaries[1] - EnemyCollider.rect.Width;
                        EnemyMoveSpeed = new Vector2(EnemyMoveSpeed.x * -1, EnemyMoveSpeed.y);
                    }
                }
                else
                {
                    nextEnemyPosition = new Vector2(EnemyPosition.x, EnemyPosition.y + EnemyMoveSpeed.y);
                    if (nextEnemyPosition.y - m_enemyBoundaries[0] < 0)
                    {
                        nextEnemyPosition.y = m_enemyBoundaries[0];
                        EnemyMoveSpeed = new Vector2(EnemyMoveSpeed.x, EnemyMoveSpeed.y * -1);
                    }
                    else if (nextEnemyPosition.y + EnemyCollider.rect.Height - m_enemyBoundaries[1] > 0)
                    {
                        nextEnemyPosition.y = m_enemyBoundaries[1] - EnemyCollider.rect.Height;
                        EnemyMoveSpeed = new Vector2(EnemyMoveSpeed.x, EnemyMoveSpeed.y * -1);
                    }
                }
                EnemyPosition = nextEnemyPosition;
                EnemyCollider.MovePosition((int)nextEnemyPosition.x, (int)nextEnemyPosition.y);
                m_spriteImage.SetBounds(EnemyCollider.rect.X, EnemyCollider.rect.Y, EnemyCollider.rect.Width, EnemyCollider.rect.Height);
            }
        }
    }
}
