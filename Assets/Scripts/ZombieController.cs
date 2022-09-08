using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;

    const int ANIMACION_RUN = 1;
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
        rb.velocity = new Vector2(10, rb.velocity.y);
        CambiarAnimacion(ANIMACION_RUN);
        sr.flipX = true;
    }
    private void CambiarAnimacion(int animacion){
        animator.SetInteger("EstadoZombie", animacion);
    }
    
}
