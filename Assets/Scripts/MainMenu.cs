using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void facil(){

       SceneManager.LoadScene("MiniGame");

      }

    public void dificil(){

        SceneManager.LoadScene("MiniGame2");

      }
}
