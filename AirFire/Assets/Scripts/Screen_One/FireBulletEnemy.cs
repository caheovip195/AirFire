using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulletEnemy : MonoBehaviour {
    [SerializeField]
    private GameObject[] bullet;
    private GameObject bulletEnemy;
    bool fireTime = true;
	// Use this for initialization
	void Start () {
        bulletEnemy = bullet[Random.Range(0, bullet.Length)];
	}
	
	// Update is called once per frame
	void Update () {
        if (fireTime)
        {
            StartCoroutine(Shoot());
        }
	}
    IEnumerator Shoot()
    {
        fireTime = false;
        yield return new WaitForSeconds(Random.Range(3f,7f));
        Vector3 temp = transform.position;
        temp.y += -0.3f;
        Instantiate(bulletEnemy, temp, Quaternion.identity);
        fireTime = true;
    }
}
