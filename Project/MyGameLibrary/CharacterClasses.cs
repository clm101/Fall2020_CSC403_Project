using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fall2020_CSC403_Project.code
{
	public class CharacterClasses : Character
	{
		public int Health { get; private set; }
		public int MaxHealth { get; private set; }
		private float Strength;

		public Default(Vector2 initPos, Collider collider) : base(initPos, collider)
		{
			MaxHealth = 20;
			Strength = 2;
			Health += MaxHealth;
        }

		public Paladin(Vector2 initPos, Collider collider) : base(initPos, collider)
		{
			MaxHealth = 30;
			Strength = 4;
			Health += MaxHealth;
		}


		public Monk(Vector2 initPos, Collider collider) : base(initPos, collider)
		{
			MaxHealth = 15;
			Strength = 1.5;
			Health += MaxHealth;
		}

		public Assassin(Vector2 initPos, Collider collider) : base(initPos, collider)
		{
			MaxHealth = 10;
			Strength = 1;
			Health += MaxHealth;
		}
	}
}
