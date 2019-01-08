using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class batmovement : MonoBehaviour {

    public GameObject bat1,bat2;
    Vector2 temp;
    static int playercount = 1;
    int speed = 5;
	float top,bottom;
	// Use this for initialization
	void Start () {
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName=="single")
        {
            bat2 = null;
            playercount = 1;
        }
        else
        {
            playercount = 2;
        }
		top = Screen.height /2;
		bottom = -top;
	}
	
	// Update is called once per frame
	void Update () {
        if(playercount == 1)
        {
            SinglePlayerMode();
        }
        if(playercount == 2)
        {
            MultiPlayerMode();
        }

	}

    void SinglePlayerMode()
    {
        if (Input.touchCount > 0)
        {
            Debug.Log("Toucheddd");
            Touch input = Input.GetTouch(0);
            if(input.deltaPosition.y > 0)
            {
                //if(bat1.transform.position > Screen.height)
                Debug.Log("Change is direction Y");
               // bat1Position.y += input.deltaPosition.y * speed;
                //bat1.transform.position = bat1Position;
            }
        }

        if(Input.GetKey(KeyCode.W)){
            MoveUp(bat1);
        }
        if(Input.GetKey(KeyCode.S)){
            MoveDown(bat1);
        }

    }

    void MultiPlayerMode()
    {
        if(Input.GetKey(KeyCode.W)){
            MoveUp(bat1);
        }
        if(Input.GetKey(KeyCode.S)){
            MoveDown(bat1);
        }
        if(Input.GetKey(KeyCode.UpArrow)){
            MoveUp(bat2);
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            MoveDown(bat2);
        }
    }
	void MoveUp(GameObject bat){
		temp = bat.transform.position;
		if(temp.y <= top){	
			temp.y += speed;
			bat.transform.position = temp;
		}
	}

	void MoveDown(GameObject bat){
		temp = bat.transform.position;
		if(temp.y>=bottom){
			temp.y -= speed;
			bat.transform.position = temp;
		}
	}

    public int GetPlayerCount(){
        return playercount;
    }
}
