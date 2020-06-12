using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope1 : MonoBehaviour
{
    public static Rope1 r;
    public float speedDown = 1;
    public float speedUp = 1;
    public float normalizeSpeed;
    public float weight;
    public float springSpeed;
    public float springUp;
    public float springDown;

    public bool normalize = false;
    public bool movingUp = false;
    public bool movingDown = false;

    Vector3 initialPos;
    //bool stopSpring = false;
    private void Start()
    {
        r = this;
        initialPos = transform.position;
    }

    void Update()
    {
        checkWeight();
        //moveUpDown();
    }
    void checkWeight()
    {
        if (Rope2.r2.weight < weight)
        {
            if (Rope2.r2.weight == 0)
            {
                goDown(speedDown * weight);
                GameManager.instane.anime1.SetBool("Hang", true);
                WheelRotator.wr.rotator(1,50);
            }
            if (Rope2.r2.weight != 0)
            {
                goDown(speedDown * (weight - Rope2.r2.weight));
                GameManager.instane.anime1.SetBool("Hang", true);
                WheelRotator.wr.rotator(1,50);
            }
        }


        if (Rope2.r2.weight > weight)
        {
            if (weight == 0)
            {
                goUp(speedUp * Rope2.r2.weight);
                GameManager.instane.anime1.SetBool("Hang", false);
                WheelRotator.wr.rotator(-1,50);
            }
            if (weight != 0)
            {
                goUp(speedUp * (Rope2.r2.weight - weight));
                GameManager.instane.anime1.SetBool("Hang", false);
                WheelRotator.wr.rotator(-1,50);
            }
        }
        if(GameManager.instane.weight.Count == 3 && Rope2.r2.weight == weight)
        {
            GameManager.instane.anime1.SetBool("Hang", false);
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
    }
    public void moveUpDown()
    {
        if (!Rope2.r2.stopSpring)
        {
            if (Rope2.r2.movingDown)
            {
                transform.Translate(Vector3.up * springSpeed * Time.deltaTime);
            }
            if (Rope2.r2.movingUp)
            {
                transform.Translate(Vector3.down * springSpeed * Time.deltaTime);
            }
        }
        
    }
}
