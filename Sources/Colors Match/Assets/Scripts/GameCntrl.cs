using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameCntrl : MonoBehaviour {

	private float score;

	private GameObject [] colorObjects = new GameObject[4];

	public GameObject ColorObjectPref;
	public Vector3 [] Positions;
	public Text ScoreText;
	
	void Start () 
	{
		score = 0;
		ScoreText.text = "Match the color";

		InitColorObj ();	
	}

	void InitColorObj () 
	{
		for (int i = 0; i < Positions.Length; i++) 
		{
			colorObjects [i] = Instantiate (ColorObjectPref, Positions[i], Quaternion.identity) as GameObject;
		}

		RandomizeColors ();
	}

	void RandomizeColors ()
	{
		Color randColor = Random.ColorHSV (0f, 1f, 
										   0.2f, 1f, 
										   0.2f, 1f);

		float randRange = -(.045f)*score + 1f;
		// float randRange = 2.55f/score;

		GameObject.Find ("MainColorObject").GetComponent <ColorObject> ().RandomizeColors (randColor, randRange);

		SetRandomRight ();

		for (int i = 0; i < Positions.Length; i++) 
		{
			colorObjects[i].GetComponent <ColorObject> ().RandomizeColors (randColor, randRange);
		}		
	}

	void SetRandomRight () 
	{
		int right = Random.Range (0, Positions.Length); 

		for (int i = 0; i < Positions.Length; i++) 
		{
			if (i == right)
				{ colorObjects[i].GetComponent <ColorObject> ().isRight = true; }
			else 
				{ colorObjects[i].GetComponent <ColorObject> ().isRight = false; }
		}
	}

	public void GameOver ()
	{
		ScoreText.text = "Game over\nYour score is: " + score.ToString ();

		for (int i = 0; i < Positions.Length; i++) 
		{
			colorObjects[i].GetComponent <ColorObject> ().isEnable = false;
		}
	}

	public void NextLevel () 
	{
		score++;
		ScoreText.text = score.ToString ();

		RandomizeColors ();
	}	
}