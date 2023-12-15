using UnityEngine;
using UnityEngine.InputSystem;

namespace AnimalChaos.Input
{
	[CreateAssetMenu(fileName = "InputReader", menuName = "Animal Chaos/Input/InputReader")]
	public class InputReader : ScriptableObject
	{
		public System.Action<float> OnMoveEvent;
		public System.Action OnThrowEvent;
		public System.Action OnPauseEvent;

		private PlayerInput playerInput;

		public void Initialize ()
		{
			if (playerInput == null)
			{
				playerInput = new PlayerInput();
			}

			playerInput.Player.Move.started += OnMove;
			playerInput.Player.Move.performed += OnMove;
			playerInput.Player.Move.canceled += OnMove;

			playerInput.Player.Throw.started += ctx => OnThrowEvent?.Invoke();
			playerInput.Player.Escape.started += ctx => OnPauseEvent?.Invoke();

		}

		public void CleanUp ()
		{
			playerInput.Player.Move.started -= OnMove;
			playerInput.Player.Move.performed -= OnMove;
			playerInput.Player.Move.canceled -= OnMove;

			playerInput.Player.Throw.started -= ctx => OnThrowEvent?.Invoke();
			playerInput.Player.Escape.started -= ctx => OnPauseEvent?.Invoke();
		}

		#region Basic Map Functions

		public void EnableMap ()
		{
			playerInput.Enable();
		}

		public void DisableMap ()
		{
			playerInput.Disable();
		}

		public void EnableGamePlayMap (bool value)
		{
			if (value)
			{
				playerInput.Player.Enable();
			}
			else
			{
				playerInput.Player.Disable();
			}
		}

		public void EnableUIMap (bool value)
		{
			if (value)
			{
				playerInput.UI.Enable();
			}
			else
			{
				playerInput.UI.Disable();
			}
		}

		#endregion

		private void OnMove (InputAction.CallbackContext ctx)
		{
			OnMoveEvent?.Invoke(playerInput.Player.Move.ReadValue<Vector2>().x);
		}
	}
}
