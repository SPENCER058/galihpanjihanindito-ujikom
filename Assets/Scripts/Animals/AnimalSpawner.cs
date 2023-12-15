using System.Collections.Generic;
using UnityEngine;

namespace AnimalChaos.Animals
{

	public class AnimalSpawner : MonoBehaviour
	{

		[Header("Spawn Settings")]
		[SerializeField] private List<GameObject> animalTypeList = new List<GameObject>();
		[SerializeField] private float spawnInterval = 2f;
		[SerializeField] private float maxBounds = 15f;
		[SerializeField] private GameObject spawnedAnimalContainer;

		private float currentInterval;

		public System.Action<int> OnAnimalFull;
		public System.Action OnAnimalEatSFX;

		#region Life Cycles

		public void Initialize ()
		{
			currentInterval = spawnInterval;
		}

		private void Update ()
		{
			currentInterval -= Time.deltaTime;

			if (currentInterval <= 0)
			{
				currentInterval = spawnInterval;

				SpawnAnimal();
			}
		}

		#endregion

		private void SpawnAnimal ()
		{
			// Random

			int randomEnemyType = Random.Range(0, animalTypeList.Count);
			int randomXPosition = (int)Random.Range(-maxBounds, maxBounds);

			// Instantiate

			Transform transformObject = transform;
			transformObject.position = new Vector3(randomXPosition, transformObject.position.y, transformObject.position.z);

			GameObject temp = Instantiate(animalTypeList[randomEnemyType], transformObject);
			temp.transform.parent = spawnedAnimalContainer.transform;

			// Animal

			Animal tempAnimal = temp.GetComponent<Animal>();

			tempAnimal.OnAnimalHungerFull += OnAnimalEvent;
			tempAnimal.OnAnimalEat += OnAnimalEat;
			tempAnimal.OnAnimalDie += OnAnimalEvent;

		}

		private void OnAnimalEvent (Animal animal, int score)
		{
			OnAnimalFull?.Invoke(score);
			animal.OnAnimalHungerFull -= OnAnimalEvent;
			animal.OnAnimalEat -= OnAnimalEat;
			animal.OnAnimalDie -= OnAnimalEvent;
		}

		private void OnAnimalEvent (Animal animal)
		{
			animal.OnAnimalHungerFull -= OnAnimalEvent;
			animal.OnAnimalEat -= OnAnimalEat;
			animal.OnAnimalDie -= OnAnimalEvent;
		}

		private void OnAnimalEat ()
		{
			OnAnimalEatSFX?.Invoke();
		}

	}

}