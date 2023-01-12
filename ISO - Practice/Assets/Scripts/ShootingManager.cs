using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    public static int endShootingCnt;

    PlayerShoot playerShoot;
    private void Awake()
    {
        playerShoot = GameObject.Find("Player_Isometric_Witch").transform.GetChild(0).GetComponent<PlayerShoot>();
        endShootingCnt = 0;
    }

    public void CheckAllBulletArrived()
    {
        endShootingCnt++;
        if(endShootingCnt == playerShoot.bullets.Count)
        {
            endShootingCnt = 0;
            playerShoot.DestroyAllBullet();
        }
    }
}
