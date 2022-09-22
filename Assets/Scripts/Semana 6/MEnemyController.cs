using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MEnemyController : MonoBehaviour
{
    public float vidaEnemigo = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(vidaEnemigo<=0){
            Destroy(this.gameObject);
        }
    }
    public void Attacking(int a){
        vidaEnemigo -= a;
        Debug.Log("Vida Enemigo: "+vidaEnemigo);
    }
}
