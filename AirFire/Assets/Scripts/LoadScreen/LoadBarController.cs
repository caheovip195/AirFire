using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadBarController : MonoBehaviour {
    [SerializeField]
    private Slider slider;

	// Use this for initialization
	void Start () {
        slider.minValue = 0;
        slider.maxValue = 1;
        slider.value = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
