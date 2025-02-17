﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Fall2020_CSC403_Project.code {
    public class Player : CharacterClasses
    {
        private int m_attack;
        public int attack
        {
            get { return m_attack; }
            set { m_attack = value; }
        }

        private int m_attacked;
        public int attacked
        {
            get { return m_attacked; }
            set { m_attacked = value; }
        }

        private double m_defense;
        public double defense
        {
            get { return m_defense; }
            set { m_defense = value; }
        }

        private int m_escapeChanceIncrease;
        public int escapeChanceIncrease
        {
            get { return m_escapeChanceIncrease; }
            set { m_escapeChanceIncrease = value; }
        }


        public Player(Vector2 initPos, Collider collider, CharacterType characterType) : base(initPos, collider, characterType)
        {
            set_animations_and_battle_image();
        }

        private struct WalkingAnimations
        {
            public Bitmap left;
            public Bitmap leftIdle;
            public Bitmap right;
            public Bitmap rightIdle;
            public Bitmap down;
            public Bitmap downIdle;
            public Bitmap up;
            public Bitmap upIdle;
        }

        private WalkingAnimations m_walkingAnimations;
        private Image m_battleImage;
        public Image battleImage
        {
            get { return m_battleImage; }
        }

        public Bitmap left
        {
            get { return m_walkingAnimations.left; }
        }
        public Bitmap leftIdle
        {
            get { return m_walkingAnimations.leftIdle; }
        }
        public Bitmap right
        {
            get { return m_walkingAnimations.right; }
        }
        public Bitmap rightIdle
        {
            get { return m_walkingAnimations.rightIdle; }
        }
        public Bitmap up
        {
            get { return m_walkingAnimations.up; }
        }
        public Bitmap upIdle
        {
            get { return m_walkingAnimations.upIdle; }
        }
        public Bitmap down
        {
            get { return m_walkingAnimations.down; }
        }
        public Bitmap downIdle
        {
            get { return m_walkingAnimations.downIdle; }
        }

        public void OnAttack()
        {
            Health += attacked;
        }

        public void AlterHealth(int amount)
        {
            Health += amount;
        }
        public void AlterMaxHealth(int amount)
        {
            MaxHealth += amount;
        }

        public void set_animations_and_battle_image()
        {
            string resourcesPath = Globals.resourcesPath;
            if (characterType == CharacterType.Basic)
            {
                Health = 20;
                MaxHealth = 20;
                attacked = -4;
                attack = -20;
                defense = 0.5;
                escapeChanceIncrease = 0;
                m_walkingAnimations.left = new Bitmap(resourcesPath + "\\OG_L.gif");
                m_walkingAnimations.leftIdle = new Bitmap(resourcesPath + "\\OG_LI.gif");
                m_walkingAnimations.right = new Bitmap(resourcesPath + "\\OG_R.gif");
                m_walkingAnimations.rightIdle = new Bitmap(resourcesPath + "\\OG_RI.gif");
                m_walkingAnimations.up = new Bitmap(resourcesPath + "\\OG_U.gif");
                m_walkingAnimations.upIdle = new Bitmap(resourcesPath + "\\OG_UI.gif");
                m_walkingAnimations.down = new Bitmap(resourcesPath + "\\OG_D.gif");
                m_walkingAnimations.downIdle = new Bitmap(resourcesPath + "\\OG_DI.gif");
                m_battleImage = new Bitmap(resourcesPath + "\\Orange_Girl_Shimmer.png");
            }
            else if (characterType == CharacterType.Paladin)
            {
                Health = 25;
                MaxHealth = 25;
                attacked = -2;
                attack = -4;
                defense = 0.75;
                escapeChanceIncrease = 0;
                m_walkingAnimations.left = new Bitmap(resourcesPath + "\\AM_L.gif");
                m_walkingAnimations.leftIdle = new Bitmap(resourcesPath + "\\AM_LI.gif");
                m_walkingAnimations.right = new Bitmap(resourcesPath + "\\AM_R.gif");
                m_walkingAnimations.rightIdle = new Bitmap(resourcesPath + "\\AM_RI.gif");
                m_walkingAnimations.up = new Bitmap(resourcesPath + "\\AM_U.gif");
                m_walkingAnimations.upIdle = new Bitmap(resourcesPath + "\\AM_UI.gif");
                m_walkingAnimations.down = new Bitmap(resourcesPath + "\\AM_D.gif");
                m_walkingAnimations.downIdle = new Bitmap(resourcesPath + "\\AM_DI.gif");
                m_battleImage = new Bitmap(resourcesPath + "\\Apple_Man_Shimmer.png");
            }
            else if (characterType == CharacterType.Monk)
            {
                Health = 15;
                MaxHealth = 15;
                attacked = -2;
                attack = -4;
                defense = 0.5;
                escapeChanceIncrease = 0;
                m_walkingAnimations.left = new Bitmap(resourcesPath + "\\MM_L.gif");
                m_walkingAnimations.leftIdle = new Bitmap(resourcesPath + "\\MM_LI.gif");
                m_walkingAnimations.right = new Bitmap(resourcesPath + "\\MM_R.gif");
                m_walkingAnimations.rightIdle = new Bitmap(resourcesPath + "\\MM_RI.gif");
                m_walkingAnimations.up = new Bitmap(resourcesPath + "\\MM_U.gif");
                m_walkingAnimations.upIdle = new Bitmap(resourcesPath + "\\MM_UI.gif");
                m_walkingAnimations.down = new Bitmap(resourcesPath + "\\MM_D.gif");
                m_walkingAnimations.downIdle = new Bitmap(resourcesPath + "\\MM_DI.gif");
                m_battleImage = new Bitmap(resourcesPath + "\\Monk_Man_Shimmer.png");
            }
            else // characterType == CharacterType.Thief
            {
                Health = 10;
                MaxHealth = 10;
                attacked = -4;
                attack = -10;
                defense = 0.5;
                escapeChanceIncrease = 1;
                m_walkingAnimations.left = new Bitmap(resourcesPath + "\\TG_L.gif");
                m_walkingAnimations.leftIdle = new Bitmap(resourcesPath + "\\TG_LI.gif");
                m_walkingAnimations.right = new Bitmap(resourcesPath + "\\TG_R.gif");
                m_walkingAnimations.rightIdle = new Bitmap(resourcesPath + "\\TG_RI.gif");
                m_walkingAnimations.up = new Bitmap(resourcesPath + "\\TG_U.gif");
                m_walkingAnimations.upIdle = new Bitmap(resourcesPath + "\\TG_UI.gif");
                m_walkingAnimations.down = new Bitmap(resourcesPath + "\\TG_D.gif");
                m_walkingAnimations.downIdle = new Bitmap(resourcesPath + "\\TG_DI.gif");
                m_battleImage = new Bitmap(resourcesPath + "\\Tomato_Girl_Shimmer.png");
            }
        }
    }
}
