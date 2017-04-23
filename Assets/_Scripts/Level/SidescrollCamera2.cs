using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidescrollCamera2 : MonoBehaviour {

    public GameObject enemy;

    PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public void SpawnEnemy()
    {
        enemy.SetActive(true);
        BGMManager.instance.PlayBGM("EnemyAppears");
        player.SetSpeed(11f);
        player.freeze = true;
        player.lastLevel = true;
    }


    public void UnfreezePlayer()
    {
        player.freeze = false;

    }

    public void IncreaseEnemySpeed()
    {
        enemy.GetComponent<EnemyController>().IncSpeed();

    }



}
