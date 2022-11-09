using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    public void reiniciarGame(){
        SceneManager.LoadScene("MiniGame");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
