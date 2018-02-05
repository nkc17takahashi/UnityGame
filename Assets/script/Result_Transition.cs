using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Result_Transition : MonoBehaviour {

    public GameObject Can,fance,SnowMan;
    static float head, body;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public void Transition(GameObject Sman)
    {
        SnowMan = Sman;
        //DontDestroyOnLoad(Sman);
        //DontDestroyOnLoad(this);
        //SceneManager.LoadScene("Result");
        Destroy(Can);
        Destroy(fance);
        SceneManager.LoadScene("Result",LoadSceneMode.Additive);
    }
    public void set_Head(float Hscale)
    {
        head = Hscale;
    }
    public void set_Body(float Bscale)
    {
        body = Bscale;
    }

    public float get_Head()
    {
        return head;
    }
    public float get_Body()
    {
        return body;
    }

    public GameObject Set_Sman()
    {
        return SnowMan;
    }

}
