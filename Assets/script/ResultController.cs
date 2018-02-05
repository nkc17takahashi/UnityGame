using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultController : MonoBehaviour {

    public Text comment;
    [SerializeField]
    GameObject GD,SB;
    bool dis = false;
    float head, body,timeUD,timeBD;
    int Snum=1,CSnum=0,LUCcou,DCcou=0;
    string[] sentences; //文章
    string NSen;/*
    [SerializeField,Tooltip("インターバル")][Range(0.001f, 0.3f)]
    float interval;
    */
	// Use this for initialization
	void Start ()
    {
        GD = GameObject.Find("GameDirector");
        SB = GD.GetComponent<Result_Transition>().Set_Sman();
        head = GD.GetComponent<Result_Transition>().get_Head();
        body = GD.GetComponent<Result_Transition>().get_Body();

        //set_sentence();

        if (head > body) comment.text = "体より頭の方が大きくない？ 次こそはちゃんと作ってほしいなぁ…";
        else comment.text= "上手に作ってくれてありがとう！"; ;

        //comment.text = sentences[Snum];

        /*
        NSen = sentences[Snum];
        timeUD = NSen.Length * interval;
        timeBD = Time.time;
        LUCcou = 0;
        */
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //Destroy(SB.gameObject);
            //Destroy(GD.gameObject);
            SceneManager.LoadScene("Title");
        }
        /*
        if (IsDisplayComplate())
        {
            Debug.Log("dis = true");
            dis = true;
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                timeUD = 0;
            }
        }
        */

        /*
        DCcou = (int)(Mathf.Clamp01((Time.time - timeBD) / timeUD) * NSen.Length);
        Debug.Log(DCcou);
        if(DCcou != LUCcou)
        {
            comment.text = NSen.Substring(0, DCcou);
            LUCcou = DCcou;
        }
        */
	}
    
    /*
    bool IsDisplayComplate()
    {
        return Time.time > timeBD + timeUD;
    }
    */
    void set_sentence()
    {
        sentences[0] = "体より頭の方が大きくない？ 次こそはちゃんと作ってほしいなぁ…";
        sentences[1] = "上手に作ってくれてありがとう！";
    }
}
