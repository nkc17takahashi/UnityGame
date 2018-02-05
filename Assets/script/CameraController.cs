using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    
    GameObject snowman;

	// Use this for initialization
	void Start ()
    {
        snowman = GameObject.Find("snowball");
        transform.position += snowman.transform.position + snowman.transform.localScale;
    }
	
	// Update is called once per frame
	void Update ()
    {
	}
}
