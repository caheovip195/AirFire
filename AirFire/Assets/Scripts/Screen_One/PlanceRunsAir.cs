using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanceRunsAir : MonoBehaviour {
    [SerializeField] private GameObject enemy;
    private float lastTime, time;
	// Use this for initialization
	void Start () {
        updateTime();
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > time + lastTime)
        {
            updateTime();
            CreateEnemy();
        }
	}
    private void CreateEnemy()
    {
        Vector3 temp = transform.position;
        for(int i = 0; i < 4; i++)
        {
            Instantiate(enemy, temp, Quaternion.identity);
            temp.y += 2.0f;
        }
    }
    private void updateTime()
    {
        lastTime = Time.time;
        time = lastTime + Random.Range(10.0f,15.0f);
    }
}
