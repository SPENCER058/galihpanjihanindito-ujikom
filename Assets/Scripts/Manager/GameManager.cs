using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField] private PlayerController playerController;
	[SerializeField] private Spawner spawner;

	[SerializeField] private TMPro.TextMeshProUGUI scoreText;
	[SerializeField] private TMPro.TextMeshProUGUI timerText;
	[SerializeField] private TMPro.TextMeshProUGUI gameOverText;

	[SerializeField] private GameObject gameOverPanel;

	[SerializeField] private float timer = 60f;

	public int score = 0;

	private void Update ()
	{
		timer -= Time.deltaTime;
		timerText.text = $"Timer = {(int)timer}";

		if (timer < 0.1f)
		{
			GameOver();
		}
	}

	private void GameOver ()
	{
		gameOverText.text = $"Score = {score}";
		gameOverPanel.SetActive(true);

		Time.timeScale = 0;
	}

	public void Retry ()
	{
		SceneManager.LoadScene("GamePlay");
	}

	public void MainMenu ()
	{
		SceneManager.LoadScene("Main Menu");
	}

	public void OnEscape ()
	{
		// TO DO : Pause
	}

	public void AddScore ()
	{
		score++;
		scoreText.text = $"Score = {score}";
	}

}
