﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowAlien : MonoBehaviour {

    private Vector2 velocity;

    public float cameraX = 2f;

    public float smoothTimeX;
    public float smoothTimeY;

    public GameObject player;

	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player");

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX + cameraX, posY, transform.position.z);
	}
}
