using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
using UnityEngine;

public class FlappyMovement : MonoBehaviour
{
    public float force;
    public KeyCode jumpKey;

    private Rigidbody2D _rb;
    private float _rotationSpeed = 10f;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            _rb.velocity = Vector2.zero;
            _rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, _rb.velocity.y * _rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.GameOver();
        AdManager.instance.ShowAd();
    }
}

    

