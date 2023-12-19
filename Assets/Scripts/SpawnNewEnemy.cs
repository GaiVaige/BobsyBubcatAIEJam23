using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNewEnemy : MonoBehaviour
{
    public Transform _enemySpawn;
    public GameObject _enemiesToSpawn;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject go = Instantiate(_enemiesToSpawn, _enemySpawn);
            go.transform.parent = null;
            Destroy(this.gameObject);
        }
    }

}
