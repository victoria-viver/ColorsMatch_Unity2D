using UnityEngine;
using System.Collections;

public class ColorObject : MonoBehaviour 
{
	bool 		isMain = false;
	GameCntrl 	GameController;

	[HideInInspector] 
	public bool isRight  = false;
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

	public void SetColor (Color randColor, float randRange)
	{
		if (isMain || isRight)
		{ 
			GetComponent <Renderer> ().material.color = randColor; 			
		}
		else
		{ 
			float hue = 0f;
			float sat = 0f;
			float val  = 0f;

			Color.RGBToHSV (randColor, out hue, out sat, out val);

			Color aColor = Random.ColorHSV (hue, 
											hue, 
											sat - randRange > 0 ? sat - randRange : 0,
											sat + randRange < 1 ? sat + randRange : 1,
											val - randRange > 0 ? val - randRange : 0,
											val + randRange < 1 ? val + randRange : 1);

			GetComponent <Renderer> ().material.color = aColor;
		}
	}
}