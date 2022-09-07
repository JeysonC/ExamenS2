using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidadCorrer = 20, velocidadCaminar = 10, fuerzaSalto = 25;
    public float saltosMaximos;
    
    public LayerMask capaSuelo;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;
    BoxCollider2D boxcollider;

    const int ANIMATION_IDLE = 0;
    const int ANIMATION_WALK = 1;
    const int ANIMATION_RUN = 2;
    const int ANIMATION_JUMP = 3;
    const int ANIMATION_ATTACK = 4;
    
    //bool puedeSaltar = true;

    private Vector3 lastCheckPointPosition; 
    private float saltosRestantes;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        boxcollider = GetComponent<BoxCollider2D>();
        saltosRestantes = saltosMaximos;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        CambiarAnimacion(ANIMATION_IDLE);

        if(EstaEnSuelo()){
            
            saltosRestantes = saltosMaximos;
        }
        if(Input.GetKeyDown(KeyCode.Space) && saltosRestantes > 0){//Saltar
            rb.velocity = new Vector2(rb.velocity.x, 0f);//para saltar con la misma fuerza al caer
            rb.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
            CambiarAnimacion(ANIMATION_JUMP);
            saltosRestantes--;
            //puedeSaltar = false;
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
        animator.SetInteger("EstadoPlayer", animacion);
    }

    //para doble salto
    bool EstaEnSuelo(){
        RaycastHit2D raycasthit= Physics2D.BoxCast(boxcollider.bounds.center, new Vector2(boxcollider.bounds.size.x, boxcollider.bounds.size.y), 0f, Vector2.down, 0.2f, capaSuelo);
        return raycasthit.collider != null;
    }
    void OnCollisionEnter2D(Collision2D other){
        //puedeSaltar = true;

        if(other.gameObject.name == "Muerte"){
            if(lastCheckPointPosition != null){
                transform.position = lastCheckPointPosition;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        
        Debug.Log("Trigger");
        lastCheckPointPosition = transform.position; 
    }
}
