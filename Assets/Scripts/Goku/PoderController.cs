using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoderController : MonoBehaviour
{
    private float velocidadBala = 25;


    Rigidbody2D rb;

    float realVelocity;

    public void SetRightDirection(){
        realVelocity = velocidadBala;
    }
    
    public void SetLeftDirection(){
        realVelocity = -velocidadBala;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject,5);    
    }

    void Update()
    {
        rb.velocity = new Vector2(realVelocity,0);
    }

}
