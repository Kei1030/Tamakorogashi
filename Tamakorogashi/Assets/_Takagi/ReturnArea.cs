using System.Collections;
using UnityEngine;

public class ReturnArea : MonoBehaviour {

    private Transform returnPoint;  // 初期化時の位置
    private float initX;
    private float initY;
    private float initZ;

    // Use this for initialization
    void Start () {
        returnPoint = GameObject.Find("_PlayerBall").transform;
        initX = returnPoint.position.x;
        initY = returnPoint.position.y;
        initZ = returnPoint.position.z;
    }

    private void OnTriggerEnter(Collider c)
    {
        Debug.Log(c.gameObject.tag);

        if (c.gameObject.CompareTag("Player"))
        {            
            StartCoroutine("returnCharacter", c.gameObject);
        }
    }

    private IEnumerator returnCharacter(GameObject ball)
    {
        yield return new WaitForSeconds(1f);
       // 球の位置を戻す
        ball.transform.position = new Vector3(initX, initY, initZ);

        // 球を止める
        Rigidbody rbBall = ball.transform.GetComponent<Rigidbody>();

        rbBall.velocity = Vector3.zero;
        rbBall.angularVelocity = Vector3.zero;
    }


}
