using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class menuscript : MonoBehaviour,IPointerClickHandler {

    int gameindex=0;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Pointer touched:::" + name);
        if (name == "single")
        {
            gameindex = 1;
        }
        else if (name == "multi")
        {
            gameindex = 2;
        }
    }

    // Use this for initialization
    void Start () {
        
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameindex != 0)
        {
            switch (gameindex)
            {
                case 1:
                    SceneManager.LoadScene("single");
                    break;
                case 2:
                    SceneManager.LoadScene("multi");
                    break;
            }
        }
    }
}
