using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scripts : MonoBehaviour {
    private float moveKey = 0.5f;
    public float sideMoveSpeed = Constants.sideMoveSpeed;
	// Use this for initialization
	void Start () {
        animator.SetFloat("move", moveKey);
        animator.SetBool("jump_again", false);
    }
	
	// Update is called once per frame
	void Update () {
        /*if(animator.GetBool("jump"))
        {
            transform.GetComponent<Collider>().isTrigger = true;
        }
        else
        {
            transform.GetComponent<Collider>().isTrigger = false;
        }*/
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("slide", false);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("slide", true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("jump", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("jump", true);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            moveKey = Mathf.Lerp(0.3f, 0.5f, Time.time * -1);
            
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            moveKey = Mathf.Lerp(0.5f, 0.7f, Time.time * 1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetFloat("move", moveKey);
            transform.Translate(Vector3.left * sideMoveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetFloat("move", moveKey);
            transform.Translate(Vector3.right * sideMoveSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetFloat("move", 0.5f);
        }
    }
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
        
    }
    
}
