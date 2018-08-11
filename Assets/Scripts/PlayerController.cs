using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody rBody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    //Controller look input
    //public float xFire;
    //public float yFire;

    private Camera mainCamera;

    // Player Combat

    public bool isCasting;

    public ProjectileController projectile;
    public float projTravelSpeed;
    public float projCastSpeed;
    private float timeBetweenCasts;

    public Transform castFromPoint;

	// Use this for initialization
	void Start () {

        rBody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
	}

    private void Update()
    {
        PlayerMovement();
        PlayerCombat();
    }

    private void PlayerMovement()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);

        // Abstract plane in the world to find the intercept point. Not physical terrain plane
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(pointToLook);
        }

        #region Controller stuff
        //TODO: Controller stuff 
        //Should make it neater and detect if its kb input or controller.
        //Vector3 lookDirection = new Vector3(Input.GetAxisRaw("hShoot"), 0f, Input.GetAxisRaw("vShoot"));
        //Debug.Log("Right stick horizontal value: " + Input.GetAxisRaw("hShoot") + "\nRight stick vertical value: " + Input.GetAxisRaw("vShoot"));
        //if(Input.GetAxisRaw("hShoot")!=0 || Input.GetAxisRaw("vShoot")!= 0)
        //{
        //    transform.rotation = Quaternion.LookRotation(lookDirection);
        //}
        #endregion
    }

    private void PlayerCombat()
    {
        if(!isCasting)
        {
            timeBetweenCasts = 0;
        }
        else
        {
            timeBetweenCasts -= Time.deltaTime;
            if (timeBetweenCasts <= 0)
            {
                timeBetweenCasts = projCastSpeed;
                ProjectileController newProjectile = Instantiate(projectile, castFromPoint.position, castFromPoint.rotation) as ProjectileController;
                newProjectile.speed = projTravelSpeed;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            isCasting = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isCasting = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate () {

        rBody.velocity = moveVelocity;
		
	}
}
