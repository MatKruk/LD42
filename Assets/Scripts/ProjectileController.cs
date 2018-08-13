using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

    //TODO: Change from static speed to a value modified by upgrades that the player gains.
    public float speed;
    public int projDamage;

    //TODO: make a pool of objects to reduce garbage collection instead of this.
    public float lifeTime;
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(projDamage);
            Destroy(gameObject);
        }
    }

    void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
	}
}
