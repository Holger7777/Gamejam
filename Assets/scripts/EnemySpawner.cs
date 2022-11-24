using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Enemy Spawner taken from https://github.com/Tutorials-By-Kaupenjoe/Basic-Unity-2020.3-Tutorials/tree/11-enemySpawner/Assets
*/
public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _kamiKaze;
    
    [SerializeField]
    private GameObject _kamiKaze1;
        /*
    [SerializeField]
    private GameObject //swarmerPrefab;
    [SerializeField]
    private GameObject //bigSwarmerPrefab;
    */

    [SerializeField]
    private float KamiKazeInterval = 3.5f;

    [SerializeField]
     private float KamiKaze1Interval = 3.5f;
    /*
     [SerializeField]
     private float //swarmerInterval = 3.5f;
     [SerializeField]
     private float //bigSwarmerInterval = 10f;
    */

    [SerializeField] private GameObject _arena;
    private MeshCollider _spawnArea;

    void Awake()
    {
        _spawnArea = _arena.GetComponent<MeshCollider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(KamiKazeInterval, _kamiKaze));

        //StartCoroutine(spawnEnemy(//bigSwarmerInterval, bigSwarmerPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        float arenaX, arena›;
        Vector2 spawnPos;
        arenaX = Random.Range(_spawnArea.bounds.min.x, _spawnArea.bounds.max.x);
        arena› = Random.Range(_spawnArea.bounds.min.y, _spawnArea.bounds.max.y);
        spawnPos = new Vector2(arenaX, arena›);
        GameObject newEnemy = Instantiate(enemy, spawnPos, Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
