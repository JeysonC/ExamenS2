using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class GameManag : MonoBehaviour
{
    public Text scoreText;
  
    private int score;
    void Start()
    {
        score = 0;
        PrintScoreInScreen();
        
    }

    
    // Update is called once per frame
    public int Score(){
        return score;
    }
    public void GanarPuntos(int puntos){
        score += puntos;
        PrintScoreInScreen();
    }
    private void PrintScoreInScreen(){
        scoreText.text = "Puntaje: " + score;
    }
}
