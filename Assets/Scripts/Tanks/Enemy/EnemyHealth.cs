using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    // Zona de variables globales
    [Header("Health")]
    // Vida máxima del tanque
    [SerializeField]
    private float _maxHealth;
    // Vida actual
    [SerializeField]
    private float _currentHealth;
    // Daño que hacen las balas enemigas
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

    // Awake
    private void Awake()
    {

        // Inicialización de la vida del tanque
        _currentHealth = _maxHealth;
        _lifeBar.fillAmount = 1.0f;

        // Reseteamos las explosiones
        _bigExplosion.Stop();
        _smallExplosion.Stop();


    }
    private void OnCollisionEnter(Collision infoCollision)
    {

        if (infoCollision.collider.CompareTag("ShellTank"))
        {

            _smallExplosion.Play();

            _currentHealth -= _damageEnemyshell;
            _lifeBar.fillAmount = _currentHealth / _maxHealth;
            Destroy(infoCollision.gameObject);

            if (_currentHealth <= 0.0f)
            {
                Death();
            }
        }

    }


    private void Death()
    {

        _bigExplosion.Play();

        Destroy(gameObject, 1.0f);

    }
}
