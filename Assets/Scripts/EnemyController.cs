using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private Rigidbody rBody;

    public float moveSpeed;

    public PlayerController player;

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayerController>();
    }

	void Update () {

        //Face enemy towards the player
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
	}

    private void FixedUpdate()
    {
        //move the enemy
        rBody.velocity = (transform.forward * moveSpeed);
    }
}
