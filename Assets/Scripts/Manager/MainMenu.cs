using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

	public void Play ()
	{
		SceneManager.LoadScene("GamePlay");
	}

	public void Quit ()
	{
		Application.Quit();
	}

}
