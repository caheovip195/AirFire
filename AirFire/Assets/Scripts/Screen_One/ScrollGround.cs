using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollGround : MonoBehaviour {
    //-51 create a new
    //position y =-17.5
    public float speed = 1.0f;
    private Vector3 fistposition;
    bool flag = true;
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
            //if (transform.position.y <= -50f)
            //{
            //    transform.position = fistposition;
            //}
            if (transform.position.y < -51.0f && flag)
            {
                Vector3 temp = transform.position;
                temp.y = -17.5f;
                Instantiate(gameObject, temp, Quaternion.identity);
                flag = false;
            }
            if (transform.position.y < -71.0f)
            {
                Destroy(gameObject);
            }
        }
       
	}
}
