using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
	[SerializeField] private float turnSpeed;
	[SerializeField] private float movementSpeed;
	[SerializeField] private float distanceRedirect;
    [SerializeField] private GameObject[] position_go;
	private int nodeIndex;
	Transform target;
	public Transform [] node;
	Vector3 direction;
	Quaternion rotation;
	Quaternion lockRotation;
	void Start ()
	{
        //int rd = Random.Range(0, position_go.Length);
        node = new Transform[position_go[0].transform.childCount];
        for (int i = 0; i < node.Length; i++)
        {
            node[i] = position_go[0].transform.GetChild(i).transform;
        }
        nodeIndex = 0;
        target = node[nodeIndex];
    }

	void Update ()
	{
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
}