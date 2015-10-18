using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Transform myTransform;
    private Vector3 playerPosition;
    public float moveSpeed = 100f;

    GameManager gameManager;

    public GameObject lazor;
    private float lazorFireTime;
    private float lazorFireRate = 0.1f;

    //Controls setup
    private string useSpecial;
    public GameObject[] muzzle;

    //Aiming
    float aimingX;
    float aimingY;

    // Use this for initialization
    void Start () {
        myTransform = this.transform;
        gameManager = FindObjectOfType<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
        Movement();
        CheckBoundry();
    }
    //Handles the movement of the player
    private void Movement()
    {
        
        playerPosition = myTransform.position;

        //Handles basic movemenet of player
        if (Input.GetAxis("Vertical") != 0)
        {
            playerPosition.z = playerPosition.z + (Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            playerPosition.x = playerPosition.x + (Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime);
        }

        // Handles aiming of player
        if(Input.GetAxis("Mouse X") != 0)
        {
            aimingX = Input.GetAxis("Mouse X");
        }

        if (Input.GetAxis("Mouse Y") != 0)
        {
            aimingY = Input.GetAxis("Mouse Y");
        }

        

        if (Input.GetAxis("Fire1") != 0)
        {
            if (Time.time > lazorFireTime)
            {
                float angle = Mathf.Atan2(aimingX,aimingY)*Mathf.Rad2Deg;
                Transform bullet = muzzle[0].transform;
                bullet.rotation = Quaternion.Euler(0, 0, angle);
                Instantiate(lazor, muzzle[0].transform.position, bullet.rotation);
                lazorFireTime = Time.time + lazorFireRate;
                print(angle);
            }
        }

        if (Input.GetAxis("Fire2") != 0)
        {
            if (Time.time > lazorFireTime)
            {
                print("NO ACTION MAPPED: (Fire2)");
                Time.timeScale = 2;
                lazorFireTime = Time.time + lazorFireRate;
            }
        }
        else
        {
            Time.timeScale = 1;
        }

        myTransform.position = playerPosition;
    }

    //Keeps the player within a certain area 
    private void CheckBoundry()
    {
        playerPosition = myTransform.position;

        //Horizontal Boundry check
        if (playerPosition.x <= -gameManager.xBoundry)
        {
            playerPosition.x = -gameManager.xBoundry;
        }
        else if (playerPosition.x >= gameManager.xBoundry)
        {
            playerPosition.x = gameManager.xBoundry;
        }

        //Vertical Boundrty Check
        if (playerPosition.z >= gameManager.zBoundry)
        {
            playerPosition.z = gameManager.zBoundry;
        }
        else if (playerPosition.z <= -gameManager.zBoundry)
        {
            playerPosition.z = -gameManager.zBoundry;
        }
        myTransform.position = playerPosition;
    }
}
