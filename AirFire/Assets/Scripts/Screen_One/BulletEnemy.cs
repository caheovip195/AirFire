using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour {
    public float speed = 13f;
    private Rigidbody2D myBody;
    private int score_dead = 0;
    [SerializeField]
    private GameObject bag_player;
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
    // Use this for initialization
    void Start () {
		
	}

    private void Update()
    {
        if (transform.position.y < -38f)
        {
            Destroy(gameObject, 0);
        }
    }
    // Update is called once per frame
    void FixedUpdate () {
        myBody.velocity = new Vector2(0, -speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
                GameObject obj = Instantiate(bag_player, collision.transform.position, Quaternion.identity);
                Destroy(gameObject);
                Destroy(obj,1);
        }
    }
    
}
