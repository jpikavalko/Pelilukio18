using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartLevel : MonoBehaviour {

    public Button reload;

	public void RestartScene()
    {
        Debug.Log("scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Application.LoadLevel(0);
    }


}
