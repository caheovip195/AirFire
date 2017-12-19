using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulletPlayer : MonoBehaviour {


    [SerializeField]
    private GameObject [] bullet;
    private bool canShoot = true;
    private GameObject initObj;
    public float speedFire = 0.45f;
    private int bullet_target = 0;
    // Use this for initialization
	// Update is called once per frame
	void Update () {
        if (GamePlayController.instance.checkDie)
            return;
        if (canShoot)
        {
            StartCoroutine(Shoot());
        }
    }
   
    IEnumerator Shoot()
    {
        canShoot = false;
        Vector3 temp = transform.position;
        temp.y += 0.8f;
        temp.x += -0.15f;
        initObj= Instantiate(bullet[bullet_target], temp, Quaternion.identity);
        Destroy(initObj, 2.0f);
        yield return new WaitForSeconds(speedFire);
        canShoot = true;
    }
    private void DestroyBullet(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "item1":
                {
                    if (speedFire > 0.1f)
                    {
                        speedFire = speedFire - 0.05f;
                    }
                    DestroyBullet(collision);
                } ; break;
            case "item2":
                {
                   if(bullet_target ==0)
                    {
                        bullet_target = 1;
                        DestroyBullet(collision);
                    }
                    else
                    {
                        DestroyBullet(collision);
                        if (speedFire > 0.1f)
                        {
                            speedFire = speedFire - 0.05f;
                        }
                    }
                }; break;
            case "item3":
                {
                    if (bullet_target != 2)
                    {
                        DestroyBullet(collision);
                        bullet_target = 2;
                    }
                    else
                    {
                        if (speedFire > 0.1f)
                        {
                            speedFire = speedFire - 0.05f;
                        }
                        DestroyBullet(collision);
                    }
                };break;
        }
    }
}
