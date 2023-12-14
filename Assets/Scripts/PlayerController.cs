using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

	[SerializeField] private Animator animator;

	[SerializeField] private GameObject parentFood;
	[SerializeField] private GameObject prefabFood;

	public float moveSpeed = 5f;

	private float moveX = 0f;

	public float maxBound = 10f;

	private void Update ()
	{
		Move();
	}

	private void Move ()
	{
		Vector3 tempMove = new Vector3(moveX, 0f, 0f).normalized * moveSpeed * Time.deltaTime;

		transform.Translate(tempMove);
	}

	public void OnMove (InputAction.CallbackContext ctx)
	{
		Vector2 tempMove = ctx.ReadValue<Vector2>();

		moveX = tempMove.x;

		animator.SetFloat("Strafe", moveX);
	
	}

	public void OnFire (InputAction.CallbackContext ctx)
	{
		if (ctx.started)
		{
			Instantiate(prefabFood, parentFood.transform);

			animator.SetTrigger("Throw");
		}
	}

}
