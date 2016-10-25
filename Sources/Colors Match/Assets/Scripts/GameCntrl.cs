using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameCntrl : MonoBehaviour {

	float 			score;
	GameObject [] 	colorObjects = new GameObject[4];

	public GameObject   ColorObjectPref;
	public Vector3 []   Positions;
	public Text 		ScoreText;
	public Button 		RestartBtn;
	
	void Start () 
	{
		score = 0;
		ScoreText.text = "Match the color";

		InitColorObj ();	

		RestartBtn.GetComponent<Button>().onClick.AddListener(Restart);

		RestartBtn.gameObject.SetActive(false);
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

		float randRange = -.005f*score + 1f;

		GameObject.Find ("MainColorObject").GetComponent <ColorObject> ().SetColor (randColor, randRange);

		SetRandomRight ();

		for (int i = 0; i < Positions.Length; i++) 
		{
			colorObjects[i].GetComponent <ColorObject> ().SetColor (randColor, randRange);
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

		RestartBtn.gameObject.SetActive(true);
	}

	public void NextLevel () 
	{
		score++;
		ScoreText.text = score.ToString ();

		RandomizeColors ();
	}	

	void Restart ()
	{
		RestartBtn.gameObject.SetActive(false);

		score = 0;
		ScoreText.text = score.ToString ();

		for (int i = 0; i < Positions.Length; i++) 
		{
			colorObjects[i].GetComponent <ColorObject> ().isEnable = true;
		}

		RandomizeColors ();
	}
}