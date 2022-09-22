using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPlayerController : MonoBehaviour
{
    private float velocidad = 10, fuerzaSalto = 15;

    public GameObject primeraBala;
    
    private float timeLeft = 0;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;

    const int ANIMACION_IDLE = 0;
    const int ANIMACION_RUN = 1;
    const int ANIMACION_JUMP = 2;
    const int ANIMACION_RUNATTACK = 3;
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
            Debug.Log("Tiempo: "+timeLeft);
        }
        //ATACAR CON TIEMPO
        if(timeLeft < 1){
                //vALOR ATTACK
                //DIMENSION
                //FUNSION
                if(sr.flipX == false && Input.GetKeyUp(KeyCode.X)){
                CambiarAnimacion(ANIMACION_ATTACK);
                var primeraBalaPosition = transform.position + new Vector3(2,0,0);
                var gb = Instantiate(primeraBala, primeraBalaPosition, Quaternion.identity) as GameObject;
                var controller = gb.GetComponent<Bala1Controller>();
                controller.SetRightDirection();
                }
                if(sr.flipX == true && Input.GetKeyUp(KeyCode.X)){
                CambiarAnimacion(ANIMACION_ATTACK);
                var primeraBalaPosition = transform.position + new Vector3(-2,0,0);
                var gb = Instantiate(primeraBala, primeraBalaPosition, Quaternion.identity) as GameObject;
                var controller = gb.GetComponent<Bala1Controller>();
                controller.SetLeftDirection();
                }
            }
            else if(timeLeft > 3 && timeLeft < 5){
                if(sr.flipX == false && Input.GetKeyUp(KeyCode.X)){
                CambiarAnimacion(ANIMACION_ATTACK);
                var primeraBalaPosition = transform.position + new Vector3(2,0,0);
                var gb = Instantiate(primeraBala, primeraBalaPosition, Quaternion.identity) as GameObject;
                gb.transform.localScale = new Vector3(8,8,8);
                var controller = gb.GetComponent<Bala1Controller>();
                controller.SetDanio(3);
                controller.SetRightDirection();
                }
                if(sr.flipX == true && Input.GetKeyUp(KeyCode.X)){
                CambiarAnimacion(ANIMACION_ATTACK);
                var primeraBalaPosition = transform.position + new Vector3(-2,0,0);
                var gb = Instantiate(primeraBala, primeraBalaPosition, Quaternion.identity) as GameObject;
                gb.transform.localScale = new Vector3(8,8,8);
                var controller = gb.GetComponent<Bala1Controller>();
                controller.SetDanio(3);
                controller.SetLeftDirection();
                }
            }
            else if(timeLeft > 5){
                if(Input.GetKeyUp(KeyCode.X)){
                   if(sr.flipX == false && Input.GetKeyUp(KeyCode.X)){
                        CambiarAnimacion(ANIMACION_ATTACK);
                        var primeraBalaPosition = transform.position + new Vector3(3,0,0);
                        var gb = Instantiate(primeraBala, primeraBalaPosition, Quaternion.identity) as GameObject;
                        gb.transform.localScale = new Vector3(15,15,15);
                        var controller = gb.GetComponent<Bala1Controller>();
                        controller.SetDanio(5);
                        controller.SetRightDirection();
                    }
                    if(sr.flipX == true && Input.GetKeyUp(KeyCode.X)){
                        CambiarAnimacion(ANIMACION_ATTACK);
                        var primeraBalaPosition = transform.position + new Vector3(-3,0,0);
                        var gb = Instantiate(primeraBala, primeraBalaPosition, Quaternion.identity) as GameObject;
                        gb.transform.localScale = new Vector3(15,15,15);
                        var controller = gb.GetComponent<Bala1Controller>();
                        controller.SetDanio(5);
                        controller.SetLeftDirection();
                    } 
                }
            }
        if(Input.GetKeyUp(KeyCode.X)){
            timeLeft = 0;
        }

    }

    private void CambiarAnimacion(int animacion){
        animator.SetInteger("EstadoM",animacion);
    }

    void OnCollisionEnter2D(Collision2D other){
        
        puedeSaltar = true;
    }
}
