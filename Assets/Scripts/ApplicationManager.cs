using UnityEngine;
using System.Collections;

public class ApplicationManager : MonoBehaviour {

    public void LoadFightTest()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("FightTest");
    }

    public void LoadMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu 3D");
    }

    public void Quit () 
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
}
