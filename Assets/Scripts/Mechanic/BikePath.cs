using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikePath : MonoBehaviour
{
    private BikeFollow Biker;
    public Transform[] PathToFollow;
    public GameObject bike;
    public int PathIndex = 0;
    

    public void PathLine()
    {
        if (PathToFollow == null || PathToFollow.Length < 2)
        {
            return;
        }

        for (int i = 1; i < PathToFollow.Length; i++)
        {
            Gizmos.DrawLine(PathToFollow[i - 1].position, PathToFollow[i].position);
        }
    }

    //void Update()
    //{
    //    if (transform.position == PathToFollow[PathIndex].transform.position)
    //    {
    //        PathIndex += 1;
    //    }

    //    if (PathIndex == PathToFollow.Length)
    //    {
    //        PathIndex = 0; 
    //        //Destroy(bike);
    //    }    
    //}
}
