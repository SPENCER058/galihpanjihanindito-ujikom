using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	[SerializeField] private GameManager gameManager;
	[SerializeField] private float interval = 2f;

	[SerializeField] private List<GameObject> enemyList = new List<GameObject>();

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

			GachaEnemy();
		}
	}

	private void GachaEnemy () {

		int gacha = Random.Range(0, 3);

		NewEnemy(enemyList[gacha]);

	}

	private void NewEnemy (GameObject gacha)
	{
		GameObject temp =  Instantiate(gacha, this.gameObject.transform);
		Animal tempAnimal = temp.GetComponent<Animal>();

		tempAnimal.OnEnemyDie += OnEnemyDie;
		
	}

	private void OnEnemyDie (int score)
	{
		gameManager.AddScore(score);
	}

}
