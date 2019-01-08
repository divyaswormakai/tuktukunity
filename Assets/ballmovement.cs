using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ballmovement : MonoBehaviour {

    public GameObject ball;
	Vector2 ballposition,startposition;
	float top,bottom,left,right,height,width,angle,speed,loadTime,tempLoadTime;
	float pi = Mathf.PI;
	int p1Life,p2Life,speedCount=0,mode,touchcount=0,maxSpeedCount;

	// Use this for initialization
	void Start () {
		ballposition = ball.transform.position;
		startposition = ballposition;

		float radius =15;

		angle = RandomGenerator();
		Camera cam = Camera.main;
		//get the screen size the screen is in potrait mode so top is left and right is top 
		width = cam.orthographicSize*2f;	
		height = width*cam.aspect;

		top = (height/2)-radius;
		bottom = -((height/2)-radius);
		left = (width/2)-radius;
		right = -((width/2)-radius);
		speed=3f;
		//get play mode
		string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName=="single")
        {
            mode = 1;
			maxSpeedCount = 50;
        }
        else
        {
            mode = 2;
			maxSpeedCount =20;
        }
	}
	
	// Update is called once per frame
	void Update (){	
		// to increase speed while playing for a long time
		if(speedCount <maxSpeedCount){
			if(speedCount == 0){
				tempLoadTime=loadTime;
				speedCount++;
			}
			if(loadTime%7==0 && loadTime!=tempLoadTime){ //increase speed every 5 sec
				tempLoadTime = loadTime;
				speed+=.5f;
				speedCount++;
			}
		}
		if(ballposition.y >= left || ballposition.y <=right){
			angle = 360f-angle;
		}
		if(ballposition.x <= bottom){
			//angle = 180f-angle;
			ReduceLife(1);
		}
		if(ballposition.x >=top){
			if(mode==1){
				angle = 180f-angle;
			}
			else{
				ReduceLife(2);
			}
		}
		
		ballposition.x += Mathf.Cos((pi/180)*angle) *speed;
		ballposition.y += Mathf.Sin((pi/180)*angle) *speed;

		ball.transform.position = ballposition;
		
	}

	float RandomGenerator(){
		int index = Random.Range(0,5);
		if(index == 0){
			angle = Random.Range(30,60);
		}
		else if(index ==1){
			angle = Random.Range(120,150);
		}
		else if(index == 2){
			angle = Random.Range(210,240);
		}
		else{
			angle = Random.Range(300,330);
		}
		//Debug.Log(angle);
		return angle;
	}

	void ReduceLife(int player){
		if(player == 1){
			p1Life--;
		}
		else if(player == 2){
			p2Life--;
		}
		ballposition =startposition;
		angle = RandomGenerator();
		speed =3f;
		speedCount =0;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		string name = coll.collider.name;
		float coll_point_y = coll.GetContact(0).point.y;

		float height = coll.collider.GetComponent<BoxCollider2D>().transform.position.y;

		float touched_point = height-coll_point_y;
		if(name=="bat"){
			angle = -touched_point;
		}
		if(name == "bat2"){
			angle = 180f+touched_point;
		}
		touchcount++; // for single player mode
    }


     
}
