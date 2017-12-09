using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    [SerializeField]
    private GameObject[] Enemy;
    private BoxCollider2D box;
    /* [SerializeField]
     private GameObject Enemy2;
     [SerializeField]
     private GameObject Enemy3;*/
    // Use this for initialization
    private void Awake()
    {
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update () {
    }
    private void Start()
    {
        StartCoroutine(initSpawner());
    }
    IEnumerator initSpawner()
    {
        yield return new WaitForSeconds( Random.Range(1, 3));
        float minX = -box.bounds.size.x / 2.0f;
        float maxX = box.bounds.size.x / 2.0f;
        Vector3 temp = transform.position;
        temp.x = Random.Range(minX, maxX);
        Instantiate(Enemy[Random.Range(0,Enemy.Length)], temp, Quaternion.identity);
        StartCoroutine(initSpawner());
    }
}
