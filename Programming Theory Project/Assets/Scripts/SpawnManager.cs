using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnPrefab;

    [SerializeField]
    private GameObject spawnFinisherPrefab;

    [SerializeField]
    private Vector3 startPos;

    [SerializeField]
    private float margin = 20.0f;

    List<Color> boxColors = new()
    {
        new Color(1, 0, 1, 1),
        new Color(0, 0, 1, 1),
        new Color(0.5f, 0.5f, 0.5f, 1),
        new Color(1, 0.92f, 0.016f, 1),
        new Color(0, 1, 1, 1),
        new Color(1, 1, 0, 1),
        new Color(1, 0, 1, 1),
        new Color(1, 0, 0, 1),
        new Color(1, 0, 1, 1),
        new Color(0, 0, 0, 1),
    };

    // Start is called before the first frame update
    void Start()
    {
        SpawnLevel(startPos, MainManager.Instance.Level + 5, MainManager.Instance.Level);

        Time.timeScale = 1 + MainManager.Instance.Level / 10f;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnLevel(Vector3 start, int boxes, int level)
    {
        Vector3 spawnPos = start;

        foreach (var i in Enumerable.Range(0, boxes))
        {
            var box = Instantiate(spawnPrefab, spawnPos, spawnPrefab.transform.rotation);

            var script = box.GetComponent<BoxMover>();

            script.Motion = BoxMotionFactory.SpawnBoxMotion(level, i);

            box.transform.GetChild(0).GetComponent<Renderer>().material.color = boxColors[level % boxColors.Count];

            //pick a random direction and spawn there

            var angle = Random.Range(-Mathf.PI/2, Mathf.PI/2);
                
            var direction = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));

            spawnPos = spawnPos + (direction * margin);
        }

        Instantiate(spawnFinisherPrefab, spawnPos, spawnPrefab.transform.rotation);        
    }
}
