using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{

    public MeshRenderer meshRenderer;
    public Rigidbody body;
    public Material material;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();

        body.AddForce(0, 500, 0);
        material.SetColor("_Color", Color.cyan);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(0, 500, 0);
        }
    }
}
