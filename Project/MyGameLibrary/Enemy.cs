using System.Drawing;
using System.Windows.Forms;
using System;

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

        // Walking art
        private struct MovingAnimations
        {
            public Image posX;
            public Image negX;
            public Image negY;

            public Image baseImage;
        }
        private MovingAnimations m_spriteImage;
        private PictureBox m_sprite;

        public void set_images(string enemyName)
        {
            string resourcesPath = Globals.resourcesPath;
            string baseSpriteFilePath = resourcesPath + "\\sprite" + enemyName;
            try
            {
                m_spriteImage.posX = Image.FromFile(baseSpriteFilePath + "_posX.gif");
                m_spriteImage.negX = Image.FromFile(baseSpriteFilePath + "_negX.gif");
                m_spriteImage.negY = Image.FromFile(baseSpriteFilePath + "_negY.gif");
                m_spriteImage.baseImage = m_spriteImage.negX;
            }
            catch(System.IO.FileNotFoundException e)
            {
                m_spriteImage.baseImage = Image.FromFile(baseSpriteFilePath + ".gif");
            }
            m_battleImage = Bitmap.FromFile(resourcesPath + "\\battle" + enemyName + ".png");
        }

        /// <summary>
        /// this is the background color for the fight form for this enemy
        /// </summary>
        public Color Color { get; set; }
        public bool m_isAlive;
        public bool IsAlive {
            get
            {
                return m_isAlive;
            }
            set
            {
                m_isAlive = value;
                m_sprite.Visible = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="initPos">this is the initial position of the enemy</param>
        /// <param name="collider">this is the collider for the enemy</param>
        public Enemy(Vector2 initPos,
            Collider collider,
            string enemyName,
            PictureBox levelSprite,
            Point boundary1 = default(Point),
            Point boundary2 = default(Point),
            int speed = 0)
            :
            base(initPos, collider)
        {
            // Init members first
            EnemyPosition = initPos;
            EnemyCollider = collider;
            m_sprite = levelSprite;
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
                    EnemyMoveSpeed = new Vector2(0, speed);
                }
                else
                {
                    m_moveDirection = MoveDirection.Horizontal;
                    m_enemyBoundaries = new int[2] { boundary1.X, boundary2.X };
                    EnemyMoveSpeed = new Vector2(speed, 0);
                }
            }

            IsAlive = true;
            set_images(enemyName);
            if (m_isMoving && m_moveDirection == MoveDirection.Horizontal)
            {
                if (speed > 0)
                {
                    m_sprite.Image = m_spriteImage.posX;
                }
                else
                {
                    m_sprite.Image = m_spriteImage.negX;
                }
            }
            else
            {
                m_sprite.Image = m_spriteImage.baseImage;
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
                        m_sprite.Image = m_spriteImage.posX;
                    }
                    else if (nextEnemyPosition.x + EnemyCollider.rect.Width - m_enemyBoundaries[1] > 0)
                    {
                        nextEnemyPosition.x = m_enemyBoundaries[1] - EnemyCollider.rect.Width;
                        EnemyMoveSpeed = new Vector2(EnemyMoveSpeed.x * -1, EnemyMoveSpeed.y);
                        m_sprite.Image = m_spriteImage.negX;
                    }
                }
                else
                {
                    nextEnemyPosition = new Vector2(EnemyPosition.x, EnemyPosition.y + EnemyMoveSpeed.y);
                    if (nextEnemyPosition.y - m_enemyBoundaries[0] < 0)
                    {
                        nextEnemyPosition.y = m_enemyBoundaries[0];
                        EnemyMoveSpeed = new Vector2(EnemyMoveSpeed.x, EnemyMoveSpeed.y * -1);
                        m_sprite.Image = m_spriteImage.negX;
                    }
                    else if (nextEnemyPosition.y + EnemyCollider.rect.Height - m_enemyBoundaries[1] > 0)
                    {
                        nextEnemyPosition.y = m_enemyBoundaries[1] - EnemyCollider.rect.Height;
                        EnemyMoveSpeed = new Vector2(EnemyMoveSpeed.x, EnemyMoveSpeed.y * -1);
                        m_sprite.Image = m_spriteImage.negY;
                    }
                }
                EnemyPosition = nextEnemyPosition;
                EnemyCollider.MovePosition((int)nextEnemyPosition.x, (int)nextEnemyPosition.y);
                m_sprite.SetBounds(EnemyCollider.rect.X, EnemyCollider.rect.Y, EnemyCollider.rect.Width, EnemyCollider.rect.Height);
            }
        }
    }
}
