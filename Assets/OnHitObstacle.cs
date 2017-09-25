using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnHitObstacle : MonoBehaviour {
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "obstacle")
        {
            //GameObject.Find("Running").transform.position -= Vector3.up * 100;
            Debug.Log("HHIIIITTT!!!");
            SumPause.Status = true;
            //SumScoreExample
        }
    }
}
