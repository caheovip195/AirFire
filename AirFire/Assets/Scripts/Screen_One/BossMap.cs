using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMap : MonoBehaviour {
    public float speed = 1f;
    private Rigidbody2D myBody;
    Vector3 position;
    private float X;
    private float Y;
    float minX = -4.42f;
    float maxX = 4.42f;
    bool flag = true;
    private float time = 0;
    private float lasttime = 0;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
    // Use this for initialization
    void Start () {
        updateTime();
	}
    void updateTime()
    {
        lasttime = Time.time;
        time = lasttime + Random.Range(1,5);
    }

    private void Update()
    {
        if (transform.position.y > -25)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            position = transform.position;
            Y = transform.position.y;
        }
        else
        {
            if (Time.time > lasttime)
            {
                updateTime();
                X = Random.Range(minX, maxX);
            }
            position = transform.position;
            position.x += X * speed;
            position.y = Y;
            myBody.velocity = position;
        }
    }
    // Update is called once per frame
}
