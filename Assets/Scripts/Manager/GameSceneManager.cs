using UnityEngine;
using UnityEngine.SceneManagement;

namespace AnimalChaos.Manager
{
	public class GameSceneManager : MonoBehaviour
	{
		[Header("Scene Address")]
		[SerializeField] private string mainMenuScene = "MainMenu";
		[SerializeField] private string gamePlayScene = "GamePlay";

		public void LoadScene (string sceneName)
		{
			SceneManager.LoadScene(sceneName);
		}

		public void LoadMainMenu ()
		{
			SceneManager.LoadScene(mainMenuScene);
		}

		public void LoadGamePlay ()
		{
			SceneManager.LoadScene(gamePlayScene);
		}
	}
}
