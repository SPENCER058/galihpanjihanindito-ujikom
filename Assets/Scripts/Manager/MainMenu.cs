using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

	public void Play ()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void Quit ()
	{
		Application.Quit();
	}

}
