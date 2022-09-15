using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public float velocidad;
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
        rb.velocity = new Vector2(velocidad, rb.velocity.y);
        CambiarAnimacion(ANIMACION_RUN);
    }

    private void OnTriggerExist2D(Collider2D other){
        if(other.gameObject.tag == "plataforma"){
            velocidad *= -1;
            this.transform.localScale = new Vector2(this.transform.localScale.x*-1, this.transform.localScale.y);
        }
    }
    private void CambiarAnimacion(int animacion){
        animator.SetInteger("EstadoZombie", animacion);
    }
    
}
