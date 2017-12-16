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
        temp.x += -0.15f;
        initObj= Instantiate(bullet, temp, Quaternion.identity);
        Destroy(initObj, 2.0f);
        yield return new WaitForSeconds(0.2f);
        canShoot = true;
    }
}
