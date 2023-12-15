using UnityEngine;

public class MoveUnit : MonoBehaviour
{
	[SerializeField] private float moveSpeed = 5f;

	private void Update ()
	{
		Vector3 move = new Vector3(0f, 0f, moveSpeed).normalized * moveSpeed * Time.deltaTime;

		transform.Translate(move);
	}

}
