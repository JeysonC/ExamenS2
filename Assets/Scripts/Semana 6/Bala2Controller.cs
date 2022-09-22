using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala2Controller : MonoBehaviour
{
    private float velocidadBala = 25;

    Rigidbody2D rb;
    SpriteRenderer sr;

    float realVelocity;
    

    public void SetRightDirection(){
        realVelocity = velocidadBala;
        // sr.flipX = false;
    }
    public void SetLeftDirection(){
        realVelocity = -velocidadBala;
        // sr.flipX = true;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        Destroy(this.gameObject,5);   
    }

    void Update()
    {
        rb.velocity = new Vector2(realVelocity,0);
    }

    void OnCollisionEnter2D(Collision2D other){
        Destroy(this.gameObject);
        if(other.gameObject.tag == "Enemy"){
            Destroy(other.gameObject);
        }
    }
}
