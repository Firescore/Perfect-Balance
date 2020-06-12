using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotator : MonoBehaviour
{
    public static WheelRotator wr;

    float angle;
    public void Start()
    {
        wr = this;
    }
    public void rotator(float sign, float speed)
    {
        angle += Time.deltaTime * speed * sign;
        transform.localRotation = Quaternion.Euler(0, 0, -angle);
    }
}
