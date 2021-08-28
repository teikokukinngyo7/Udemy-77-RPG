using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public void LoadTo(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}