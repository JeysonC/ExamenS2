using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidadCorrer = 20, velocidadCaminar = 10, fuerzaSalto = 25;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;

    const int ANIMATION_IDLE = 0;
    const int ANIMATION_WALK = 1;
    const int ANIMATION_RUN = 2;
    const int ANIMATION_JUMP = 3;
    const int ANIMATION_ATTACK = 4;
    
    bool puedeSaltar = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        CambiarAnimacion(ANIMATION_IDLE);

        if(Input.GetKey(KeyCode.Space) && puedeSaltar){//Saltar
            CambiarAnimacion(ANIMATION_JUMP);
            rb.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
            puedeSaltar = false;
        }
        if(Input.GetKey(KeyCode.X) && Input.GetKey(KeyCode.RightArrow)){//correr derecha
            CambiarAnimacion(ANIMATION_RUN);
            rb.velocity = new Vector2(velocidadCorrer, rb.velocity.y);
            sr.flipX = false;
        }else if(Input.GetKey(KeyCode.RightArrow)){//derecha
            rb.velocity = new Vector2(velocidadCaminar, rb.velocity.y);
            CambiarAnimacion(ANIMATION_WALK);
            sr.flipX = false;
        } 
              
        if(Input.GetKey(KeyCode.X) && Input.GetKey(KeyCode.LeftArrow)){//correr Izquierda
            CambiarAnimacion(ANIMATION_RUN);
            rb.velocity = new Vector2(-velocidadCorrer, rb.velocity.y);
            sr.flipX = true;
        }else if(Input.GetKey(KeyCode.LeftArrow)){//izquierda
            rb.velocity = new Vector2(-velocidadCaminar, rb.velocity.y);
            CambiarAnimacion(ANIMATION_WALK);
            sr.flipX = true;
        }
        
        if(Input.GetKey(KeyCode.Z)){
            CambiarAnimacion(ANIMATION_ATTACK);
        }

        
        
    }

    private void CambiarAnimacion(int animacion){
        animator.SetInteger("Estado", animacion);
    }

    void OnCollisionEnter2D(Collision2D other){
        puedeSaltar = true;
    }
}
