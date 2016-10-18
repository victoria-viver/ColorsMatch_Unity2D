using UnityEngine;
using System.Collections;

public class ColorObject : MonoBehaviour 
{
	// GameObject GameObject.Find ("MainColorObject");
	bool isMain = false;

	public bool isRight = false;

	void Awake () 
	{
		if (gameObject.transform.name == "MainColorObject")
		{
			isMain = true;
			Color aColor = new Vector4 (Random.Range (0.1f, 1f), Random.Range (0.1f, 1f), Random.Range (0.1f, 1f), 1);
			GetComponent <Renderer> ().material.color = aColor;
		}
	}

	void Start () 
	{
		Color aColor = GameObject.Find ("MainColorObject").GetComponent <Renderer> ().material.color;

		if (isRight)
			{ GetComponent <Renderer> ().material.color = aColor; }
		else
			{ GetComponent <Renderer> ().material.color = new Vector4 (aColor.r + Random.Range (0.1f, 0.5f), aColor.g + Random.Range (0.1f, 0.5f), aColor.b + Random.Range (0.1f, 0.5f), aColor.a); }
	}

	void OnMouseDown () 
	{
		if (isMain) return;

		if (isRight)
			{ GameObject.Find ("Main Camera").GetComponent <GameCntrl> ().isNext = true; }	
		else
			{ GameObject.Find ("Main Camera").GetComponent <GameCntrl> ().isLose = true; }	
	}
}