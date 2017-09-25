using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class Constants : MonoBehaviour {
    private static float speedInit = 0.2f;
    private static float sideMoveSpeedInit = 5f;
    public static float speed = 0.2f;
    public static bool isPaused = false;
    public static float sideMoveSpeed = 5f;
    // Use this for initialization
    void Start () {
		
	}
	public static void pauseGame()
    {
        isPaused = true;
        foreach (ObstacleGenerator obsticalGen in FindObjectsOfType<ObstacleGenerator>())
            obsticalGen.activated = false;
        foreach (ObstacleGeneratorENV obsticalGen in FindObjectsOfType<ObstacleGeneratorENV>())
            obsticalGen.activated = false;
        speed = 0f;
        sideMoveSpeed = 0f;
    }
    public static void resumeGame()
    {
        isPaused = false;
        foreach (ObstacleGenerator obsticalGen in FindObjectsOfType<ObstacleGenerator>())
            obsticalGen.activated = true;
        foreach (ObstacleGeneratorENV obsticalGen in FindObjectsOfType<ObstacleGeneratorENV>())
            obsticalGen.activated = true;
        speed = speedInit;
        sideMoveSpeed = sideMoveSpeedInit;
        
    }
	// Update is called once per frame
	void Update () {
		
	}
}
