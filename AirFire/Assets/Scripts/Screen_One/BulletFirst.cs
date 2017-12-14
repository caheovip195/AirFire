using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFirst : MonoBehaviour {
    public float speed;
    [SerializeField]
    private GameObject bag_enemy;
    
    private Rigidbody2D mybody;

    private void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	

    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (transform.position.y > -20.5 || GamePlayController.instance.checkDie==true||player==null)
        {
            Destroy(gameObject, 0);
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            ControllerScore.instance.AddScore(10);
            GameObject obj= Instantiate(bag_enemy, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(obj, 1);
            Destroy(gameObject);
        }
        if (collision.tag == "boss1_body")
        {
            Destroy(gameObject);
        }
    }
}
