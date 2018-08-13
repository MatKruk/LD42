using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {

    public int enemiesKilled = 0;

    public void UpdateScore()
    {
        enemiesKilled++;
    }
    private void LateUpdate()
    {
        if (enemiesKilled >= 11)
        {
            SceneManager.LoadScene("Victory");
        }
    }
}
