using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collision : MonoBehaviour {
	int mode;
	// Use this for initialization
	void Start () {
		string scenename= SceneManager.GetActiveScene().name;
		if(scenename == "single"){
			mode =1;
		}
		else{
			mode =2;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	Vector2 EnemyPosition(){
		Vector2 position = new Vector2(0,0);
		if(mode==1){
			position.x = Random.Range(0,120);
			position.y = Random.Range(-100,100);
		}
		else if(mode==2){
			position.x = Random.Range(-60,60);
			position.y = Random.Range(-100,100);
		}
		return position;
	}

}
