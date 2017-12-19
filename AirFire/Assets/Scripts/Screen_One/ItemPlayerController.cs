using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlayerController : MonoBehaviour {
    public float speed = 1.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (transform.position.y < -38f)
        {
            Destroy(gameObject, 0);
        }
    }
}
