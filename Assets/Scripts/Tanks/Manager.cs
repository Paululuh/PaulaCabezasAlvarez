using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    

    //Método al que llamamos al pulsar el botón "retry"
    public void LoadSceneLevel()
    {

        SceneManager.LoadScene(1);

    }

}

   