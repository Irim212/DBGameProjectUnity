using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KiBlastSpawner : MonoBehaviour {

    public GameObject KiBlast;

    Player player = new Player();
    
    public Transform SpawnPoint;
    private float timeStamp;
    public float coolDown = 0.5f;

    void Update()
    {
       if(PlayerController.kiBlastHold)
       {
            if(timeStamp<=Time.time)
            {
                RaycastHit2D r = Physics2D.Raycast(SpawnPoint.position, Vector2.up);
                
                if(r.collider == null)
                {
                    if(player.playerStats.currentKi>10)
                    {
                        Instantiate(KiBlast, SpawnPoint.position, Quaternion.identity);
                        player.KiUse(player.playerStats.kiBlastCost);
                        timeStamp = Time.time + coolDown;
                    }
                }   
            }
       }
    }
}
