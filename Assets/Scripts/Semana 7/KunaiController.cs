using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiController : MonoBehaviour
{
    public float velocidadKunai = 50;

    public int danio=1;

    //parapu puntaje
    private GManagController gManagController;

    Rigidbody2D rb;
    SpriteRenderer sr;

    float realVelocidad;

    public void SetRightDirection()
    {
        realVelocidad = velocidadKunai;
    }
    public void SetLeftDirection()
    {
        realVelocidad = -velocidadKunai;
    }
    public void SetDanio(int d){
        danio = d;
    }
    void Start()
    {
        //parapu puntaje
        gManagController = FindObjectOfType<GManagController>();

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        Destroy(this.gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(realVelocidad, 0);

        if(realVelocidad > 0){
            sr.flipX=false;
        }
        if(realVelocidad < 0){
            sr.flipX=true;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(this.gameObject);
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyZController>().Attacking(danio);

            
            // Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "ZSaltarin")
        {
           other.gameObject.GetComponent<ZombieSalt>().Attacking(danio);
           
            // Destroy(other.gameObject);
        }
    }
}
