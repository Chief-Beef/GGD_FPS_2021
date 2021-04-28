using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{

    public static WinCondition Instance;

    public GameObject[] enemies;

    public int totalEnemies;

    public string nextScene;
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        totalEnemies = 13;
    }

    // Update is called once per frame
    void Update()
    {
        if(checkForWin())
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneScript.Instance.LoadScene(nextScene);
        }
    }

    public bool checkForWin()
    {

        for(int i = 0; i < totalEnemies; i++)
        {
            if(enemies[i] != null)
            {
                return false;
            }
        }
        return true;
    }
}
