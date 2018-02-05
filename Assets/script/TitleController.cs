using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour {

    public Text TS; //Touch Screenのテキスト
    [SerializeField,Tooltip("シーンの遷移先")]
    string Sname;
    float alpha=1.0f;
    bool fade=false;

	// Use this for initialization
	void Start ()
    {
        alpha = 1.0f / 30.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Touch Screen点滅
        if(Time.frameCount % 30 == 0)
        {
            fade = !(fade);
        }

        if (fade)
        {
            TS.color += new Color(0.0f, 0.0f, 0.0f, alpha);
        }
        else
        {
            TS.color -= new Color(0.0f, 0.0f, 0.0f, alpha);
        }


        //ゲーム画面遷移
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(Sname);
        }
	}
}
