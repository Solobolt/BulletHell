using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public float zBoundry = 50.0f;
	public float xBoundry = 145.0f;

	public float zBoundryMoving = 0.0f;

	public int innerClip = 30;

	public int enemyNumb = 0;

	public int livesLeft = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (enemyNumb == 0) 
		{
				Time.timeScale = 1f;
		}
	}

	public void LifeRemove()
	{
		livesLeft--;
	}
}