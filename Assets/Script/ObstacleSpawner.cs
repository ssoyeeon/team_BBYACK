using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstacleType001;
    [SerializeField] private GameObject obstacleType002;

    [SerializeField] private float minXPosition = -5f;
    [SerializeField] private float maxXPosition = 5f;
    [SerializeField] private float lastObstaclePosition = 0;

    [SerializeField] private MovePlayer player;

    public void SpawnObstacle(int num)
    {
        lastObstaclePosition = Random.Range(minXPosition, maxXPosition);
        GameObject temp;
        if (num == 1)
        {
            temp = GameObject.Instantiate<GameObject>(obstacleType001);
        }
        else
        {
            temp = GameObject.Instantiate<GameObject>(obstacleType002);
        }
        temp.transform.position = new Vector3(Random.Range(maxXPosition, minXPosition), player.transform.position.y + 11, 0);
        var obstacle = temp.GetComponent<Obstacle>();
        obstacle.ObstacleNum = num;
        obstacle.Player = player;
        obstacle.spawner = this;
    }
}
