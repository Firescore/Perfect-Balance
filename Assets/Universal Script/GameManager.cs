using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instane;

    public float speed;


    public GameObject Player_1; 
    public GameObject Player_2;


    [Header("---------------------")]
    public Transform Rope1;
    public Transform Rope2;

    [Header("---------------------")]
    public Animator anime1;
    public Animator anime2;

    public Vector3 endPos1;
    public Vector3 endPos2;

    public bool gameStarted = false;
    public bool removeGravity = false;


    public List<GameObject> weight = new List<GameObject>();
    private void Start()
    {
        instane = this;
/*        if(P1 || P2 == null)
        {
            P1 = Player_1.GetComponent<Rigidbody>();
            P2 = Player_2.GetComponent<Rigidbody>();
        }*/
        
    }
    private void Update()
    {
        if(weight.Count == 3 && !removeGravity)
        {
/*            endPos1 = Player_1.transform.position;
            endPos2 = Player_2.transform.position;*/


            
            removeGravity = true;
        }
    }
    public void endRotateL()
    {
        if (Rope1.position.y < Rope2.position.y)
        {
            WheelRotator.wr.rotator(-1,75);
        }
    }   
    public void endRotateR()
    {
        if (Rope1.position.y > Rope2.position.y)
        {
            WheelRotator.wr.rotator(1,75);
        }
    }
}
