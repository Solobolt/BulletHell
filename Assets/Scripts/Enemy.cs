using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public GameObject pickUp;

	public GameObject EnemyLazor;

	private GameManager gameManager;

	private float movementSpeed = -20.0f;
	
	private Transform myTransform;

	private float lazorFireTime;
	private float lazorFireRate = 2f;

	private float health = 20.0f;

	// Use this for initialization
	void Start () {
		myTransform = this.transform;
		gameManager = FindObjectOfType <GameManager>();
		gameManager.enemyNumb ++;
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
		CheckIfDead ();
		checkIfOffScreen ();

		if (Time.time > lazorFireTime) 
		{
			Instantiate (EnemyLazor, transform.position, transform.rotation);
			lazorFireTime = Time.time + lazorFireRate;
		}
	}

	public void TakeDamage (float damage)
	{
		health -= damage;
	}

	private void Move()
	{
		myTransform.position += Time.deltaTime * movementSpeed * this.transform.forward;

	}

	private void randomPickUp()
	{
		int roll = Random.Range (1,100);
		if (roll <= 5)
		{
			Instantiate (pickUp, transform.position,transform.rotation);
		}
	}

	private void CheckIfDead()
	{
		if (health <= 0)
		{
			removeEnemy();
			randomPickUp ();
		}
	}

	private void checkIfOffScreen()
	{
		if (transform.position.z < (-gameManager.zBoundry - 20))
		{
			removeEnemy ();
		}
	}

	private void removeEnemy()
	{
		gameManager.enemyNumb --;
		Destroy(this.gameObject);
	}
}
