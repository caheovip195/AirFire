using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTouchInputPlayer : MonoBehaviour {
    public float speed = 2f;
    public float minX = -3.7f;
    public float maxX = 3.7f;
    public float minY = -35f;
    public float maxY = -20.5f;
    Vector3 mousePo;
    [SerializeField]
    private GameObject bag_player;
    [SerializeField]
    private GameObject[] healing;
    private int point_dead = 0;
   
    private void Start()
    {
        mousePo = transform.position;
    }

    private void Update()
    {
        if (GamePlayController.instance.checkDie == false)
        {
            PlayerMoveButton();
        }
        
        if (point_dead >= 5)
        {
            GameObject obj= Instantiate(bag_player, transform.position, Quaternion.identity);
            Destroy(obj, 1);
            Destroy(gameObject);
            GamePlayController.instance.GameOverButton();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GamePlayController.instance.GamePauseButton();
        }
    }

    private void PlayerMoveButton()
    {
        if (Input.GetMouseButton(0))
        {
            mousePo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePo = new Vector3(Mathf.Clamp(mousePo.x,minX,maxX), Mathf.Clamp(mousePo.y,minY,maxY), 0);
        }
        
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, mousePo, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bullet_enemy1")
        {
            Destroy(healing[5-point_dead-1]);
            point_dead = point_dead + 1;   
        }
        if (collision.tag == "Enemy" ||collision.tag == "plen1"||collision.tag == "plen2"||collision.tag == "enemyrun")
        {
            for(int i = 0; i < healing.Length; i++)
            {
                Destroy(healing[i]);
            }
        }
        if (collision.tag == "bossmap")
        {
            for (int i = 0; i < healing.Length; i++)
            {
                Destroy(healing[i]);
            }
            point_dead = 5;
        }
        
    }
}
