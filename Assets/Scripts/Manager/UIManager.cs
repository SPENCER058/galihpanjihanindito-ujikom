using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace AnimalChaos.Manager
{
	public class UIManager : MonoBehaviour
	{
		#region Variables

		[Header("Gameplay UI")]
		[SerializeField] private GameObject gameplayUI;
		[SerializeField] private TextMeshProUGUI scoreText;
		[SerializeField] private TextMeshProUGUI timerText;

		[Header("Pause UI")]
		[SerializeField] private GameObject pausePanel;
		[SerializeField] private Button resumeButton;
		[SerializeField] private Button pauseMainMenuButton;

		[Header("Game Over UI")]
		[SerializeField] private GameObject gameOverPanel;
		[SerializeField] private Button retryButton;
		[SerializeField] private Button mainMenuButton;
		[SerializeField] private TextMeshProUGUI finalScoreText;

		#endregion

		#region Events

		public System.Action OnResumeUIEvent;
		public System.Action OnRetryUIEvent;
		public System.Action OnMainMenuUIEvent;

		#endregion

		#region Unity Life Cycles

		public void Initialize ()
		{
			resumeButton.onClick.AddListener(OnResumePressed);
			pauseMainMenuButton.onClick.AddListener(OnMainMenuPressed);
			retryButton.onClick.AddListener(OnRetryPressed);
			mainMenuButton.onClick.AddListener(OnMainMenuPressed);
		}

		public void CleanUp ()
		{
			resumeButton.onClick.RemoveListener(OnResumePressed);
			pauseMainMenuButton.onClick.RemoveListener(OnMainMenuPressed);
			retryButton.onClick.RemoveListener(OnRetryPressed);
			mainMenuButton.onClick.RemoveListener(OnMainMenuPressed);
		}

		#endregion

		#region Event Handlers

		private void OnResumePressed ()
		{
			pausePanel.SetActive(false);
			OnResumeUIEvent?.Invoke();
		}

		private void OnRetryPressed ()
		{
			OnRetryUIEvent?.Invoke();
		}

		private void OnMainMenuPressed ()
		{
			OnMainMenuUIEvent?.Invoke();
		}

		#endregion

		#region Public Methods

		public void OnPause ()
		{
			pausePanel.SetActive(true);
		}

		public void OnResume ()
		{
			pausePanel.SetActive(false);
		}

		public void UpdateScore (int score)
		{
			scoreText.text = $"Score = {score}";
		}

		public void UpdateTimer (int time)
		{
			timerText.text = $"Timer = {time}";
		}

		public void OnGameOver (int finalScore)
		{
			gameplayUI.SetActive(false);

			finalScoreText.text = $"Final Score = {finalScore}";

			gameOverPanel.SetActive(true);
		}

		#endregion
	}

}