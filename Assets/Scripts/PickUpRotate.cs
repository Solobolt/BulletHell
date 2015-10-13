using UnityEngine;
using System.Collections;

public class PickUpRotate : MonoBehaviour {
	private GameManager gameManger;
	private float rotationSpeed = 100f;
	private float movementSpeed = 25.0f;
	private Transform myTransform;

	public Material[] material;

	private int rand = Random.Range(1,4);

	private CubeController player;

	// Use this for initialization
	void Start () {
		myTransform = this.transform;
		player = FindObjectOfType<CubeController> ();
		gameManger = FindObjectOfType<GameManager> ();
		GetComponent<Renderer>().material = material[rand - 1];
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
		if (coll.gameObject.tag == "FullPlayer")
		{
			player.fireMode = rand;
			Destroy (gameObject);
		}
	}
}
