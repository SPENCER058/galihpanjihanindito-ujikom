using UnityEngine;

using AnimalChaos.Player;
using AnimalChaos.Animals;
using AnimalChaos.Input;

namespace AnimalChaos.Manager
{

	public class GameManager : MonoBehaviour
	{
		#region Scripts References

		[Header("Managers Reference")]
		[SerializeField] private UIManager uIManager;
		[SerializeField] private AudioManager audioManager;
		[SerializeField] private GameSceneManager sceneManager;

		[Header("Gameplay Reference")]
		[SerializeField] private InputReader inputReader;
		[SerializeField] private PlayerController playerController;
		[SerializeField] private AnimalSpawner animalSpawner;

		#endregion

		#region Variables 

		[Header("Gameplay Settings")]
		[SerializeField] private float gameTimer = 60f;

		private float currentTimer = 0f;
		private int score = 0;

		#endregion

		#region Unity Life Cycles

		private void Awake ()
		{
			inputReader.Initialize();

			uIManager.Initialize();
			playerController.Initialize(audioManager.ThrowFoodClip);

			currentTimer = gameTimer;
		}

		private void OnEnable ()
		{
			inputReader.OnPauseEvent += OnPause;

			uIManager.OnResumeUIEvent += OnResume;
			uIManager.OnRetryUIEvent += OnRetry;
			uIManager.OnMainMenuUIEvent += OnMainMenu;

			animalSpawner.OnAnimalFull += OnAnimalFull;
			animalSpawner.OnAnimalEatSFX += audioManager.PlayEatSFX;

			inputReader.EnableMap();
			inputReader.EnableUIMap(false);
			inputReader.EnableGamePlayMap(true);
		}

		private void Update ()
		{

			currentTimer -= Time.deltaTime;

			currentTimer = Mathf.Max(0, currentTimer);

			uIManager.UpdateTimer((int)currentTimer);

			if (currentTimer < 0.1f)
			{
				GameOver();
			}
		}

		private void OnDisable ()
		{
			inputReader.OnPauseEvent += OnPause;

			uIManager.OnResumeUIEvent -= OnResume;
			uIManager.OnRetryUIEvent -= OnRetry;
			uIManager.OnMainMenuUIEvent -= OnMainMenu;

			animalSpawner.OnAnimalFull -= OnAnimalFull;
			animalSpawner.OnAnimalEatSFX += audioManager.PlayEatSFX;

			uIManager.CleanUp();
			playerController.CleanUp();

			inputReader.DisableMap();
		}

		#endregion

		#region Event Handlers

		public void OnAnimalFull (int score)
		{
			this.score += score;
			uIManager.UpdateScore(this.score);

			audioManager.PlayAnimalFullSFX();
		}

		public void OnPause ()
		{
			inputReader.EnableGamePlayMap(false);
			inputReader.EnableUIMap(true);

			audioManager.PlayButtonSFX();
			Time.timeScale = 0;
			uIManager.OnPause();
		}

		public void OnResume ()
		{
			audioManager.PlayButtonSFX();
			uIManager.OnResume();
			Time.timeScale = 1;

			inputReader.EnableUIMap(false);
			inputReader.EnableGamePlayMap(true);
		}

		public void OnRetry ()
		{
			audioManager.PlayButtonSFX();
			sceneManager.LoadGamePlay();
		}

		public void OnMainMenu ()
		{

			audioManager.PlayButtonSFX();
			audioManager.StopAllAudio();
			sceneManager.LoadMainMenu();
		}

		#endregion

		#region Others Functions

		private void GameOver ()
		{
			inputReader.EnableGamePlayMap(false);
			inputReader.EnableUIMap(true);

			Time.timeScale = 0;

			audioManager.StopAllAudio();
			audioManager.PlayGameOverSFX();
			uIManager.OnGameOver(score);
		}

		#endregion

	}

}