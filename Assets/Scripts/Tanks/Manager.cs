using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    

    //M�todo al que llamamos al pulsar el bot�n "retry"
    public void LoadSceneLevel()
    {

        SceneManager.LoadScene(1);

    }

}

   