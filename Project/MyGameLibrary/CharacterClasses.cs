using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable 1591


namespace Fall2020_CSC403_Project.code
{
	public class CharacterClasses : Character
	{
		public int Health { get; private set; }
		public int MaxHealth { get; private set; }
		private float Strength;

		public int ClassId = 3;

		public event Action<int> AttackEvent;

		

		public CharacterClasses(Vector2 initPos, Collider collider) : base(initPos, collider)
		{
			if ( ClassId == 0)
            {
				MaxHealth = 20;
				Strength = 2;
				Health += MaxHealth;
			}
			if (ClassId  == 1)
            {
				MaxHealth = 25;
				Strength = 2;
				Health += MaxHealth;
			}
			if(ClassId  == 2)
			{
				MaxHealth = 15;
				Strength = 2;
				Health += MaxHealth;
			}
			if (ClassId  == 3)
			{
				MaxHealth = 10;
				Strength = 2;
				Health += MaxHealth;
			}
		}

		public void OnAttack(int amount)
		{
			AttackEvent((int)(amount * Strength));
		}

		public void AlterHealth(int amount)
		{
			Health += amount;
		}
	}
}
