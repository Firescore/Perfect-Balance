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

    [Header("Test")]
    public float speedCheckD;
    public float speedCheckU;

    Vector3 initialPos;
    private void Start()
    {
        r = this;
        initialPos = transform.position;
    }

    void Update()
    {
        checkWeight();
    }
    void checkWeight()
    {
        if (Rope2.r2.weight < weight)
        {
            if (Rope2.r2.weight == 0)
            {
                speedCheckD = speedDown * weight;

                goDown(speedDown * weight);
                WheelRotator.wr.rotator(1,50);
            }
            if (Rope2.r2.weight != 0)
            {
                speedCheckD = speedDown * (weight - Rope2.r2.weight);
                goDown(speedDown * (weight - Rope2.r2.weight));
                WheelRotator.wr.rotator(1,50);
            }
        }


        if (Rope2.r2.weight > weight)
        {
            if (weight == 0)
            {
                speedCheckU = speedUp * Rope2.r2.weight;
                goUp(speedUp * Rope2.r2.weight);
                WheelRotator.wr.rotator(-1,50);
            }
            if (weight != 0)
            {
                speedCheckU = speedUp * (Rope2.r2.weight - weight);
                goUp(speedUp * (Rope2.r2.weight - weight));
                WheelRotator.wr.rotator(-1,50);
            }
        }
        if(GameManager.instane.weight.Count == 3 && Rope2.r2.weight == weight)
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
