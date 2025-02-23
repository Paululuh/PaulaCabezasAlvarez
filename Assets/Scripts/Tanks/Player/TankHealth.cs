using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    //Zona de variables globales
    [Header("Health")]
    //Vida máxima del tanque
    [SerializeField]
    private float _maxHealth;
    //Vida actual
    [SerializeField]
    private float _currentHealth;
    //Daño que hacen las balas enemigas
    [SerializeField]
    private float _damageEnemyshell;

    [Header("ProgressBar")]
    [SerializeField]
    private Image _lifeBar;

    [Header("Explosions")]
    [SerializeField]
    private ParticleSystem _bigExplosion;
    [SerializeField]
    private ParticleSystem _smallExplosion;

    [Header("Game Over")]
    [SerializeField]
    private GameManagerTanks _gameManagerTanks;


    private void Awake()
    {

        
        _currentHealth = _maxHealth;
        _lifeBar.fillAmount = 1.0f;

        
        _bigExplosion.Stop();
        _smallExplosion.Stop();


    }
    private void OnCollisionEnter(Collision infoColision)
    {

        if (infoColision.collider.CompareTag("ShellEnemy"))
        {
            
            _smallExplosion.Play();

            
            _currentHealth -= _damageEnemyshell;
            _lifeBar.fillAmount = _currentHealth / _maxHealth;
            Destroy(infoColision.gameObject);

            if (_currentHealth <= 0.0f)
            {
                Death();
            }
        }

    }

    private void Death()
    {

        //Debemos extraer la cámara del objeto
        Camera.main.transform.SetParent(null);

        _gameManagerTanks.GameOver();

        //Ejecutamos la animación de la explosión
        _bigExplosion.Play();


        //Destruimos el tanque
        Destroy(gameObject, 1.0f);



    }
}