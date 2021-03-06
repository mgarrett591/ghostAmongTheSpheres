﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitManager : MonoBehaviour
{
    public float speed = 50f;
    private float RealSpeed;
    public Transform parentBody;
    public Transform childBody;
    public Transform nextBody;
    public float radius;
    public float CoupleLenght = 75;

    public float startingTheta;
    public float LongitudeOfAssendingNode = 0;
    public float Inclination = 0;
    public float focuseDistance = 0;
    public float Semi_majorAxis = 0;
    public float PerigeeDistance = 0;

    private float volocity;
    private float theta = 0;
    private float x;
    private float z;
    

    //arch lenght formula D = 2 * PI * radius * theta
    //rearranged theta = D / (2 * PI * radius)

    // Start is called before the first frame update
    void Start()
    {
        radius = Vector3.Distance(parentBody.position, childBody.position);
        volocity = speed;
        theta = startingTheta % 360;
        //Debug.Log(radius);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            volocity = speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            volocity = - speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            volocity = 0;
        }
        if(nextBody != null && CoupleLenght > Vector3.Distance(childBody.position, nextBody.position))
        {
            return;
        }
        theta = (theta + (volocity * Time.deltaTime) / (2 * Mathf.PI * radius)) % 360;
        Debug.Log(volocity);
        x = radius * Mathf.Cos(theta);
        z = radius * Mathf.Sin(theta);
        //Debug.Log(radius * (1 / Mathf.Sin(theta)) + ":" + radius * (1 / Mathf.Tan(theta)));
        childBody.position = parentBody.position + new Vector3 (radius * Mathf.Cos(theta), 0, radius * Mathf.Sin(theta));
        //childBody.position = parentBody.position + new Vector3(x, (z * .5f) + (x * .5f) , z);  //Apex NE
        //childBody.position = parentBody.position + new Vector3(x, (z * .5f) + (x * - .5f), z); //Apex NW
        //childBody.position = parentBody.position + new Vector3(x, (z * - .5f) + (x * .5f), z); //Apex SE
        //childBody.position = parentBody.position + new Vector3(x, (z * -.5f) + (x * -.5f), z);   //Apex SW
        //childBody.position = parentBody.position + new Vector3(x, (x), z); //Apex E
        //childBody.position = parentBody.position + new Vector3(x, (z), z);   // Apex N
        //childBody.position = parentBody.position + new Vector3(x, (-x), z); //Apex W
        //childBody.position = parentBody.position + new Vector3(x, (-z), z); //Apex S
    }
}
