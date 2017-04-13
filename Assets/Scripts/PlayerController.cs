using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rgbd2d;
    Animator anim;
    private float playerSpeed = 2f;
    private float jumpHeight = 300f;

	// Use this for initialization
	void Start () {
        rgbd2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        if(Input.GetAxis("Horizontal") > 0)
        {
            transform.Translate(Vector2.right * playerSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.Translate(Vector2.right * playerSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }
        if (Input.GetButtonDown("Jump"))
        {
            rgbd2d.AddForce(Vector2.up * jumpHeight);
        }

    }
}
