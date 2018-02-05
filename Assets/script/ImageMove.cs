using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageMove : MonoBehaviour {

    public GameObject snowball;
    public Text ScaleUI;
    bool flg = false;
    [SerializeField,Tooltip("Rotate.Z")]
    float RttZ;
    [SerializeField, Tooltip("Scale")]
    float Scale;
    [SerializeField, Tooltip("Scale(Memory)")]
    float Mem;

    // Use this for initialization
    void Start ()
    {
        Mem = Scale;
    }
	
	// Update is called once per frame
	void Update ()
    {
        flg = snowball.GetComponent<MoveController>().OnFrag();

        if (flg == true)
        {
            transform.Rotate(0.0f, 0.0f, -RttZ);
        }

        Scale = (snowball.transform.localScale.x + snowball.transform.localScale.y + snowball.transform.localScale.z) / 3;
        if (Mem < Scale)
        {
            ScaleUI.text = string.Format("{0:F1}", Scale);
            Mem = Scale;
        }
	}
}
