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
		public int Health { get;  set; }
		public int MaxHealth { get; set; }
		private float Strength;

		public int ClassId = 0;

		//public event Action<int> AttackEvent;

		
	
		public CharacterClasses(Vector2 initPos, Collider collider) : base(initPos, collider)
		{

				MaxHealth = 20;
				//Strength = 2;
				Health += MaxHealth;

		}

		public void OnAttack(int amount)
		{
			Health += amount;
		}

		public void AlterHealth(int amount)
		{

			Health += amount;
		}
		public void AlterMaxHealth(int amount)
		{
			MaxHealth += amount;
		}
	}
}
