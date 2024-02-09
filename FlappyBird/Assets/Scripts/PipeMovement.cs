using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{

    private float _speed = 2f;
    private float _maxTime = 5f;
    private float _timer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()

    {
        transform.position += Vector3.left * _speed * Time.deltaTime;
 

        if (_timer > _maxTime)
        {
            gameObject.SetActive(false);
            _timer = 0;
        }

        _timer += Time.deltaTime;

    }
}
