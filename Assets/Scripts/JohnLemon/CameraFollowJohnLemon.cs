using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Zona de variables globales
    public Transform Target;
    [Header("Vectors")]
    //Velocidad de seguimiento de la cámara al personaje
    [SerializeField]
    private float _smoothing;
    //Distancia inicial que hay entre la cámara y el "player"
    [SerializeField]
    private Vector3 _offset;

    void Start()
    {

        _offset = transform.position - Target.position;


    }

    private void LateUpdate()
    { 
    
        //Posición a la que queremos mover la cámara
        Vector3 desiredPosition = Target.position + _offset;

        //Mover la cámara
        transform.position = Vector3.Lerp(transform.position, desiredPosition, _smoothing * Time.deltaTime);
    
    
    }
}
