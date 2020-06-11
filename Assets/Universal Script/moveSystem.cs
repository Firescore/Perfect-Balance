using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveSystem : MonoBehaviour
{
    float startPosX;
    float startPosY;

    float player_1X;
    float player_1Y;
    float player_2X;
    float player_2Y;

    [SerializeField]
    private float forcePlayer_1 = 0;
    [SerializeField]
    private float forcePlayer_2 = 0;

    public GameObject player_1, player_2;
    bool mouseMoving = false;
    bool mouseUp = false, attached = false;
    public float weight;

    Vector3 resetPos;
    // Start is called before the first frame update
    void Start()
    {
        resetPos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseMoving)
            moveWeight();
        if (mouseUp)
            addForce();

            /*///
            if (GameManager.instane.force_1 > forcePlayer_2)
            {
                GameManager.instane.force_1 -= Mathf.Abs(forcePlayer_1 - forcePlayer_2);
            }
            if (GameManager.instane.force_1 < forcePlayer_2)
            {
                GameManager.instane.force_1 += Mathf.Abs(forcePlayer_2 - forcePlayer_1);
            }
            ///

            /////////////////////////////////////////////
            /////////////////////////////////////////////
        
            ///
            if (GameManager.instane.force_2 > forcePlayer_1)
            {
                GameManager.instane.force_2 -= Mathf.Abs(forcePlayer_2 - forcePlayer_1);
            }
            if (GameManager.instane.force_2 < forcePlayer_1)
            {
                GameManager.instane.force_2 += Mathf.Abs(forcePlayer_1 - forcePlayer_2);
            }*/
        ///

    }

    void moveWeight()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.localPosition.z);
    }
    private void OnMouseDown()
    {
        mouseUp = false;
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;
            mouseMoving = true;
        }
    }
    private void OnMouseUp()
    {
        mouseMoving = false;
         player_1X = Mathf.Abs(this.transform.localPosition.x - player_1.transform.position.x);
         player_2X = Mathf.Abs(this.transform.localPosition.x - player_2.transform.position.x);
         player_1Y = Mathf.Abs(this.transform.localPosition.y - player_1.transform.position.y);
         player_2Y = Mathf.Abs(this.transform.localPosition.y - player_2.transform.position.y);
        mouseUp = true;
        /* 
        agar player 1 pe 7 force down apply hota hai toh player 2 pe 7 ka up force apply kro
        agar player 1 already 7 ka force and player 2 pe 3 ka foce apply kar rahe hai toh :player1 pe 7-3 = 4 ka down and player 2 pe 4 ka up foece apply kaarana hai :
        agar player 1 pe 4 ka down and player 2 pe again 4 ka force apply kiya toh dono player ka force 0 karana hai
       */
        if ((player_1X <= 1f && player_1Y <= 1f) || (player_2X <= 1f && player_2Y <= 1f))
        {
            if (player_1X <= 1f && player_1Y <= 1f)
            {
                Rope1.r.weight += weight;
                this.transform.position = GameManager.instane.Player_1.transform.position;
                this.transform.parent = GameManager.instane.Player_1.transform;
                GameManager.instane.weight.Add(this.gameObject);



               // attached = true;

                /*
                                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                GameManager.instane.P1.AddForce(Vector3.down * GameManager.instane.force_1, ForceMode.Impulse);
                                GameManager.instane.P1.AddForce(Vector3.up * GameManager.instane.force_2, ForceMode.Impulse);
                                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////*/
                ///

                if (!attached)
                {
                   
                }


            }
            if ((player_2X <= 1f && player_2Y <= 1f))
            {
                Rope2.r2.weight += weight;
                this.transform.position = GameManager.instane.Player_2.transform.position;
                this.transform.parent = GameManager.instane.Player_2.transform;
                GameManager.instane.weight.Add(this.gameObject);




                //attached = true;

                /*
                                ////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                GameManager.instane.P2.AddForce(Vector3.down * GameManager.instane.force_2, ForceMode.Impulse);
                                GameManager.instane.P2.AddForce(Vector3.up * GameManager.instane.force_1, ForceMode.Impulse);
                                ////////////////////////////////////////////////////////////////////////////////////////////////////////////*/

                if (!attached)
                {
                    
                }


            }
        }
        else
        {
            this.transform.localPosition = new Vector3(resetPos.x, resetPos.y, resetPos.z);
        }

    }
    
    void addForce()
    {
       
    }
}
