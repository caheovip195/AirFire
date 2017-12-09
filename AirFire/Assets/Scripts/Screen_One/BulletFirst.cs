using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFirst : MonoBehaviour {
    public float speed;
    [SerializeField]
    private GameObject bag_enemy;
    [SerializeField]
    private GameObject buff_bullet1;
    private Rigidbody2D mybody;
    private Vector3 poitDead;
    private void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	

    private void Update()
    {
        if (transform.position.y > -21)
        {
            Destroy(gameObject, 0);
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            int rd = Random.Range(1, 30);
            if (rd == 15)
            {
                GameObject laze = Instantiate(buff_bullet1, transform.position, Quaternion.identity) as GameObject;
                Destroy(laze, 8);
            }
            ControllerScore.instance.AddScore(10);
            GameObject obj= Instantiate(bag_enemy, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(obj, 1);
            Destroy(gameObject);
        }
    }
}
