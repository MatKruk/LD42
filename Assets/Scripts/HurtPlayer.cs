using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

    public int damage;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player hit");
            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damage);
            Debug.Log("Damage dealt");
        }
    }
}
