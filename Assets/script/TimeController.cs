using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeController : MonoBehaviour {

    public Text TimeLabel;
    float time = 61;
    float alpha = 1.0f;
    bool pause=false;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (pause == false)
        {
            time -= Time.deltaTime;
            time = Mathf.Max(time, 0.0f);
            TimeLabel.GetComponent<Text>().text = string.Format("{0:d}", (int)time);

            if (time < 6.0 && time > 1.0f)
            {
                if (Time.frameCount % 15 == 0)
                {
                    alpha = (alpha == 0.0f) ? 1.0f : 0.0f;
                    TimeLabel.color = new Color(1.0f, 0.0f, 0.0f, alpha);
                }
            }
            else if (time == 0.0f)
            {
                TimeLabel.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            }
        }
	}

    public void Pause(bool p)
    {
        pause = p;
    }

}
