using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Transform myTransform;

    private Vector3 playerPosition;

    public float moveSpeed = 100f;

    GameManager gameManager;


    //Controls setup
    private string fireWeapon = "space";
    private string useSpecial;

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

        if (Input.GetAxis("Vertical") != 0)
        {
            playerPosition.z = playerPosition.z + (Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            playerPosition.x = playerPosition.x + (Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(fireWeapon))
        {
            //Time.timeScale = 2f;
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
