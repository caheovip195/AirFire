using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed;
   // private AudioSource audio;
    private Rigidbody2D myBody;
    [SerializeField]
    private GameObject bag;
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
       // audio = GetComponent<AudioSource>();
    }

	// Update is called once per frame
	void Update () {
        if (transform.position.y < -38f)
        {
            Destroy(gameObject, 0);
        }
        myBody.velocity = new Vector2(0, -speed);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject bag_enemy= Instantiate(bag, transform.position, Quaternion.identity);
            GameObject bag_player=  Instantiate(bag, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(bag_enemy, 1);
            Destroy(bag_player, 1);
            GamePlayController.instance.GameOverButton();
           // audio.Play();
            Destroy(gameObject);
        }
    }
}
