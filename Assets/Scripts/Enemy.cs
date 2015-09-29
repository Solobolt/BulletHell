using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private float health = 100.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	 if (health <= 0)
		{
			Destroy(this.gameObject);
		}
	}

	public void takeDamage (float damage)
	{
		health -= damage;
	}
}
