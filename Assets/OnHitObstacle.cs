using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnHitObstacle : MonoBehaviour {
    SumScoreExample scoreBoard;
    int count = 0;
    const int MAX = 50;
    const int EVADE = 200;
    public void Awake()
    {
    }
    public void FixedUpdate()
    {
        if (count++ > MAX)
        {
            count = 0;
            if (scoreBoard != null)
            {
                scoreBoard.AddPoints((int)((1 + Time.deltaTime) * Constants.timeScore));
            }
            else
            {
                scoreBoard = new SumScoreExample();
                scoreBoard.AddPoints((int)((1 + Time.deltaTime) * Constants.timeScore));
            }
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "obstacle")
        {
            if(gameObject.tag == "Player")
            {
                if (scoreBoard != null)
                {
                    scoreBoard.AddPoints(EVADE);
                }
                else {
                    scoreBoard = new SumScoreExample();
                    scoreBoard.AddPoints(EVADE);
                }
                   
            }
            else
            {
                //GameObject.Find("Running").transform.position -= Vector3.up * 100;
                Debug.Log("HHIIIITTT!!!");
                SumPause.Status = true;
                //SumScoreExample
            }

        }
    }
}
