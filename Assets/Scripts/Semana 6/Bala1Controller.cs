using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala1Controller : MonoBehaviour
{
    private float velocidadBala = 25;
    public int danio;

    Rigidbody2D rb;
    Animator animator;

    float realVelocity;

    public void SetRightDirection(){
        realVelocity = velocidadBala;
    }
    
    public void SetLeftDirection(){
        realVelocity = -velocidadBala;
    }

    public void SetDanio(int d){
        danio = d;
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

    

    void OnCollisionEnter2D(Collision2D other){
        Destroy(this.gameObject);
        if(other.gameObject.tag == "Enemy"){
            other.gameObject.GetComponent<MEnemyController>().Attacking(danio);
            //other.gameObject.Attacking(danio);
            
        }
    }
}
