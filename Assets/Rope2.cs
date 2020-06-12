using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope2 : MonoBehaviour
{
    public static Rope2 r2;
    public float speedDown = 1;
    public float speedUp = 1;
    public float normalizeSpeed;
    public float weight;
    public float springSpeed;
    public float springUp;
    public float springDown;


    public bool movingDown = false;
    public bool movingUp = false;
    public bool normalize = false;
    public bool stopSpring = false;
    Vector3 initialPos;
    bool rechedUP = false;

    private void Start()
    {
        r2 = this;
       initialPos = transform.position;
    }
    void Update()
    {
        checkWeight();
        //moveUpDown();
    }

    void checkWeight()
    {
        if(Rope1.r.weight < weight)
        {
            if(Rope1.r.weight == 0)
            {
                goDown(speedDown* weight);
                GameManager.instane.anime2.SetBool("Hang",true);
                WheelRotator.wr.rotator(-1,50);
            }
            if(Rope1.r.weight != 0)
            {
                goDown(speedDown* (weight - Rope1.r.weight));

                GameManager.instane.anime2.SetBool("Hang", true);
                WheelRotator.wr.rotator(-1,50);
            }
            
        }
        if (Rope1.r.weight > weight)
        {
            if (weight == 0)
            {
                goUp(speedUp * Rope1.r.weight);

                GameManager.instane.anime2.SetBool("Hang", false);
                WheelRotator.wr.rotator(1,50);
            }
            if (weight != 0)
            {
                goUp(speedUp* (Rope1.r.weight-weight));

                GameManager.instane.anime2.SetBool("Hang", false);
                WheelRotator.wr.rotator(1,50);
            }

        }
        if (GameManager.instane.weight.Count == 3 && Rope1.r.weight == weight)
        {
            GameManager.instane.anime2.SetBool("Hang", false);
            backToInitial();

            if (normalize)
                StartCoroutine(spring(5));

        }
    }

   public void goDown(float speed)
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
   public void goUp(float speed)
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
    public void backToInitial()
    {
        if (!normalize)
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPos, normalizeSpeed * Time.deltaTime);
            GameManager.instane.endRotateL();
            GameManager.instane.endRotateR();
            if (transform.position == initialPos)
                normalize = true;
        }
        
    }
    IEnumerator spring(float time)
    {
        moveUpDown();
        yield return new WaitForSeconds(time);
        transform.position = Vector3.MoveTowards(transform.position, initialPos, normalizeSpeed * Time.deltaTime);
        stopSpring = true;
    }
    public void moveUpDown()
    {
        if (!stopSpring)
        {
            if (!rechedUP)
            {

                transform.Translate(Vector3.up * springSpeed * Time.deltaTime);
                WheelRotator.wr.rotator(1, 50);
                movingUp = true;
                movingDown = false;
                if (transform.position.y >= springUp)
                    rechedUP = true;


            }

            if (rechedUP)
            {
                transform.Translate(Vector3.down * springSpeed * Time.deltaTime);
                WheelRotator.wr.rotator(-1, 50);
                movingUp = false;
                movingDown = true;
                if (transform.position.y <= springDown)
                    rechedUP = false;
            }
        }
        
        
    }
   
}
