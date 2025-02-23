using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow : MonoBehaviour
{

    //Zona de variables globales
    [Header("CamaraFollow")]
    [SerializeField]
    private Transform _player;

    //Velocidad de movimiento
    [SerializeField]
    private float _smoothing;

    //Distancia entre el player y la cámara
    [SerializeField]
    private Vector3 _offset;

    void Start()
    {

        
        _offset = transform.position - _player.position;
        
    }

    void Update()
    {

        Vector3 camPosition  = _player.position + _offset;
        transform.position = Vector3.Lerp(transform.position, camPosition, _smoothing * Time.deltaTime);   
        
    }
}
