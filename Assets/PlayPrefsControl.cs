using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayPrefsControl : MonoBehaviour
{
	public Slider slider;
	public Text info;
	public string key;
	
	void Start()
	{
		slider.value = PlayerPrefs.GetFloat(key, 0f);
	}
	
    public void SetVal(float val)
    {
        PlayerPrefs.SetFloat(key, val);
		info.text = val.ToString("F1");
    }
}
