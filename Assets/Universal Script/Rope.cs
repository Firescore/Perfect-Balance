using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    List<GameObject> ropeComponents = new List<GameObject>();
    public List<Rigidbody> rb = new List<Rigidbody>();
    public List<HingeJoint> hg = new List<HingeJoint>();

    public float mass;
    public float drag;
    public float angularDrag;

    // Start is called before the first frame update
    void Start()
    {
        changeRigidBody();
    }
    void changeRigidBody()
    {
        foreach (Transform child in this.transform)
        {
            ropeComponents.Add(child.gameObject);
        }

        for (int i = 0; i < ropeComponents.Count; i++)
        {
            rb.Add(ropeComponents[i].GetComponent<Rigidbody>());
        }
        for (int i = 0; i < ropeComponents.Count; i++)
        {
            hg.Add(ropeComponents[i].GetComponent<HingeJoint>());
        }
        for (int i = 0; i < rb.Count; i++)
        {
            rb[i].mass = mass;
            rb[i].drag = drag;
            rb[i].angularDrag = angularDrag;
        }
    }
    public void removeHG()
    {
        for (int i = 0; i < hg.Count; i++)
        {
        }
    }
}
