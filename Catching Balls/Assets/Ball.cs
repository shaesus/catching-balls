using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject slopeTrailPS;
    public GameObject landPS;

    private Rigidbody2D _rb;

    private Transform _basket;

    private ParticleSystem _trail;

    private Vector3 _trailOffset;

    private bool _isOnGround;
    
    private void Start()
    {
        _trailOffset = new Vector3(0, -0.15f, 0);
        
        _trail = Instantiate(slopeTrailPS, transform.position + _trailOffset, slopeTrailPS.transform.rotation)
            .GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (_trail != null)
        {
            _trail.transform.position = transform.position + _trailOffset;
        }
    }

    private void InitializeFields()
    {
        _rb = GetComponent<Rigidbody2D>();

        _basket = FindObjectOfType<Basket>().transform;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Slope"))
        {
            Debug.Log("Destroy trail");
            _trail.Stop();
            Destroy(_trail.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Basket"))
        {
            DisableBall();
        }
        else if (col.CompareTag("LoseScoreTrigger"))
        {
            GlobalEventManager.SendBallFall();
            Debug.Log("Ball felt");
        }
    }

    private void DisableBall()
    {
        ScoreManager.Instance.IncrementScore();

        InitializeFields();

        transform.parent = _basket;
        _rb.simulated = false;

        var landEffect = Instantiate(landPS, transform.position, quaternion.identity);
        Destroy(landEffect, 1f);
    }
}
