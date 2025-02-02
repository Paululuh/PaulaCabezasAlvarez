using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Zona de variables globales
    [Header("Images")]
    [SerializeField]
    private Image _caugthImage;
    [SerializeField]
    private Image _wongImage;
    [Header("Fade")]
    //La duración del "fade" de la imagen
    //(que va a aparecer poco a poco)
    [SerializeField]
    private float _fadeDuration;
    //El total del tiempo que voy a dejar la imagen en pantalla
    [SerializeField]
    private float _displayImageDuration;
    //Contador de tiempo
    private float _timer;

    //Para saber si el "player ha llegado a la salida
    public bool IsPlayerAtExit;
    //Para saber si han pillado el "player"
    public bool IsPlayerCaught;
    //Me va a decir si "reseteo" el nivel o no
    private bool IsRestartLevel;

    [Header("Audio")]
    [SerializeField]
    private AudioClip _caughtClip;
    [SerializeField]
    private AudioClip _wonClip;
    private AudioSource _audioSource;

    private void Awake()
    {
        
        _audioSource = GetComponent<AudioSource>();
        _wongImage.gameObject.SetActive(false);
        _caugthImage.gameObject.SetActive(false);


    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (IsPlayerAtExit)
        {

            Won();


        }
        else if (IsPlayerCaught)
        { 
        
            Caught();
        
        
        }


    }

    private void Won()
    {
        _wongImage.gameObject.SetActive(true);
        _audioSource.clip = _wonClip;
        if(_audioSource.isPlaying == false)
        {

            _audioSource.Play();

        }

        _timer = _timer + Time.deltaTime;//_timer += Time.deltaTime;
        //Aumentar el canal alfa de la imagen poco a poco
        _wongImage.color = new Color(_wongImage.color.r, _wongImage.color.g, _wongImage.color.b, _timer / _fadeDuration);

        //La imagen se quede durante un tiempo
        if(_timer > _fadeDuration + _displayImageDuration)
        {

            Debug.Log("He ganado");


        }

    }


    private void Caught()
    {
        _caugthImage.gameObject.SetActive(true);
        _audioSource.clip = _caughtClip;
        if (_audioSource.isPlaying == false)
        {

            _audioSource.Play();

        }

        _timer = _timer + Time.deltaTime;//_timer += Time.deltaTime;
        //Aumentar el canal alfa de la imagen poco a poco
        _caugthImage.color = new Color(_caugthImage.color.r, _caugthImage.color.g, _caugthImage.color.b, _timer/ _fadeDuration);

        //La imagen se quede durante un tiempo
        if (_timer > _fadeDuration + _displayImageDuration)
        {

            Debug.Log("He perdido");
            SceneManager.LoadScene("JuanitoLimones");

        }

    }

    public void Restart()
    {

        SceneManager.LoadScene("JuanitoLimones");
    
    }

    private void OnTriggerEnter(Collider infoCollider)
    {
        if (infoCollider.CompareTag("JohnLemon"))
        {

            IsPlayerAtExit = true;

        }



    }
}
