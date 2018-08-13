using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    public int baseHealth;
    private int currentHealth;

    public ScoreManager scoreManager;

    void Start()
    {
        currentHealth = baseHealth;
    }
	void Update () {

		if(currentHealth <= 0)
        {
            scoreManager.UpdateScore();
            Destroy(gameObject);
        }
	}

    public void HurtEnemy(int damageDealt)
    {
        currentHealth -= damageDealt;
    }
}
