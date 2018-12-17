using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMover : MonoBehaviour
{

    public float spinSpeed = 180.0f;

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Rotate(Vector3.up * this.spinSpeed * Time.deltaTime);
    }
}
