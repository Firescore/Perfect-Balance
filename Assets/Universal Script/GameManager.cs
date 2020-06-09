using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instane;

    public float speed;


    public GameObject Player_1; 
    public GameObject Player_2;
    //public GameObject active;

    public Rigidbody P1;
    public Rigidbody P2;

    [SerializeField]
    Vector3 Player1_initialPos;
    [SerializeField]
    Vector3 Player2_initialPos;

    public bool gameStarted = false;
    public bool removeGravity = false;
    bool mouseclick = false;

    public List<GameObject> weight = new List<GameObject>();
    private void Start()
    {
        instane = this;
        if(P1 || P2 == null)
        {
            P1 = Player_1.GetComponent<Rigidbody>();
            P2 = Player_2.GetComponent<Rigidbody>();
        }
        
    }


    private void Update()
    {
        startGame();


    }
    void startGame()
    {
        if (gameStarted)
        {
            if (P1.mass == P2.mass && weight.Count == 3)
            {
                removeGravity = true;
                if (removeGravity)
                {
                    P1.isKinematic = true;
                    P2.isKinematic = true;
                    FindObjectOfType<Rope>().removeHG();
                    Player_1.transform.position = /*Player1_initialPos;*/Vector3.Lerp(this.transform.position, Player1_initialPos,speed);
                    Player_2.transform.position = /*Player2_initialPos;*/Vector3.Lerp(this.transform.position, Player2_initialPos,speed);
                }
            }
        }

        if (Input.GetMouseButtonDown(0) && !mouseclick)
        {
            gameStarted = true;
            Player1_initialPos = Player_1.transform.position;
            Player2_initialPos = Player_2.transform.position;
            mouseclick = true;
        }
    }

}
