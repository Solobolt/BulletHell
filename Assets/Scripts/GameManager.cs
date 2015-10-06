using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public float zBoundry = 50.0f;
	public float xBoundry = 145.0f;

	public float zBoundryMoving = 0.0f;

	public int innerClip = 30;

	public int enemyNumb = 0;

	public GameObject liveLeftUIObject;
	public int livesLeft = 3;

	public GameObject[] enemyUnitList;

	public GameObject enemiesKilledUIObject;
	public int enemiesKilled = 0;

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
		//Update enemy unit list
		enemyUnitList = GameObject.FindGameObjectsWithTag ("Enemy");

		//NEW UI stuff
		enemiesKilledUIObject.GetComponent <Text> ().text = "Enemies Killed:" + enemiesKilled;
		liveLeftUIObject.GetComponent <Text> ().text = "Lives:" + livesLeft;
	}

	public void LifeRemove()
	{
		livesLeft--;
	}
}