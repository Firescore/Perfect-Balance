using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instane;
    public GameObject Player_1; 
    public GameObject Player_2;
    //public GameObject active;

    public Rigidbody P1;
    public Rigidbody P2;


    bool gameStarted = false;
    private void Start()
    {
        instane = this;
        //active.SetActive(false);
        P1 = Player_1.GetComponent<Rigidbody>();
        P2 = Player_2.GetComponent<Rigidbody>();
    }


/*    private void Update()
    {
        if (gameStarted)
        {
            if (P1.mass == P2.mass)
            {
                active.SetActive(true);
            }
        } 
    }*/
    
}
