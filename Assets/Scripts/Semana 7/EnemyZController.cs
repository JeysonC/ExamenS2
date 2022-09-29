using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    public float vidaEnemigo = 2;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity=new Vector2(-5,rb.velocity.y);
        if(vidaEnemigo<=0){
            Destroy(this.gameObject);
        }
    }
    public void Attacking(int a){
        vidaEnemigo -= a;
        Debug.Log("Vida Enemigo: "+vidaEnemigo);
    }
}
