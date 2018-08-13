using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour {

    public int baseHealth;
    private int currentHealth;

	void Start () {
        currentHealth = baseHealth;
	}

	void Update () {
		if(currentHealth <= 0)
        {
            Debug.Log("Dead");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
	}

    public void HurtPlayer(int damageDealt)
    {
        currentHealth -= damageDealt;
    }
}
