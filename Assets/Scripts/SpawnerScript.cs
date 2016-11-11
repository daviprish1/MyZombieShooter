using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {

    public PlayerScript playerScript;       // Ref to player
    public GameObject enemy;                // enemy prefab for spawn
    public float spawnTime = 3f;            // delay before spawn
    public Transform[] spawnPoints;         

    // Use this for initialization
    void Start () {
        // Repeat spawning
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void Spawn()
    {
        if (playerScript.health <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
