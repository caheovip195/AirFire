using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollGround : MonoBehaviour {
    public float speed = 1.0f;
    private Vector3 fistposition;
	// Use this for initialization
	void Start () {
        fistposition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        GameObject bossmap = GameObject.FindGameObjectWithTag("bossmap");
        if (!bossmap)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            if (transform.position.y <= -50f)
            {
                transform.position = fistposition;
            }
        }
       
	}
}
