using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScrolling : MonoBehaviour
{
    public float speed;
    public int background_count;
    public float background_height;
    bool check_point_scroll = false;
    [SerializeField]
    private GameObject boss_map;
    // Update is called once per frame
    private void Update()
    {
        if (!check_point_scroll)
        {
            moveBackground();
        }
    }
    private void moveBackground()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        Vector3 pos = transform.position;
        if (pos.y < -background_height)
        {
            pos.y += background_height * background_count;
            transform.position = pos;
            if (pos.y <= -71)
            {
                check_point_scroll = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "destroy_pl")
        {
            Destroy(collision.gameObject);
            Vector3 temp = collision.transform.position;
            temp.y += 5;
            Instantiate(boss_map,temp, Quaternion.identity);
        }
    }

}
