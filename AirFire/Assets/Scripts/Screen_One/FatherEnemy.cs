using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FatherEnemy : MonoBehaviour {
    public Image healBar;
    private float maxHeal = 100;
    public float speed;
    [SerializeField]
    private GameObject [] bullet;
    private float rd_position = 0;
    private bool is_shoot = true;
    private void Start()
    {
        rd_position = Random.Range(-28.50f,-22.88f);
    }

    void Update()
    {
        if (transform.position.y < -38f)
        {
            Destroy(gameObject, 0);
        }
        if (transform.position.y > rd_position)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        if (is_shoot)
        {
            StartCoroutine(Shoot());
        }
    }
    IEnumerator Shoot()
    {
        is_shoot = false;
        yield return new WaitForSeconds(Random.Range(3, 6));
        Vector3 temp = transform.position;
        temp.y += -0.8f;
        Instantiate(bullet[0], temp, Quaternion.identity);
        temp.y = transform.position.y;
        temp.x += +0.519f;
        Instantiate(bullet[1], temp, Quaternion.identity);
        temp.x += +0.31f;
        Instantiate(bullet[2], temp, Quaternion.identity);
        temp.x += -0.829f-0.537f;
        Instantiate(bullet[3], temp, Quaternion.identity);
        temp.x += -0.29f;
        Instantiate(bullet[4], temp, Quaternion.identity);
        is_shoot = true;
    }
    private void TakeDame(int heal)
    {
        maxHeal = maxHeal - heal;
        healBar.fillAmount = maxHeal / 100;
        if (maxHeal <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "bullerplayer" : {

                           TakeDame(5);
                           Destroy(collision.gameObject);
                                     
                        } ; break;
        }
    }
}
