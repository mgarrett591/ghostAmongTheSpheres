using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitManager : MonoBehaviour
{
    public float tacometer = 0f;
    public float speed = 100f;
    public Transform parentBody;
    public Transform childBody;
    public float radius;

    private float theta;
    //arch lenght formula D = 2 * PI * radius * theta
    //rearranged theta = D / (2 * PI * radius)

    // Start is called before the first frame update
    void Start()
    {
        radius = Vector3.Distance(parentBody.position, childBody.position);
        //Debug.Log(radius);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return)){
            Debug.Log(radius * Mathf.Sin(theta) + ":" + radius * Mathf.Tan(theta));
        }
        tacometer += speed * Time.deltaTime;
        theta = tacometer / (2 * Mathf.PI * radius);
        //Debug.Log(radius * (1 / Mathf.Sin(theta)) + ":" + radius * (1 / Mathf.Tan(theta)));
        childBody.position = new Vector3 (radius * Mathf.Cos(theta), 0, radius * Mathf.Sin(theta));

    }
}
