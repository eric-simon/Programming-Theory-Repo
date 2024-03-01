using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnPrefab;

    [SerializeField]
    private Vector3 startPos;

    [SerializeField]
    private float margin = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnLevel(startPos, 50);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnLevel(Vector3 start, int boxes)
    {
        Vector3 spawnPos = start;

        Instantiate(spawnPrefab, spawnPos, spawnPrefab.transform.rotation);

        foreach (var i in Enumerable.Range(0, boxes))
        {
            //pick a random direction and spawn there

            var angle = Random.Range(0, 2 * Mathf.PI);
                
            var direction = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));

            spawnPos = spawnPos + (direction * margin);

            Instantiate(spawnPrefab, spawnPos, spawnPrefab.transform.rotation);
        }
    }
}
