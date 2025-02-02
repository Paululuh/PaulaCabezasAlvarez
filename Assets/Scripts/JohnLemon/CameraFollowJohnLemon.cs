using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Zona de variables globales
    public Transform Target;
    [Header("Vectors")]
    //Velocidad de seguimiento de la c�mara al personaje
    [SerializeField]
    private float _smoothing;
    //Distancia inicial que hay entre la c�mara y el "player"
    [SerializeField]
    private Vector3 _offset;

    void Start()
    {

        _offset = transform.position - Target.position;


    }

    private void LateUpdate()
    { 
    
        //Posici�n a la que queremos mover la c�mara
        Vector3 desiredPosition = Target.position + _offset;

        //Mover la c�mara
        transform.position = Vector3.Lerp(transform.position, desiredPosition, _smoothing * Time.deltaTime);
    
    
    }
}
