using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{

    public static SceneScript Instance;

    public void Start()
    {
        Instance = this;
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
