using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttack : MonoBehaviour
{

    //Zona de variables globales
    //Referencia al prefabricado de la bala
    [SerializeField]
    private Rigidbody _shellPrefab;

    //Referencia al "gameObject" vacío que representa la posición de salida
    [SerializeField]
    private Transform _posShell;

    //Fuerza a la que sale la bala
    [SerializeField]
    private float _launchForce;

    //Rerefencia al componente AudioSource que lleva el objeto "_posShell"
    [SerializeField]
    private AudioSource _audioSource;


    // Update is called once per frame
    void Update()
    {
        InputPlayer();


    }

    private void InputPlayer()
    {
        if (Input.GetMouseButtonDown(0))

        {
            Launch();

        }
    }

    private void Launch()
    {
        Rigidbody cloneShellPrefab = Instantiate(_shellPrefab, _posShell.position, _posShell.rotation);

        _audioSource.Play();

        cloneShellPrefab.velocity = _posShell.forward * _launchForce;


    }
}
