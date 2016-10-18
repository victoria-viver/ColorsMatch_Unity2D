using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameCntrl : MonoBehaviour {

	private GameObject block;
	private GameObject [] blocks = new GameObject[4];

	private int score;

	public GameObject ColorObjectPref;
	public Vector3 [] Positions;
	public Text ScoreText;

	[HideInInspector]
	public bool isNext = false;
	public bool isLose = false;
	
	void Start () 
	{
		score = 0;
		ScoreText.text = score.ToString ();

		InitColorObj ();

		SetRandomRight ((int) Random.Range (0, Positions.Length));
	}

	void Update () 
	{
		if (isLose)
			{ ScoreText.text = "Game Over \n You score is:" + score.ToString (); }
		else if (isNext)
		{ 
			score++;
			ScoreText.text = score.ToString ();

			NextLevel (); 
		}
	}

	void InitColorObj () 
	{
		for (int i = 0; i < Positions.Length; i++) 
		{
			blocks [i] = Instantiate (ColorObjectPref, Positions[i], Quaternion.identity) as GameObject;
		}
	}

	void SetRandomRight (int right) 
	{
		blocks[right].GetComponent <ColorObject> ().isRight = true;
	}

	void NextLevel () 
	{
		isNext = false;

		Color aColor = new Vector4 (Random.Range (0.1f, 1f), Random.Range (0.1f, 1f), Random.Range (0.1f, 1f), 1);
		GameObject.Find ("MainColorObject").GetComponent <Renderer> ().material.color = aColor;

		int rand = Random.Range (0, Positions.Length);
		
		float randColorCoef = 0;
		if (score < 5) 
			{ randColorCoef = 0.4f; }
		else if (score >= 5 && score < 10) 
			{ randColorCoef = 0.3f; }
		else if (score >= 10) 
			{ randColorCoef = 0.2f; }

		for (int i = 0; i < Positions.Length; i++) 
		{
			if (i == rand)
			{ 
				SetRandomRight (rand);

				blocks [i].GetComponent <Renderer> ().material.color = aColor; 
			}
			else 
			{
				blocks [i].GetComponent <ColorObject> ().isRight = false;

				float r = aColor.r + Random.Range (0.1f, randColorCoef) > 1f ? 1f : aColor.r + Random.Range (0.1f, randColorCoef);
				float g = aColor.g + Random.Range (0.1f, randColorCoef) > 1f ? 1f : aColor.g + Random.Range (0.1f, randColorCoef);
				float b = aColor.b + Random.Range (0.1f, randColorCoef) > 1f ? 1f : aColor.b + Random.Range (0.1f, randColorCoef);
				blocks [i].GetComponent <Renderer> ().material.color = new Vector4 (r, g, b, aColor.a);
			}
		}
	}	
}