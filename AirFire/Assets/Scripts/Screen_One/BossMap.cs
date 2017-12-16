using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMap : MonoBehaviour {
    public GameObject efffire;
    public float speed = 1f, speed2 = 2f;
    [SerializeField]
    private GameObject bulletBoss;
    [SerializeField]
    private GameObject[] enemyChidren;
    [SerializeField]
    private GameObject bagPlayer;
    [SerializeField]
    private GameObject bagBullet;
    [SerializeField]
    private GameObject bag_boss;
    private Rigidbody2D myBody;
    private float minX = -1.25f, maxX = 1.25f, minY = -25.0f, maxY = -22.5f, possitionX = 0.0f, possitionY = 0.0f;
    private bool move_boss = true, flagfire = true, flag = true, flagCreateEnemyLeft = true, flagCreateEnemyRight = true,
        is_die_air_left = true, is_die_air_right = true;
    private float time = 0,lastime = 0, scoreDead = 0;
    private Animator ani;
    private GameObject air_left, air_right;
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    private void Start()
    {
        air_left = transform.GetChild(1).transform.GetChild(0).gameObject;
        air_right = transform.GetChild(1).transform.GetChild(1).gameObject;
        ani.SetBool("bag_left", false);
        ani.SetBool("two_bag", false);
        ani.SetBool("bag_boss", false);
        RandomPossition();
    } 

    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Destroy(GameObject.FindGameObjectWithTag("bag_bullet"));
        }
        if (move_boss == true)
        {
            moveboss();
        }
        
        if (flag == true)
        {
            if ((float)transform.position.x == (float)possitionX && (float)transform.position.y == (float)possitionY)
            {
                RandomPossition();
                flag = false;
            }
            ani.SetBool("bag_left", false);
            ani.SetBool("two_bag", false);
            ani.SetBool("bag_boss", false);
        }
        else
        {

            if ((float)transform.position.x == (float)possitionX && (float)transform.position.y == (float)possitionY)
            {
                RandomPossition();
            }
            if (flagfire && scoreDead <10000)
            {
                StartCoroutine(fireboss());
            }
            if (flagCreateEnemyLeft && player && scoreDead <=3000)
            {
                StartCoroutine(createEnemyChidrenLeft());
            }
            if (flagCreateEnemyRight && player && scoreDead <=7000)
            {
                StartCoroutine(createEnemyChidrenRight());   
            }
            Vector3 temp;
            if (scoreDead >=3000 && is_die_air_left)
            {
                temp = air_left.transform.position;
                Instantiate(efffire,temp , Quaternion.identity, air_left.transform);
                temp.x += 0.3f;
                ani.SetBool("bag_left", true);
                is_die_air_left = false;
                ControllerScore.instance.AddScore(2000);
            }
            if (scoreDead >= 7000 && is_die_air_right)
            {
                temp = air_right.transform.position;
                Instantiate(efffire, temp, Quaternion.identity, air_left.transform);
                ani.SetBool("two_bag", true);
                is_die_air_right = false;
                ControllerScore.instance.AddScore(2000);
            }
        }
    }
 
    void RandomPossition()
    {
        possitionX = Random.Range(minX, maxX);
        possitionY = Random.Range(minY, maxY);
    }

    private void moveboss()
    {
        Vector3 position;
        position.x = possitionX;
        position.y = possitionY;
        position.z = transform.position.z;
        transform.position = Vector3.MoveTowards(transform.position, position, speed2*Time.deltaTime);
    }
    private IEnumerator fireboss()
    {      
        flagfire = false;
        Vector3 temp = transform.position;
        temp.y += -2f;
        //temp.x += -0.1f;
        Instantiate(bulletBoss, temp, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        flagfire = true;
    }
    private IEnumerator createEnemyChidrenLeft()
    {
        flagCreateEnemyLeft = false;
        yield return new WaitForSeconds(Random.Range(3.0f, 6.0f));
        Vector3 temp = transform.position;
        temp.x+= -2.0f;
        Instantiate(enemyChidren[Random.Range(0,enemyChidren.Length)], temp, Quaternion.identity);
        flagCreateEnemyLeft = true;
    }
    private IEnumerator createEnemyChidrenRight()
    {
        flagCreateEnemyRight = false;
        yield return new WaitForSeconds(Random.Range(3.0f, 6.0f));
        Vector3 temp = transform.position;
        temp.x += 2.0f;
        Instantiate(enemyChidren[Random.Range(0, enemyChidren.Length)], temp, Quaternion.identity);
        flagCreateEnemyRight = true;
    }
    private void TimeCreateEnemy()
    {
        lastime = Time.time;
        time = lastime + Random.Range(1, 4);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bullerplayer")
        {
            if (flag == false)
            {
                GameObject bag = Instantiate(bagBullet, collision.transform.position, Quaternion.identity);
                Destroy(bag, 0.2f);
                scoreDead += 5;
                Debug.Log("Score : " + scoreDead);
                if (scoreDead == 10000)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        Vector3 temp = transform.position;
                        temp.y += Random.Range(-1.3f, 1.3f);
                        GameObject obj = Instantiate(bag_boss, temp, Quaternion.identity);
                        Destroy(obj, 5);
                    }
                    move_boss = false;
                    ani.SetBool("bag_boss", true);
                    GamePlayController.instance.checkDie = true;
                    ControllerScore.instance.AddScore(5000);
                    GamePlayController.instance.GameWin();
                    Destroy(gameObject, 5);

                }
            }   
            Destroy(collision.gameObject);
        }
    }
}
