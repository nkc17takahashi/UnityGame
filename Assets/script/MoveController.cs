using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {
    
    public GameObject SB,Tcon;
    Rigidbody rig,SBrig;
    RaycastHit hit;
    Vector3 Pos, R_Vec,SB_vec;
    bool flg;
    float scale;

    [SerializeField, Tooltip("ポーズ")]
    bool pause;
    [SerializeField, Tooltip("速度")]
    float speed;
    [SerializeField, Tooltip("速度の最大値")]
    float max;
    [SerializeField, Tooltip("maxの最大値")]
    float max_s;
    [SerializeField, Tooltip("maxの最小値")]
    float min_s;
    [SerializeField, Tooltip("Rigidbodyの速度")]
    float R_speed;
    [SerializeField, Tooltip("Rigidbodyの速度")]
    string Tag;


	// Use this for initialization
	void Start ()
    {
        flg = false;
        rig = GetComponent<Rigidbody>();
        SBrig = SB.GetComponent<Rigidbody>();
        //speed = 1.0f;
        //max = 10.0f;
    }
	
	// Update is called once per frame
	void Update ()
    {

        //クリックした時
        if (Input.GetMouseButtonDown(0) && pause == false)
        {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 5, false);
                if ((Physics.Raycast(ray, out hit, Mathf.Infinity)) && 
                        hit.collider.tag == Tag && flg == false)
                {
                    flg = true;
                }
        }

        // ray が object に当たっている時
        if (flg == true && pause ==false)
        {
            //移動
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit, Mathf.Infinity);
            float x = Mathf.RoundToInt(hit.point.x);
            float z = Mathf.RoundToInt(hit.point.z);
            Pos = new Vector3(x, 0.0f, z);

            //雪玉が転がる方向
            Vector3 vec = Pos-transform.position;
            vec.y = 0.0f;
            if (vec.magnitude < 1.0f)
            {
                vec = new Vector3(0.0f, 0.0f, 0.0f);
            }

            //スピード制限
            if (max <= speed)
            {
                speed = max;
            }
            else
            {
                speed += 0.5f;
            }

            //転がす
            rig.velocity = vec.normalized * speed;
        }

        //クリックをはなした時
        if (Input.GetMouseButtonUp(0))
        {
            flg = false;
        }

        // max の値変更
        scale = (transform.localScale.x + transform.localScale.y + transform.localScale.z) / 3.0f;
        max = 50.0f / scale;

        if(max > max_s)
        {
            max = max_s;
        }
        else if(max < min_s)
        {
            max = min_s;
        }

        //大きさの変更
        R_speed = rig.velocity.magnitude;
        if (R_speed > 3.0)
        {
            R_Vec.x = Mathf.Abs(rig.velocity.normalized.x);
            R_Vec.z = Mathf.Abs(rig.velocity.normalized.z);

            R_Vec.y = (R_Vec.x + R_Vec.z)/2;


            transform.localScale += R_Vec * Time.deltaTime * 0.5f;
        }
        
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "snowball" || other.tag == "snowball2")
        {
            pause = true;
            if (SBrig.velocity.magnitude < rig.velocity.magnitude)
            {
                Tcon.GetComponent<Result_Transition>().set_Head(scale);
                SB_vec = transform.position - SB.transform.position;
                transform.parent = SB.transform;
                rig.isKinematic = true;
                SB.transform.Rotate(SB_vec.normalized * 90);
                Tcon.GetComponent<TimeController>().Pause(pause);
                Invoke("RT", 5.0f);
            }
            else
            {
                //GetComponent<SmanDesController>().enabled = true;
                //GetComponent<SmanDesController>().transition();
                transform.tag = "SnowMan";
                Tcon.GetComponent<Result_Transition>().set_Body(scale);
            }
            flg = false;
            SBrig.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            rig.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }
    void RT()
    {
        Tcon.GetComponent<Result_Transition>().Transition(SB);
    }

    public bool OnFrag()
    {
        return flg;
    }
}
