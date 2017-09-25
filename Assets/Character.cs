using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    RaycastHit hit;
    bool started = false;
    float count = 0;
    int hash;
    // Use this for initialization
    void Start()
    {
        hash = Animator.StringToHash("Base.jump");
    }

    // Update is called once per frame
    void Update()
    {

        //Animator.StringToHash("Base.jump")
        //Debug.Log(GameObject.Find("Running").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).nameHash);
        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            Debug.DrawLine(transform.position, hit.point, Color.cyan);
            started = true;
            GameObject.Find("Running").GetComponent<Rigidbody>().useGravity = true;
        }
        if (started)
        {
            if (Physics.Raycast(transform.position, -Vector3.up, out hit))
            {
                count = 0;
            }
            else if (!GameObject.Find("Running").GetComponent<Animator>().GetBool("jump"))
            {
                Debug.Log(count);
                if (count++ > 15f)
                {
                    //GameObject.Find("Running").transform.position -= Vector3.up * 100;
                    started = false;
                }
            }
        }
    }
}
