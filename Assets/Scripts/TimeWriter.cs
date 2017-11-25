using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class TimeWriter : MonoBehaviour
{

	private Text _text;

	public Text Text
	{
		get
		{
			if (_text == null)
				_text = GetComponent<Text>();
			return _text;
		}
	}

	
	// Update is called once per frame
	void Update ()
	{
	    if (Text)
	        Text.text = DateTime.Now.ToString();

	}
}
