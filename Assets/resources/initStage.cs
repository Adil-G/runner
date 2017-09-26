﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initStage : MonoBehaviour {
    private GameObject variableForPrefab;
    private float speed = 0.1f;
    // Use this for initialization
    void Start () {
        variableForPrefab = (GameObject)Resources.Load("Track 1", typeof(GameObject));
        ObstacleGeneratorENV obs = gameObject.GetComponent<ObstacleGeneratorENV>();
        GameObject[] obstacles = obs.obstacle;
        List<GameObject> selection = new List<GameObject>();
        foreach (Transform childT in variableForPrefab.GetComponentInChildren<Transform>())
        {

            GameObject child = childT.gameObject;
            //child.transform.localScale = new Vector3(child.transform.localScale.x * 3, child.transform.localScale.y, child.transform.localScale.z);
            /*child.AddComponent<Rigidbody>(); // Add the rigidbody.


            child.GetComponent<Rigidbody>().useGravity = false; // Set the GO's mass to 5 via the Rigidbody.
            child.GetComponent<Rigidbody>().isKinematic = false;*/
            for (int i = 0; i< child.GetComponents<Collider>().Length;i++)
            {
                Collider c = child.GetComponents<Collider>()[i];
                Destroy(c);
            }
            for (int i = 0; i < child.GetComponents<Rigidbody>().Length; i++)
            {
                Rigidbody c = child.GetComponents<Rigidbody>()[i];
                Destroy(c);
            }
            
            if (child.GetComponent<constantSpeed>() == null)
            {
                child.AddComponent<constantSpeed>();
                //child.GetComponent<constantSpeed>().speed = speed;
            }
            else
            {
                //child.GetComponent<constantSpeed>().speed = speed;
            }
            if (child.GetComponent<BoxCollider>() == null)
            {
                child.AddComponent<BoxCollider>();
                child.GetComponent<BoxCollider>().isTrigger = true;
            }
            else
            {
                child.GetComponent<BoxCollider>().isTrigger = true;
            }
            /*
            if (child.GetComponent<MeshCollider>() == null)
            {
                child.AddComponent<MeshCollider>();
                child.GetComponent<MeshCollider>().isTrigger = false;
            }
            else
            {
                child.GetComponent<MeshCollider>().isTrigger = false;
            }*/
            if (child.GetComponent<DestroyByOption>() == null)
            {
                child.AddComponent<DestroyByOption>();
                child.GetComponent<DestroyByOption>().destroyByTime = 0;
                child.GetComponent<DestroyByOption>().destroyByCollision = false;
                child.GetComponent<DestroyByOption>().destroyOutOfScreen = true;
            }
            else
            { 
                child.GetComponent<DestroyByOption>().destroyByTime = 0;
                child.GetComponent<DestroyByOption>().destroyByCollision = false;
                child.GetComponent<DestroyByOption>().destroyOutOfScreen = true;
            }
            FitColliderToChildren(child);
            FitColliderToChildrenBOX(child);
            selection.Add(child);
        }
        obs.obstacle = selection.ToArray();
    }
    private void FitColliderToChildren(GameObject parentObject)
    {
        MeshFilter[] renderers = parentObject.GetComponentsInChildren<MeshFilter>();
        foreach (MeshFilter render in renderers)
        {
            render.gameObject.AddComponent<MeshCollider>();
            render.gameObject.GetComponent<MeshCollider>().sharedMesh = render.sharedMesh;
        }
    }

        
        private void FitColliderToChildrenBOX(GameObject parentObject)
        {
            BoxCollider bc = parentObject.GetComponent<BoxCollider>();
            if (bc == null) { bc = parentObject.AddComponent<BoxCollider>(); }
            Bounds bounds = new Bounds(Vector3.zero, Vector3.zero);
            bool hasBounds = false;
            Renderer[] renderers = parentObject.GetComponentsInChildren<Renderer>();
            foreach (Renderer render in renderers)
            {
                if (!render.gameObject.name.Contains("Ground")
                    && !render.gameObject.name.Contains("Bridge"))
                    continue;
                if (render.gameObject.transform.childCount > 0)
                    continue;
                if (hasBounds)
                {
                    bounds.Encapsulate(render.bounds);
                }
                else
                {
                    bounds = render.bounds;
                    hasBounds = true;
                }
            }
            if (hasBounds)
            {
                bc.center = bounds.center - parentObject.transform.position;
                bc.size = bounds.size;
            }
            else
            {
                bc.size = bc.center = Vector3.zero;
                bc.size = Vector3.zero;
            }
        }

        // Update is called once per frame
        void Update () {
		
	}
}
