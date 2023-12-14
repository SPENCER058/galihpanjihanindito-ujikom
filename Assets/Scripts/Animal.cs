using UnityEngine;

public class Animal : MonoBehaviour
{

	[SerializeField] private float health = 100f;

	public System.Action OnEnemyDie;

	private void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag("Food"))
		{
			health = health - 25;

			if (health <= 0)
			{
				Destroy(this.gameObject);
				OnEnemyDie?.Invoke();
			}
		}

		if (other.CompareTag("EnemyLimit"))
		{
			Destroy(this.gameObject);
		}
	}
}
