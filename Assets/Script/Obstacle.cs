using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class Obstacle : MonoBehaviour
{
    public int ObstacleNum;
    public MovePlayer Player;
    public ObstacleSpawner spawner;

    void Update()
    {
        if (transform.position.y - Player.transform.position.y <= -12)
        {
            spawner.SpawnObstacle(ObstacleNum);
            Destroy(gameObject);
        }
    }
}
