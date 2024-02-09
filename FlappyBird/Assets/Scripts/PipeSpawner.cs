using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{

    private float _maxTime = 2.5f;
    private float _heigthRange = 0.45f;

    public PipePool pipePool;

    private float _timer;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer > _maxTime)
        {
            SpawnPipe();
            _timer = 0;
        }

        _timer += Time.deltaTime;
    }

    private void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-_heigthRange, _heigthRange));
        GameObject pipe = pipePool.GetInactiveGameObject();

        pipe.transform.position = spawnPos;

        pipe.SetActive(true);


    }
}
