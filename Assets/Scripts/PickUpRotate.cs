using UnityEngine;
using System.Collections;

public class PickUpRotate : MonoBehaviour {
	private GameManager gameManger;
	private float rotationSpeed = 100f;
	private float movementSpeed = -25.0f;
	private Transform myTransform;

	private int rand = Random.Range(1,3);

	private CubeController player;

	// Use this for initialization
	void Start () {
		myTransform = this.transform;
		player = FindObjectOfType<CubeController> ();
		gameManger = FindObjectOfType<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		myTransform.position += Time.deltaTime * movementSpeed * this.transform.forward;
		transform.Rotate (0,0,rotationSpeed*Time.deltaTime);

		if (transform.position.z < (-gameManger.zBoundry - 20))
		{
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter (Collider coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			player.fireMode = rand;
			Destroy (gameObject);
		}
	}
}
