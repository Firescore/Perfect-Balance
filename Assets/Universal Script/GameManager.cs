using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instane;

    public Rope1 r1;
    public Rope2 r2;
    [Header("---------------------")]
    public float speed;
    public float CrocoSpeed;
    public float weightLooseSpeed;

    [Header("---------------------")]
    public GameObject Player_1; 
    public GameObject Player_2;

    [Header("---------------------")]
    public GameObject sidePlayer_1;
    //public GameObject sidePlayer_2;
    public GameObject Croco1;
    public GameObject Croco2;

    public GameObject waterlevel1;
    public GameObject waterlevel2;
    public GameObject confetti;

    [Header("Weights")]
    public GameObject weight1;
    public GameObject weight2;
    public GameObject weight3;

    [Header("---------------------")]
    public float D1;
    public float D2;

    [Header("---------------------")]
    public Transform Rope1;
    public Transform Rope2;
    public Transform comettiePos;
    public Transform c1;
    public Transform c2;

    [Header("---------------------")]
    public Animator anime1;
    public Animator anime2;
    public Animator croco1;
    public Animator croco2;
    public Animator Face_1;
    public Animator Face_2;

    public Vector3 endPos1;
    public Vector3 endPos2;

    public bool gameStarted = false;
    public bool gameOver = false;
    public bool fallDown1 = false;
    public bool fallDown2 = false;

    bool comettieEffect = false;
    bool isPlayer1Died = false;
    bool isPlayer2Died = false;
    bool isParantSetTrue1 = false;
    bool isParantSetTrue2 = false;

    public List<GameObject> weight = new List<GameObject>();
    private void Start()
    {
        instane = this;
         comettieEffect = false;
         isPlayer1Died = false;
         isPlayer2Died = false;


        Player_1.GetComponent<Rigidbody>().isKinematic = true;
        Player_2.GetComponent<Rigidbody>().isKinematic = true;
        sidePlayer_1.GetComponent<Rigidbody>().isKinematic = true;
    }
    private void Update()
    {
        if(weight.Count == 3 && !gameOver)
        {
            gameOver = true;
        }
        distacne_R1();
        distacne_R2();
        GameOver();
        weightLoose();
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



    public void GameOver()
    {
        if (gameOver)
        {
            if(r1.weight == r2.weight)
            {
                if (croco1 != null)
                    croco1.SetBool("Exit", true);

                if (croco2 != null)
                    croco2.SetBool("Exit", true);

                if (Croco1 != null)
                {
                    if (Croco1.transform.position.y <= -2.30f)
                        Destroy(Croco1, 1f);
                }

                if (Croco2 != null)
                {
                    if (Croco2.transform.position.y <= -2.30f)
                        Destroy(Croco2, 1f);
                }
            }

            if(r2.normalize && !comettieEffect)
            {
                Destroy(Instantiate(confetti, comettiePos.position, Quaternion.identity),3);
                comettieEffect = true;
            }
        }

    }
    public void distacne_R1()
    {
        D1 = Mathf.Abs(Rope1.transform.position.y - waterlevel1.transform.position.y);
        if (D1 < 1f && !isParantSetTrue1 && !fallDown1)
        {
            //Player_1.transform.parent = null;
            Player_1.transform.position = new Vector3(1.771f, -5.4f, -2.82f);
            sidePlayer_1.transform.position = new Vector3(2.443927f, -5.714768f, -1.635189f);

            Player_1.transform.rotation = Quaternion.Euler(-150.211f, -90, -90);
            sidePlayer_1.transform.rotation = Quaternion.Euler(-21.267f, 28.405f, -291.007f);

            Player_1.transform.parent = Croco1.transform;
            sidePlayer_1.transform.parent = Croco1.transform;

            isParantSetTrue1 = true;
            isPlayer1Died = true;

        }
        //if charecter is less than 0 start scaring and make expression of fear
        //if charecter is greater then 0 than make enjoy face
        //if charecter is less then 0 but near to water speed animation
        //if charecter touches the water grab the chareter to crocodial mouth.
    }

    public void distacne_R2()
    {
        D2 = Mathf.Abs(Player_2.transform.position.y - waterlevel2.transform.position.y);
        if (D2 < 0.3f && !isParantSetTrue2 && !fallDown2)
        {
           // Player_2.transform.parent = null;
            Player_2.transform.position = new Vector3(-1.37f, -5.52f, -2.93f);
            Player_2.transform.rotation = Quaternion.Euler(-120, 90, 90);
            Player_2.transform.parent = Croco2.transform;
            isParantSetTrue2 = true;
            isPlayer2Died = true;
        }
    }
    public void weightLoose()
    {
        if (isPlayer1Died || isPlayer2Died)
        {
            if (weight1 != null)
            {
                weight1.transform.localScale -= Vector3.one * Time.deltaTime * weightLooseSpeed;
                Destroy(weight1, .5f);
            }
            if (weight2 != null)
            {
                weight2.transform.localScale -= Vector3.one * Time.deltaTime * weightLooseSpeed;
                Destroy(weight2, .75f);
            }
            if (weight3 != null)
            {
                weight3.transform.localScale -= Vector3.one * Time.deltaTime * weightLooseSpeed;
                Destroy(weight3, .9f);
            }
            StartCoroutine(CrocoEatExit(1));
        }
    }
    IEnumerator CrocoEatExit(float time)
    {

        yield return new WaitForSeconds(time);
        Croco1.GetComponent<Animator>().enabled = false;
        Croco2.GetComponent<Animator>().enabled = false;
        Croco1.transform.position = Vector3.Lerp(Croco1.transform.position, c1.position, CrocoSpeed * Time.deltaTime);
        Croco2.transform.position = Vector3.Lerp(Croco2.transform.position, c2.position, CrocoSpeed * Time.deltaTime);
    }

    public void fallDownP1()
    {
        Player_1.transform.position = new Vector3(-1.61f, 1.154366f, 0.25f);
        sidePlayer_1.transform.position = new Vector3(-1.43f, 1.299915f, 0.39f);

        Player_1.GetComponent<Rigidbody>().isKinematic = false;
        Player_1.GetComponent<Rigidbody>().useGravity = true;

        sidePlayer_1.GetComponent<Rigidbody>().isKinematic = false;
        sidePlayer_1.GetComponent<Rigidbody>().useGravity = true;
    }
    public void fallDownP2()
    {
        Player_2.transform.position = new Vector3(1.51f, 1.95f, 0.47f);
        Player_2.GetComponent<Rigidbody>().isKinematic =false;
        Player_2.GetComponent<Rigidbody>().useGravity = true;
    }

}
