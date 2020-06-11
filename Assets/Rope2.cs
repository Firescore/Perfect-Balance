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

    [Header("Test")]
    public float speedCheckD;
    public float speedCheckU;

    Vector3 initialPos;
    private void Start()
    {
        r2 = this;
       initialPos = transform.position;
    }
    void Update()
    {
        checkWeight();
    }

    void checkWeight()
    {
        if(Rope1.r.weight < weight)
        {
            if(Rope1.r.weight == 0)
            {
                speedCheckD = speedDown * weight;
                goDown(speedDown* weight);


                WheelRotator.wr.rotator(-1,50);
            }
            if(Rope1.r.weight != 0)
            {
                speedCheckD = speedDown * (weight - Rope1.r.weight);
                goDown(speedDown* (weight - Rope1.r.weight));


                WheelRotator.wr.rotator(-1,50);
            }
            
        }
        if (Rope1.r.weight > weight)
        {
            if (weight == 0)
            {
                speedCheckU = speedUp * Rope1.r.weight;
                goUp(speedUp * Rope1.r.weight);


                WheelRotator.wr.rotator(1,50);
            }
            if (weight != 0)
            {
                speedCheckU = speedUp * (Rope1.r.weight - weight);
                goUp(speedUp* (Rope1.r.weight-weight));


                WheelRotator.wr.rotator(1,50);
            }

        }
        if (GameManager.instane.weight.Count == 3 && Rope1.r.weight == weight)
        {
            backToInitial();
            GameManager.instane.endRotateL();
            GameManager.instane.endRotateR();
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
        transform.position = Vector3.MoveTowards(transform.position, initialPos, normalizeSpeed * Time.deltaTime);
    }
}
