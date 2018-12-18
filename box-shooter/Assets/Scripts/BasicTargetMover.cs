using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTargetMover : MonoBehaviour
{
    public bool hasSpin = true;
    public float spinSpeed = 180.0f;
    public bool hasMotion = false;
    public float motionMagnitude = 0.1f;

    void Update()
    {
        if (this.hasSpin) {
            this.gameObject.transform.Rotate(Vector3.up * this.spinSpeed * Time.deltaTime);
        }
        if (this.hasMotion) {
            this.gameObject.transform.Translate(Vector3.up * this.motionMagnitude * Mathf.Cos(Time.timeSinceLevelLoad));            
        }
    }
}
