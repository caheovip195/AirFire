using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHight : MonoBehaviour {
    [SerializeField]
    private GameObject bag;
    public float speed = 2f;
    private int dem = 0;
    private GameObject player;
    Vector3 positionplayer;
    private Rigidbody2D myBody;
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update () {
        //rotation enemy hight 
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Vector3 temp = player.transform.position - transform.position;
            temp.Normalize();
            float rotation_z = Mathf.Atan2(temp.y, temp.x) * Mathf.Rad2Deg + 90;
            transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);
            myBody.velocity = temp * speed;
        }
       
        if (gameObject.tag == "plen1")
        {
            movePlance1();
        }
        else
        {
            movePlance2();
        }
        if (dem == 3)
        {
            ControllerScore.instance.AddScore(20);
            Destroy(gameObject);
        }
	}
    private void movePlance1()
    {
        /*float attmove = speed * Time.deltaTime;
        Vector3 temp = (transform.position - target) * attmove;
        temp = temp + Vector3.up * attmove;
        transform.Translate(-temp, Space.World);*/

        /* float attomove = speed * Time.deltaTime;
         Vector3 temp = Vector3.left * attomove;
         temp = temp + Vector3.up * attomove;
         transform.Translate(-temp, Space.World);*/
        if (transform.position.y < -38f || transform.position.y > -4.3||transform.position.x>24||transform.position.x<-24)
        {
            Destroy(gameObject, 0);
        }
    }
    private void movePlance2()
    {
        /* float attomove = speed * Time.deltaTime;
         Vector3 temp = Vector3.right * attomove;
         temp = temp + Vector3.up * attomove;
         transform.Translate(-temp, Space.World);
         */
        if (transform.position.y < -38f || transform.position.y>-4.3 || transform.position.x > 24 || transform.position.x < -24)
        {
            Destroy(gameObject, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject obj1= Instantiate(bag, transform.position, Quaternion.identity);
            GameObject obj2 = Instantiate(bag, collision.gameObject.transform.position,Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(obj1, 1);
            Destroy(obj2, 1);
            Destroy(gameObject);
        }
        if (collision.tag == "bullerplayer")
        {
            GameObject obj1 = Instantiate(bag, transform.position, Quaternion.identity);
            dem += 1;
            Destroy(obj1, 1);
            Destroy(collision.gameObject);
        }
    }
}
