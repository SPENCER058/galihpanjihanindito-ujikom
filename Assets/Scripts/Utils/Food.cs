using UnityEngine;

public class Food : MonoBehaviour
{
	[SerializeField] private float hungerValue = 25f;
	[SerializeField] private float lifeTime = 3f;

	private float currentLifeTime = 0f;

	private void Awake ()
	{
		currentLifeTime = lifeTime;
	}

	private void Update ()
	{
		currentLifeTime -= Time.deltaTime;

		if (currentLifeTime < 0.1f)
		{
			Destroy(gameObject);
		}

	}

	private void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag("Animal"))
		{
			Destroy(gameObject);
		}
	}

	public float GetHungerValue ()
	{
		return hungerValue;
	}


}
