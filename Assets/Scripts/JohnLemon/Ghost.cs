using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    //Zona de variables globales
    [Header("WayPoints")]
    [SerializeField]
    private Transform[] _positionsArray;
    [SerializeField]
    private float _speed;
    //Almacenar la posición a la que se dirige el fantasma
    private Vector3 _posToGo;
    //Índice para controlar en qué posición (casilla) del "array" estoy
    private int _i;
    private Ray _ray;
    private RaycastHit _hit;

    public GameManager GameManagerScript;

    void Start()
    {

        _i = 0;
        _posToGo = _positionsArray[_i].position;

    }

    private void FixedUpdate()
    {

        DetectionJohnLemon();

    }

    // Update is called once per frame
    void Update()
    {


        Move();
        ChangePosition();
        Rotate();
    }

    private void Move()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, _posToGo, _speed * Time.deltaTime);


    }

    private void ChangePosition()
    {

        //Si el fantasma ha llegado a su destino
        if (Vector3.Distance(transform.position, _posToGo) <= Mathf.Epsilon)
        {

            //Comprobar si estoy en la última casilla del "array" (elemento 1)
            //Un "array" con dos elementos: el elemento 0 y el elemento 1
            if (_i == _positionsArray.Length - 1)
            {

                //Vuelve a la casilla inicial del "array"
                _i = 0;

            }
            else
            {

                _i++; //_i = _1 * 1;

            }

            _posToGo = _positionsArray[_i].position;
        
        
        }
    
    
    }

    private void Rotate()
    {

        transform.LookAt(_posToGo);
    
    
    }

    private void DetectionJohnLemon()
    {

        //Subir el origen del ray 1 metro en el eje y con respecto al punto de pivote del objeto
        _ray.origin = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
        _ray.direction = transform.forward;

        if(Physics.Raycast(_ray, out _hit))

         if (_hit.collider.CompareTag("JohnLemon"))
             {

                 Debug.Log("Soy un fastama y te he pillado");
                 GameManagerScript.IsPlayerCaught = true;   
        
             }
    
    
    }

}
