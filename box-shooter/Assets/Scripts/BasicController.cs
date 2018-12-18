using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Horizontal Input = " + Input.GetAxis("Horizontal"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
