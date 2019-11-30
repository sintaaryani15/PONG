﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	
	[SerializeField]
	float speed;
	float radius;
	Vector2 direction ;
	
	
    // use this for initialization
    void Start()
    {
        direction = Vector2.one.normalized;//direction is (1,1) normalLized
		radius = transform.localScale.x / 2; //half the width
		
    }

    // Update is called once per frame
    void Update()
    {
		transform.Translate (direction * speed * Time.deltaTime);
		
		//bounce of tom and bottom
		if (transform.position.y < GameManager.bottomLeft.y + radius && direction.y < 0){
			direction.y = -direction.y;
		}
		
		if (transform.position.y > GameManager.topRight.y - radius && direction.y > 0){
			direction.y = -direction.y;
		}
        //game over
		
		if (transform.position.x < GameManager.bottomLeft.x + radius && direction.x < 0){
			
			Debug.Log("Right player wins !!");
			//for now, just freeze time
		Time.timeScale = 0 ;
		enabled = false ;//stop updating script
			
		}
		
				
		if (transform.position.x > GameManager.topRight.x + radius && direction.x > 0){
			Debug.Log("Left player wins !!");
			//for now, just freeze time
		Time.timeScale = 0 ;
		enabled = false ; //stop updating script
			
			
		
		
		
		}
    }

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Paddle") {
			bool isRight = other.GetComponent<Paddle>().isRight;
			
			
			//if hitting right paddle and moving right,flip direction
			if (isRight == true && direction.x > 0) {
				direction.x = -direction.x ;
				
			}
			//if hitting left paddle and moving right,flip direction
			if (isRight == false && direction.x < 0) {
				direction.x = -direction.x ;
				
			}
	}
	}
}

	