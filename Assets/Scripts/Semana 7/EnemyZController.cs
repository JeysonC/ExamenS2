using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZController : MonoBehaviour
{
    private float velocidad = 5;

    //parapu puntaje
    private GManagController gManagController;


    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sr;

    public float vidaEnemigo = 2;
    // Start is called before the first frame update
    void Start()
    {
        //parapu puntaje
        gManagController = FindObjectOfType<GManagController>();

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity=new Vector2(velocidad,rb.velocity.y);
        if(vidaEnemigo<=0){
            Destroy(this.gameObject);
            gManagController.GanarPuntos(10);
        }
        if(velocidad < 0){
            sr.flipX=true;
        }
        if(velocidad > 0){
            sr.flipX=false;
        }
    }
    public void Attacking(int a){
        vidaEnemigo -= a;
        Debug.Log("Vida Enemigo: "+vidaEnemigo);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "LimitePlat"){
            velocidad *= -1;
            
        }
    }
}
