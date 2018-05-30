using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThrash : MonoBehaviour {

    [System.Serializable]
    public class EnemyStat
    {
        public static int level = 1;
        public static int maxHp = 100 * level;
        public static int currentHp;
        public static int damage;

        private Animator anim;
        private Rigidbody2D rb;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
