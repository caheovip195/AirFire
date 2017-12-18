﻿using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{

	[SerializeField] private float turnSpeed;
	[SerializeField] private float movementSpeed;
	[SerializeField] private float distanceRedirect;
    [SerializeField] GameObject [] position_go;
    [SerializeField] GameObject bag;
    private int nodeIndex;
	Transform target;
	private Transform [] node;
	Vector3 direction;
	Quaternion rotation;
	Quaternion lockRotation;
    private int dem = 0;
	void Start ()
	{
        //int rd = Random.Range(0, position_go.Length);
        node = new Transform[position_go[GamePlayController.checkCreateRunsEnemy].transform.childCount];
        for (int i = 0; i < node.Length; i++)
        {
            node[i] =position_go[GamePlayController.checkCreateRunsEnemy].transform.GetChild(i).transform;
        }
        nodeIndex = 0;
        target = node[nodeIndex];
    }

	void Update ()
	{
        if (dem >= 3)
        {
            ControllerScore.instance.AddScore(20);
            Destroy(gameObject);
        }
        direction = target.position - transform.position;
		if (direction != Vector3.zero)
		{
			lockRotation = Quaternion.LookRotation (direction, Vector3.back);
			rotation = Quaternion.Lerp (transform.rotation, lockRotation, turnSpeed * Time.deltaTime);
			transform.rotation = Quaternion.Euler (0, 0, rotation.eulerAngles.z);
		}
		transform.position = Vector2.MoveTowards (transform.position, target.position, movementSpeed * Time.deltaTime);
		if (Vector2.Distance (transform.position, target.position) <= distanceRedirect)
			GetNextNode ();
	}

	void GetNextNode ()
	{
		if (nodeIndex < node.Length - 1)
		{
			nodeIndex++;
			target = node[nodeIndex];
		}
		else Destroy (this.gameObject);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject obj1 = Instantiate(bag, transform.position, Quaternion.identity);
            GameObject obj2 = Instantiate(bag, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(obj1, 1);
            Destroy(obj2, 1);
            Destroy(gameObject);
            GamePlayController.instance.GameOverButton();
        }
        if (collision.tag == "bullerplayer")
        {
            GameObject obj1 = Instantiate(bag, transform.position, Quaternion.identity);
            dem += 1;
            Destroy(obj1, 1);
            Destroy(collision.gameObject);
        }
    }
}