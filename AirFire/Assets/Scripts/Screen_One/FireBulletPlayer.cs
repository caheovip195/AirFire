using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulletPlayer : MonoBehaviour {


    [SerializeField]
    private GameObject bullet;
    private bool canShoot = true;
    private GameObject initObj;
    // Use this for initialization
    void Start () {
		
	}
	
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
        temp.y += 0.2f;
        initObj= Instantiate(bullet, temp, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        canShoot = true;
    }
    private void Bullet_Destroy(GameObject initObj)
    {
        Vector3 destroy_bullet = bullet.transform.position;
        if (initObj.transform.position.y> -20.5)
        {
            Destroy(bullet);
        }
    }
}
