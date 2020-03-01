using System.Collections;
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
    private float volocity;
    private float theta;
    private float x;
    private float z;

    //arch lenght formula D = 2 * PI * radius * theta
    //rearranged theta = D / (2 * PI * radius)

    // Start is called before the first frame update
    void Start()
    {
        radius = Vector3.Distance(parentBody.position, childBody.position);
        volocity = speed;
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

        if (Input.GetKey(KeyCode.Return)){
            Debug.Log(radius * Mathf.Sin(theta) + ":" + radius * Mathf.Tan(theta));
        }
        if(nextBody != null && CoupleLenght > Vector3.Distance(childBody.position, nextBody.position))
        {
            return;
        }
        theta = (theta + volocity / (2 * Mathf.PI * radius)) % 360;
        Debug.Log(volocity);
        x = radius * Mathf.Cos(theta);
        z = radius * Mathf.Sin(theta);
        //Debug.Log(radius * (1 / Mathf.Sin(theta)) + ":" + radius * (1 / Mathf.Tan(theta)));
        childBody.position = new Vector3 (radius * Mathf.Cos(theta), 0, radius * Mathf.Sin(theta));
        //childBody.position = new Vector3(x, (z * .5f) + (x * .5f) , z);  //Apex NE
        //childBody.position = new Vector3(x, (z * .5f) + (x * - .5f), z); //Apex NW
        //childBody.position = new Vector3(x, (z * - .5f) + (x * .5f), z); //Apex SE
        //childBody.position = new Vector3(x, (z * -.5f) + (x * -.5f), z);   //Apex SW
        //childBody.position = new Vector3(x, (x), z); //Apex E
        //childBody.position = new Vector3(x, (z), z);   // Apex N
        //childBody.position = new Vector3(x, (-x), z); //Apex W
        //childBody.position = new Vector3(x, (-z), z); //Apex S
    }
}
