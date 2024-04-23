using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacle : MonoBehaviour
{
    public int ObstacleNum;
    public MovePlayer Player;
    public ObstacleSpawner spawner;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y - Player.transform.position.y <= -11)
        {
            spawner.SpawnObstacle(ObstacleNum);
            Destroy(gameObject);
        }
    }
}
