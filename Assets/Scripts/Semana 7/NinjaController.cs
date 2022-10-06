using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaController : MonoBehaviour
{
    private float velocidad = 0, velocidadDefecto = 15, fuerzaSalto = 25;
    public GameObject kunai;

    public GameObject zombie;

    private float timeLeft = 0;

    private float maxDisparos = 5;
    private float maxSaltos= 2;
    private float saltosRestantes;

    // public static float Range(float min, float max);

    public const string ARMA_KATANA = "Katana";
    public const string ARMA_KUNAI = "Kunai";


    //parapu texto
    private GManagController gManagController;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;

    bool puedeSaltar = true;
    bool estadoVida = true;

    private string arma = ARMA_KATANA;

    private Vector3 lastCheckPoint1position;

    const int ANIMACION_IDLE = 0;
    const int ANIMACION_RUN = 1;
    const int ANIMACION_JUMP = 2;
    const int ANIMACION_ATTACK = 3;
    const int ANIMACION_DEAD = 4;

    // Start is called before the first frame update
    void Start()
    {
        //parapu texto
        gManagController = FindObjectOfType<GManagController>();


        saltosRestantes=maxSaltos;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // timeLeft += Time.deltaTime;
        // Debug.Log("Tiempo: " + timeLeft);

        //Aparición de zombies
        // if(timeLeft>=3 && timeLeft < 3.01){
        //     SpawnZombie();
        //     timeLeft = 0;
        // }
        Debug.Log(arma);

        if(gManagController.Vida()==0){
                estadoVida = false;
                CambiarAnimacion(ANIMACION_DEAD);
                
        }else if(estadoVida==true){
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                CaminarDerecha();
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                Quieto();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                CaminarIzquierda();
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                Quieto();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Saltar();
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                Quieto();
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                Atacar();
            }
            if (Input.GetKeyUp(KeyCode.X))
            {
                Quieto();
            }

            Caminar();
        }else {
            CambiarAnimacion(ANIMACION_DEAD);
            timeLeft += Time.deltaTime;
            Debug.Log(timeLeft);
            if(timeLeft>=2 && timeLeft<2.1){
                transform.position = lastCheckPoint1position;
                timeLeft = 0;
            }
            if(timeLeft==0){
            velocidad = 0 ;
            CambiarAnimacion(ANIMACION_IDLE);
            estadoVida=true;
        }
        }
        

        
    }


    public void Caminar()
    {
        rb.velocity = new Vector2(velocidad, rb.velocity.y);
        if (velocidad < 0)
            sr.flipX = true;
        if (velocidad > 0)
            sr.flipX = false;
    }

    public void CaminarDerecha()
    {
        velocidad = velocidadDefecto;
        CambiarAnimacion(ANIMACION_RUN);
    }
    public void CaminarIzquierda()
    {
        velocidad = -velocidadDefecto;
        CambiarAnimacion(ANIMACION_RUN);
    }
    public void Quieto()
    {
        velocidad = 0;
        CambiarAnimacion(ANIMACION_IDLE);
    }
    public void Saltar()
    {
        if(saltosRestantes>0){
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.velocity += Vector2.up * fuerzaSalto;
            // puedeSaltar = false;
            CambiarAnimacion(ANIMACION_JUMP);
            saltosRestantes -= 1;
        }
        
    }

    public void cambiarArma(){
        if(arma == ARMA_KATANA){
            arma = ARMA_KUNAI;
        }else if(arma == ARMA_KUNAI){
            arma = ARMA_KATANA;
        }
    }

    public void Atacar()
    {
        if(arma == ARMA_KUNAI){
            if(sr.flipX == false && maxDisparos > 0){
                var kunaiPosition = transform.position + new Vector3(3, 0, 0);
                var gk = Instantiate(kunai, kunaiPosition, Quaternion.identity) as GameObject;
                var controller = gk.GetComponent<KunaiController>();
                controller.SetRightDirection();
                maxDisparos -= 1;
            }

            if(sr.flipX == true && maxDisparos > 0){
                var kunaiPosition = transform.position + new Vector3(-3, 0, 0);
                var gk = Instantiate(kunai, kunaiPosition, Quaternion.identity) as GameObject;
                var controller = gk.GetComponent<KunaiController>();
                controller.SetLeftDirection();
                maxDisparos -= 1;
            }
        }
        if(arma == ARMA_KATANA){
            CambiarAnimacion(ANIMACION_ATTACK);
        }
        
        
    }

    void CambiarAnimacion(int animacion)
    {
        animator.SetInteger("EstadoN", animacion);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        saltosRestantes = maxSaltos;
        // puedeSaltar = true;
        if (other.gameObject.tag == "Enemy")
        {
            estadoVida = false;
            gManagController.PerderVidas(1);
            
            
            // Destroy(other.gameObject);
            
        }
        if(other.gameObject.tag == "BaseMuerte"){
            gManagController.PerderVidas(1);
            if(transform.position != null){
                transform.position = lastCheckPoint1position;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "CheckPoint1"){
            Debug.Log("CheckPoint1");
            lastCheckPoint1position = transform.position;
        }
    }

    public void SpawnZombie()
    {
        var ZombiePosition = transform.position + new Vector3(17, 0, 0);
        var zg = Instantiate(zombie, ZombiePosition, Quaternion.identity);
    }

    
}
