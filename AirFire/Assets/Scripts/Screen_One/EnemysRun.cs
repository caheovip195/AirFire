using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysRun : MonoBehaviour {
    public float speed=2.0f;
    public float speedRotation = 1.0f;
   // private Vector3[] posstions_target;
   // private Vector3 possition_target;
    private Rigidbody2D myBody;
    private int i = 0;
    public Transform [] postdichtest;
    public GameObject possiton_count;
    private bool flag = false;
    private float timeSuccses = 0.0f;
	// Use this for initialization
	void Start () {
        myBody = GetComponent<Rigidbody2D>();
        StartCoroutine(timer_moveSuccess(0));

    }
	public void Move(Transform dich)
    {
        //Vector3 dir = dich.position - transform.position;
        //float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg+90)/90;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward*Time.deltaTime*speedRotation);
        float Distance = Vector2.Distance(transform.position,dich.position);
        timeSuccses = Distance/(speed*2);
        Vector3 temp = dich.transform.position - transform.position; 
        float rotation_z_to = Mathf.Atan2(temp.y, temp.x) * Mathf.Rad2Deg + 90;
        Debug.Log("time" + timeSuccses);
        iTween.MoveTo(transform.gameObject, iTween.Hash("position", dich.position, "time", timeSuccses, "easetype", iTween.EaseType.linear));
        iTween.RotateTo(transform.gameObject, iTween.Hash("rotation", new Vector3(0, 0f, rotation_z_to), "time",timeSuccses/speedRotation, "easetype", iTween.EaseType.linear));
    }

    private IEnumerator timer_moveSuccess(int t)
    {
        Move(postdichtest[t]);
        i += 1;
        yield return new WaitForSeconds(timeSuccses);
        if (i < 5)
        {
            StartCoroutine(timer_moveSuccess(t+1));
        }
    }


    // Update is called once per frame
    //void Update () {

    //       if (Mathf.Abs(Mathf.Abs(possiton_count.transform.GetChild(i).transform.position.x) - Mathf.Abs(transform.position.x)) < 0.2f &&
    //           Mathf.Abs(Mathf.Abs(possiton_count.transform.GetChild(i).transform.position.y) - Mathf.Abs(transform.position.y)) < 0.1f)
    //       {
    //           if (Mathf.Abs(Mathf.Abs(possiton_count.transform.GetChild(7).transform.position.x) - Mathf.Abs(transform.position.x)) < 0.2f &&
    //           Mathf.Abs(Mathf.Abs(possiton_count.transform.GetChild(7).transform.position.y) - Mathf.Abs(transform.position.y)) < 0.1f)
    //           {
    //               Destroy(gameObject);
    //           }
    //           else
    //           {
    //               i = i + 1;
    //               Debug.Log("Da trung vi tri");
    //           }

    //       }

    //   }
}
