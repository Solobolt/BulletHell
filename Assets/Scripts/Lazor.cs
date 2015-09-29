using UnityEngine;
using System.Collections;

public class Lazor : MonoBehaviour {

	private float projectileSpeed = 500.0f;

	private Transform myTransform;

	private float lifeTime;
	private float lifeTimeDuration = 0.8f;

	private float damage = 20f;


	// Use this for initialization
	void Start () {
		myTransform = this.transform;
		lifeTime = Time.time + lifeTimeDuration;
	}
	
	// Update is called once per frame
	void Update () {
		myTransform.position += Time.deltaTime * projectileSpeed * this.transform.forward;

		//Kill projectile at the end of its life
		if(Time.time > lifeTime)
		{
			Destroy(this.gameObject);
		}
	}

	private void OnTriggerEnter(Collider otherObject)
	{
		if(otherObject.tag == "Enemy")
		{
			otherObject.GetComponent <Enemy>().takeDamage(damage);
			Destroy (this.gameObject);
		}
	}
}
