using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KiBlastSpawner : MonoBehaviour {

    public GameObject KiBlast;
    
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
                    Instantiate(KiBlast, SpawnPoint.position, Quaternion.identity);
                    timeStamp = Time.time + coolDown;
                }   
            }
       }
    }
}
