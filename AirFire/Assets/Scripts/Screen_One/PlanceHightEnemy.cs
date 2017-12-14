using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanceHightEnemy : MonoBehaviour {
    [SerializeField]
    private GameObject enemy;
    public float minTime=30;
    public float maxTime=50;
    private float timeupdate=0;
    private float lastTime = 0;
    private GameObject player;
    private Vector3 position;
    private BoxCollider2D box;
    private GameObject bossmap;

    private void Awake()
    {
        box = GetComponent<BoxCollider2D>();
    }
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        position = player.transform.position;
        updateTime();
	}
	
	// Update is called once per frame
	void Update () {
        bossmap = GameObject.FindGameObjectWithTag("bossmap");
        if (bossmap)
        {
            Destroy(gameObject);
        }
        if (player)
        {
            position = player.transform.position;
            if (Time.time > lastTime + timeupdate)
            {
                createEnemy();
            }
        } 
	}
    void createEnemy()
    {
        updateTime();
        float minY = -box.bounds.size.y / 2;
        float maxY = box.bounds.size.y / 2;
        Vector3 temp = transform.position;
        temp.y = Random.Range(minY, maxY) + transform.position.y;

        if (gameObject.tag == "Plance1")
        {
            temp.x += 1;
            temp.y += 1;
            GameObject obj = Instantiate(enemy, temp, Quaternion.identity) as GameObject;
            // obj.GetComponent<EnemyHight>().target = player.transform.position;
            obj.tag = "plen1";
        }
        if (gameObject.tag == "Plance2")
        {

            temp.x += 1;
            temp.y += 1;
            GameObject obj = Instantiate(enemy, temp, Quaternion.identity) as GameObject;
            //obj.GetComponent<EnemyHight>().target = player.transform.position;
            obj.tag = "plen2";
        }
    }
    void updateTime()
    {
        lastTime = Time.time;
        timeupdate = Random.Range(minTime, maxTime) + lastTime;
    }
}
