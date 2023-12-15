using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour
{
	[SerializeField] private float animalHunger = 100f;
	[SerializeField] private int score = 0;

	[SerializeField] private Slider slider;

	public System.Action<Animal, int> OnAnimalHungerFull;
	public System.Action<Animal> OnAnimalDie;
	public System.Action OnAnimalEat;

	public float currentHunger = 0f;
	public float maxHunger = 0f;

	private void Awake ()
	{
		maxHunger = animalHunger;
	}

	private void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag("Food"))
		{

			Food food = other.GetComponent<Food>();

			currentHunger = currentHunger + food.GetHungerValue();
			float tempCurrentHunger = Mathf.Clamp(currentHunger, 0, maxHunger);

			slider.value = tempCurrentHunger / maxHunger;

			OnAnimalEat?.Invoke();

			if (currentHunger >= maxHunger)
			{
				OnAnimalHungerFull?.Invoke(gameObject.GetComponent<Animal>(),score);

				Destroy(gameObject);
			}

		}

		if (other.CompareTag("Animal Destroy"))
		{
			OnAnimalDie?.Invoke(gameObject.GetComponent<Animal>());
			Destroy(gameObject);
		}
	}
}
