using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPlayerController : MonoBehaviour
{
    private float velocidad = 10, fuerzaSalto = 15;

    public GameObject poder;

    private float timeLeft = 0;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;

    const int ANIMACION_IDLE = 0;
    const int ANIMACION_RUN = 1;
    const int ANIMACION_VOLAR = 2;
    const int ANIMACION_JUMP = 3;
    const int ANIMACION_POTENCE = 4;
    const int ANIMACION_ATTACK = 5;

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
        //QUIETO
        rb.velocity = new Vector2(0,rb.velocity.y);
        CambiarAnimacion(ANIMACION_IDLE);
        
        //CORRER DERECHA
        if(Input.GetKey(KeyCode.RightArrow)){
            rb.velocity = new Vector2(velocidad,rb.velocity.y);
            CambiarAnimacion(ANIMACION_RUN);
            sr.flipX = false;
        }

        //CORRER IZQUIERDA
        if(Input.GetKey(KeyCode.LeftArrow)){
            rb.velocity = new Vector2(-velocidad,rb.velocity.y);
            CambiarAnimacion(ANIMACION_RUN);
            sr.flipX = true;
        }

        //SALTAR
        if(Input.GetKeyDown(KeyCode.Space) && puedeSaltar){
            rb.AddForce(new Vector2(0,fuerzaSalto), ForceMode2D.Impulse);
            CambiarAnimacion(ANIMACION_JUMP);
            puedeSaltar = false;
        }

        //CARGAR Energía
        if(Input.GetKey(KeyCode.X)){
            CambiarAnimacion(ANIMACION_POTENCE);
            timeLeft += Time.deltaTime;
            Debug.Log(timeLeft);
        }

        if(timeLeft < 1){
            if(sr.flipX == false && Input.GetKeyUp(KeyCode.X)){
                CambiarAnimacion(ANIMACION_ATTACK);
                var poderPosition = transform.position + new Vector3(4,0,0);
                var gb = Instantiate(poder, poderPosition, Quaternion.identity) as GameObject;
                var controller = gb.GetComponent<PoderController>();
                controller.SetRightDirection();
            }
            if(sr.flipX == true && Input.GetKeyUp(KeyCode.X)){
                CambiarAnimacion(ANIMACION_ATTACK);
                var poderPosition = transform.position + new Vector3(-4,0,0);
                var gb = Instantiate(poder, poderPosition, Quaternion.identity) as GameObject;
                var controller = gb.GetComponent<PoderController>();
                controller.SetLeftDirection();
            }
            
        }else if(timeLeft > 3 && timeLeft < 5){
            if(sr.flipX == false && Input.GetKeyUp(KeyCode.X)){
                CambiarAnimacion(ANIMACION_ATTACK);
                var poderPosition = transform.position + new Vector3(4,0,0);
                var gb = Instantiate(poder, poderPosition, Quaternion.identity) as GameObject;
                var controller = gb.GetComponent<PoderController>();
                controller.SetRightDirection();
            }
            if(sr.flipX == true && Input.GetKeyUp(KeyCode.X)){
                CambiarAnimacion(ANIMACION_ATTACK);
                var poderPosition = transform.position + new Vector3(-4,0,0);
                var gb = Instantiate(poder, poderPosition, Quaternion.identity) as GameObject;
                var controller = gb.GetComponent<PoderController>();
                controller.SetLeftDirection();
            }
        }else if(timeLeft > 5){
            if(sr.flipX == false && Input.GetKeyUp(KeyCode.X)){
                CambiarAnimacion(ANIMACION_ATTACK);
                var poderPosition = transform.position + new Vector3(4,0,0);
                var gb = Instantiate(poder, poderPosition, Quaternion.identity) as GameObject;
                var controller = gb.GetComponent<PoderController>();
                controller.SetRightDirection();
            }
            if(sr.flipX == true && Input.GetKeyUp(KeyCode.X)){
                CambiarAnimacion(ANIMACION_ATTACK);
                var poderPosition = transform.position + new Vector3(-4,0,0);
                var gb = Instantiate(poder, poderPosition, Quaternion.identity) as GameObject;
                var controller = gb.GetComponent<PoderController>();
                controller.SetLeftDirection();
            }
        }

        if(Input.GetKeyUp(KeyCode.X)){
            timeLeft = 0;
        }
    }

    private void CambiarAnimacion(int animacion){
        animator.SetInteger("EstadoG",animacion);
    }

    void OnCollisionEnter2D(Collision2D other){
        puedeSaltar = true;
    }
}
