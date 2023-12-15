using UnityEngine;
using UnityEngine.UI;

namespace AnimalChaos.Manager
{
	public class MainMenuHandler : MonoBehaviour
	{
		[Header("Manager Reference")]
		[SerializeField] private AudioManager audioManager;
		[SerializeField] private GameSceneManager sceneManager;

		[Header("Buttons")]
		[SerializeField] private Button playButton;
		[SerializeField] private Button quitButton;

		private void OnEnable ()
		{
			playButton.onClick.AddListener(OnPlayPressed);
			quitButton.onClick.AddListener(OnQuitPressed);

		}

		private void OnDisable ()
		{
			playButton.onClick.RemoveListener(OnPlayPressed);
			quitButton.onClick.RemoveListener(OnQuitPressed);
		}

		private void OnPlayPressed ()
		{
			audioManager.PlayButtonSFX();

			sceneManager.LoadGamePlay();
		}

		private void OnQuitPressed ()
		{
			audioManager.PlayButtonSFX();

			#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;

			#else
				Application.Quit();

			#endif

		}

	}

}
