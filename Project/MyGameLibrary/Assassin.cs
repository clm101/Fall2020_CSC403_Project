using System;



namespace Fall2020_CSC403_Project.code
{
	public class Assassin : Character 
	{
		public int Health { get; private set; }
		public int MaxHealth { get; private set; }
		private float Strength;

		public event Action<int> AttackEvent;

		public Assassin(Vector2 initPos, Collider collider) : base(initPos, collider)
		{

			MaxHealth = 10;
			Strength = 1;
			Health += MaxHealth;
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
