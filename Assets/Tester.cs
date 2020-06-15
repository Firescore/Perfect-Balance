using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Out"))
        {
            this.transform.parent = null;
            if (Rope1.r.weight <= Rope2.r2.weight)
            {
                GameManager.instane.fallDownP1();
                GameManager.instane.fallDown1 = true;
                GameManager.instane.Face_1.SetBool("Scary", true);
            }

            if (Rope1.r.weight >= Rope2.r2.weight)
            {
                GameManager.instane.fallDownP2();
                GameManager.instane.fallDown2 = true;
                GameManager.instane.Face_2.SetBool("Scary", true);
            }

        }
    }
}
