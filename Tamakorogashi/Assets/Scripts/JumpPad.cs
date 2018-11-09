using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour {

    public float jumpPower = 500f;
    public ParticleSystem particle;
    private AudioSource jumpSound;

	// Use this for initialization
	void Start () {
        jumpSound = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Rigidbody rd = other.GetComponent<Rigidbody>();
            Vector3 force = new Vector3(0, jumpPower, 0);
            rd.AddForce(force);

            //衝突時、パーティクル再生 by山中
            particle.Play();
            //音再生
            jumpSound.PlayOneShot(jumpSound.clip);


            Debug.Log("Jump!");
        }    
    }
}
