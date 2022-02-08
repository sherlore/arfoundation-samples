using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
	public string sceName;
    
    public void Load()
    {
        SceneManager.LoadScene(sceName, LoadSceneMode.Single);
    }
}
