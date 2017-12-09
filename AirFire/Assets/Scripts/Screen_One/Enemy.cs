using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed;

    private Rigidbody2D myBody;
    [SerializeField]
    private GameObject bag;
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void Update () {
        if (transform.position.y < -38f)
        {
            Destroy(gameObject, 0);
        }
	}
    private void FixedUpdate()
    {
        myBody.velocity = new Vector2(0, -speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
           GameObject bag_enemy= Instantiate(bag, transform.position, Quaternion.identity);
           GameObject bag_player=  Instantiate(bag, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Destroy(bag_enemy, 1);
            Destroy(bag_player, 1);
        }
    }
}
