using AnimalChaos.Input;

using UnityEngine;
using UnityEngine.InputSystem;

namespace AnimalChaos.Player
{

	public class PlayerController : MonoBehaviour
	{
		#region Variables

		[Header("Main References")]
		[SerializeField] private InputReader inputReader;
		[SerializeField] private Animator animator;
		[SerializeField] private AudioSource audioSource;

		[Header("Food Spawn Setting")]
		[SerializeField] private Transform foodSpawnPosition;
		[SerializeField] private GameObject foodContainer;
		[SerializeField] private GameObject prefabFood;

		[Header("Player Movement Setting")]
		public float moveSpeed = 5f;
		public float maxBound = 10f;

		private float moveXDirection = 0f;

		#endregion

		#region Unity Life Cycles

		public void Initialize (AudioClip throwSFXClip)
		{
			audioSource.clip = throwSFXClip;

			inputReader.OnMoveEvent += OnMove;
			inputReader.OnThrowEvent += OnThrow;
		}

		private void Update ()
		{
			Move();
		}

		public void CleanUp ()
		{
			inputReader.OnMoveEvent -= OnMove;
			inputReader.OnThrowEvent -= OnThrow;
		}

		#endregion

		#region Event Handlers

		private void Move ()
		{
			Vector3 newPosition = new Vector3(moveXDirection, 0f, 0f).normalized * moveSpeed * Time.deltaTime;

			float newXPos = Mathf.Clamp(transform.position.x + newPosition.x, -maxBound, maxBound);

			transform.position = new Vector3(newXPos, transform.position.y, transform.position.z);
		}

		public void OnMove (float value)
		{
			moveXDirection = value;

			animator.SetFloat("Strafe", moveXDirection);
		}

		public void OnThrow ()
		{
			GameObject temp = Instantiate(prefabFood, foodSpawnPosition);

			temp.transform.parent = foodContainer.transform;

			audioSource.Play();

			animator.SetTrigger("Throw");
		}

		#endregion

	}

}