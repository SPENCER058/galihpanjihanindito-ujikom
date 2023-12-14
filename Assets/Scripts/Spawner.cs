using UnityEngine;

public class Spawner : MonoBehaviour
{
	[SerializeField] private GameManager gameManager;
	[SerializeField] private float interval = 2f;

	[SerializeField] private GameObject EnemyPrefab;

	private float currentInterval;

	private void Awake ()
	{
		currentInterval = interval;
	}

	private void Update ()
	{
		currentInterval -= Time.deltaTime;

		if (currentInterval <= 0)
		{
			currentInterval = interval;

			NewEnemy();
		}
	}

	private void NewEnemy ()
	{
		GameObject temp =  Instantiate(EnemyPrefab, this.gameObject.transform);
		Animal tempAnimal = temp.GetComponent<Animal>();

		tempAnimal.OnEnemyDie += OnEnemyDie;
		
	}

	private void OnEnemyDie ()
	{
		gameManager.AddScore();
	}

}
