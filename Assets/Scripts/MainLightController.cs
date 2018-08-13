using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLightController : MonoBehaviour {

    public Light mainLight;

	// Use this for initialization
	void Start () {
        mainLight = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetMouseButtonDown(0))
        {
            mainLight.spotAngle = mainLight.spotAngle - 5;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            mainLight.spotAngle = 150;
        }

	}
}
