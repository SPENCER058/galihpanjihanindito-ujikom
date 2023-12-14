using UnityEngine;

public class Animal : MonoBehaviour
{

	[SerializeField] private float health = 100f;
	[SerializeField] private int score = 0;

	public System.Action<int> OnEnemyDie;

	private void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag("Food"))
		{
			health = health - 25;

			if (health <= 0)
			{
				Destroy(this.gameObject);
				OnEnemyDie?.Invoke(score);
			}
		}

		if (other.CompareTag("EnemyLimit"))
		{
			Destroy(this.gameObject);
		}
	}
}
