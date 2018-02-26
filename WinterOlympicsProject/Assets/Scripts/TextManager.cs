using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{

	public Text[] texts;

	public static TextManager instance;

	void Start () {
		if (instance == null)
		{
			instance = this;
		}
	}
	
	// Update is called once per frame

	
	IEnumerator ClearTextCoroutine(Text text, float delay)
	{
		yield return new WaitForSeconds(delay);
		text.enabled = false;
	}

	public void ShowRawText()
	{
		Debug.Log("text function called!");
		texts[0].enabled = true;
		StartCoroutine(ClearTextCoroutine(texts[0], 3f));
	}

	public void ShowCookedNoSauceText()
	{
		Debug.Log("text function called!");
		texts[1].enabled = true;
		StartCoroutine(ClearTextCoroutine(texts[1], 3f));
	}

	public void ShowCookedWithSauceText()
	{
		Debug.Log("text function called!");
		texts[2].enabled = true;
		StartCoroutine(ClearTextCoroutine(texts[2], 3f));
	}

	public void ShowBurnedText()
	{
		Debug.Log("text function called!");
		texts[3].enabled = true;
		StartCoroutine(ClearTextCoroutine(texts[3], 3f));
	}
}
