using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanceRunsAir : MonoBehaviour {
    [SerializeField] private GameObject enemy;
    private float lastTime, time;
    // Use this for initialization
    [SerializeField] GameObject [] lineGoEnemyRuns;
	void Start () {
        updateTime();
	}
	
	// Update is called once per frame
	void Update () {
        GameObject bossmap = GameObject.FindGameObjectWithTag("bossmap");
        if (bossmap)
        {
            Destroy(gameObject);
        }
        if (Time.time > time + lastTime)
        {
            updateTime();
            CreateEnemy();
           // GamePlayController.checkCreateRunsEnemy = false;
        }
	}
    private void CreateEnemy()
    {
        // GamePlayController.checkCreateRunsEnemy = true;
        GamePlayController.checkCreateRunsEnemy = Random.Range(0, 2);
        Vector3 temp = transform.position;
        for(int i = 0; i < 6; i++)
        {
            Instantiate(enemy, temp, Quaternion.identity);
            temp.y += 2.0f;
        }
    }
    private void updateTime()
    {
        lastTime = Time.time;
        time = Random.Range(10.0f,20.0f);
    }
}
