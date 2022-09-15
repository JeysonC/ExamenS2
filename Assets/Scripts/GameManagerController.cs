using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class GameManagerController : MonoBehaviour
{
    public Text balasText;
  
    private int bala;
    void Start()
    {
        bala = 5;
        PrintBulletInScreen();
        LoadGame();
    }

    public void SaveGame(){ //guardar datos
        var filePath = Application.persistentDataPath + "/save.dat";

        FileStream file;

        if(File.Exists(filePath)){
            file = File.OpenWrite(filePath);
        }else{
            file = File.Create(filePath);
        }

        GameData data = new GameData();
        data.Balas=bala;
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadGame(){
        var filePath = Application.persistentDataPath + "/save.dat";

        FileStream file;

        if(File.Exists(filePath)){
            file = File.OpenRead(filePath);
        }else{
            Debug.LogError("No se encontró archivo");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        GameData data = (GameData) bf.Deserialize(file);
        file.Close();

        bala = data.Balas;
        
        PrintBulletInScreen();
    }
    // Update is called once per frame
    public int Bullet(){
        return bala;
    }
    public void PerderBalas(int balas){
        bala -= balas;
        PrintBulletInScreen();
    }
    private void PrintBulletInScreen(){
        balasText.text = "Balas: " + bala;
    }
}
