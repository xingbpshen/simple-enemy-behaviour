using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] Transform[] patrolPoints;
    [SerializeField] float _speed = 1f;

    Transform _target;

    private void Start() {
        _target = patrolPoints[0];
    }
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _target.position, _speed * Time.deltaTime);
    }
}
