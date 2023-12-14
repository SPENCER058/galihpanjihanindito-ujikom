using UnityEngine;

public class Food : MonoBehaviour
{
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
			Destroy(this.gameObject);
		}

		
	}

	private void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag("Enemy"))
		{
			Destroy(this.gameObject);
		}
	}


}
