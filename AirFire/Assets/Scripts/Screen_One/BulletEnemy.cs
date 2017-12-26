using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour {
    public float speed = 13f;
    private int score_dead = 0;
    [SerializeField]
    private GameObject bag_player;
    private void Update()
    {
        if (transform.position.y < -38f)
        {
            Destroy(gameObject, 0);
        }
        //myBody.velocity = new Vector2(0, -speed);
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
                GameObject obj = Instantiate(bag_player, collision.transform.position, Quaternion.identity);
                Destroy(obj,1);
                Destroy(gameObject);
        }
    }
    
}
