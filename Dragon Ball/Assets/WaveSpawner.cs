using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public enum SpawnState { SPAWNING, WAITING, COUNTING};

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    public int NextWave = 0;

    public Transform[] spawnPoints;
    public int spawnPointNumber = 0;

    public float timeBeetweenWaves = 5f;
    private float waveCountDown;

    private float searchCountdown = 1f;

    public SpawnState state = SpawnState.COUNTING;

    void Start()
    {
        waveCountDown = timeBeetweenWaves;
    }

    void Update()
    {
        if(state == SpawnState.WAITING)
        {
            // check if enemies are still alive
            if(!EnemyIsAlive())
            {
                //Begin new round
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if(waveCountDown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                //Start spawning wave
                StartCoroutine(SpawnWave(waves[NextWave]));
            }
        }
        else
        {
            waveCountDown -= Time.deltaTime;
        }
    }

    void WaveCompleted ()
    {
        
        state = SpawnState.COUNTING;
        waveCountDown = timeBeetweenWaves;

        if(NextWave + 1 > waves.Length - 1)
        {
            NextWave = 0;
            EnemyThrash.EnemyStat.level++;
        }
        else
        {
            NextWave++;
            spawnPointNumber = 0;
        }
    }

    bool EnemyIsAlive ()
    {
        searchCountdown -= Time.deltaTime;
        if(searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }

        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.SPAWNING;

        // Spawn
        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
            spawnPointNumber++;
        }

        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        // Spawn enemy

        if(spawnPoints.Length == 0)
        {
            Debug.Log("No spawn points referenced.");
            return;
        }
        Transform _sp = spawnPoints[spawnPointNumber];
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }
}
