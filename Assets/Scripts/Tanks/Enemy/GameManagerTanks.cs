using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerTanks : MonoBehaviour
{
    // Zona variables globales
    [Header("Instantiate")]
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private Transform[] _postRotEnemy;
    [SerializeField]
    private float _timeBetweenEnemies;

    [Header("Game Over")]
    [SerializeField]
    private GameObject _panelGameOver;


    private void Start()
    {
       
        InvokeRepeating("CreateEnemies", _timeBetweenEnemies, _timeBetweenEnemies);

    }

    public void GameOver()
    {

        // Activamos el panel de Game Over
        _panelGameOver.SetActive(true);

        // Desactivamos el componente EnemyManager
        // _enemyManager.enabled = false;

    }

    private void CreateEnemies()
    {
        int n = Random.Range(0, _postRotEnemy.Length);

        Instantiate(_enemyPrefab, _postRotEnemy[n].position, _postRotEnemy[n].rotation);


    }
}