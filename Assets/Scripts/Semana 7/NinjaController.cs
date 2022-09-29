using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class NinjaController : MonoBehaviour
{
    private float velocidad = 0, velocidadDefecto = 15, fuerzaSalto = 25;
    public GameObject kunai;

    public GameObject zombie;

    private float timeLeft = 0;

    // public static float Range(float min, float max);


    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;

    bool puedeSaltar = true;
    bool puedeDisparar = false;

    const int ANIMACION_IDLE = 0;
    const int ANIMACION_RUN = 1;
    const int ANIMACION_JUMP = 2;
    const int ANIMACION_ATTACK = 3;

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
        timeLeft += Time.deltaTime;
        // Debug.Log("Tiempo: " + timeLeft);

        if(timeLeft>=3 && timeLeft < 3.01){
            SpawnZombie();
            timeLeft = 0;
        }


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

        if (Input.GetKeyDown(KeyCode.Space) && puedeSaltar)
        {
            Saltar();
        }
        if (Input.GetKeyUp(KeyCode.Space) && puedeSaltar)
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
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += Vector2.up * fuerzaSalto;
        puedeSaltar = false;
        CambiarAnimacion(ANIMACION_JUMP);
    }
    public void Atacar()
    {
        if(puedeDisparar==true){
            var kunaiPosition = transform.position + new Vector3(3, 0, 0);
            var gk = Instantiate(kunai, kunaiPosition, Quaternion.identity) as GameObject;
            var controller = gk.GetComponent<KunaiController>();
            controller.SetRightDirection();
        }else{
            CambiarAnimacion(ANIMACION_ATTACK);
        }
        
    }

    void CambiarAnimacion(int animacion)
    {
        animator.SetInteger("EstadoN", animacion);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        puedeSaltar = true;
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }

    public void SpawnZombie()
    {
        var ZombiePosition = transform.position + new Vector3(17, 0, 0);
        var zg = Instantiate(zombie, ZombiePosition, Quaternion.identity);
    }

    public void cambiarArma(){
        puedeDisparar=true;
    }
}
