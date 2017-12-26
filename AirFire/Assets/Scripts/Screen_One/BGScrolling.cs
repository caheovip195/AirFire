using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScrolling : MonoBehaviour
{
    private AudioSource audio;
    [SerializeField]
    AudioClip bossAudio;
    [SerializeField]
    AudioClip winAudio;
    public float speed;
    public int background_count;
    public float background_height;
    bool check_point_scroll = false;
    [SerializeField]
    private GameObject boss_map;
    private bool flag = true;
    // Update is called once per frame
    private void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Play();
    }
    private void Update()
    {
        if (!check_point_scroll)
        {
            moveBackground();
        }
        if (GamePlayController.instance.checkDie && flag)
        {
            flag = false;
            audio.clip = null;
            audio.loop = false;
            audio.clip = winAudio;
            audio.Play();
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
            audio.clip = bossAudio;
            audio.Play();
        }
    }

}
