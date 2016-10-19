using UnityEngine;
using System.Collections;

public class ColorObject : MonoBehaviour 
{
	bool isMain = false;

	GameCntrl GameController;

	[HideInInspector] 
	public bool isRight = false;
	public bool isEnable = true;

	void Awake () 
	{
		GameController = GameObject.Find ("Main Camera").GetComponent <GameCntrl> ();

		if (gameObject.transform.name == "MainColorObject")
			{ isMain = true; }
	}

	void OnMouseDown () 
	{
		if (isMain || !isEnable) return;

		if (isRight)
			{ GameController.NextLevel (); }	
		else
			{ GameController.GameOver (); }	
	}

	public void RandomizeColors (Color randColor, float randRange)
	{
		if (isMain || isRight)
			{ GetComponent <Renderer> ().material.color = randColor; }
		else
			{ GetComponent <Renderer> ().material.color = new Vector4 (Random.Range (randColor.r - randRange > 0 ? randColor.r - randRange : 0, randColor.r + randRange < 1 ? randColor.r + randRange : 1),
																	   Random.Range (randColor.g - randRange > 0 ? randColor.g - randRange : 0, randColor.g + randRange < 1 ? randColor.g + randRange : 1),
																	   Random.Range (randColor.b - randRange > 0 ? randColor.b - randRange : 0, randColor.b + randRange < 1 ? randColor.b + randRange : 1),
																	   randColor.a); }
	}
}