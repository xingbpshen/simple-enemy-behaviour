using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Collider))]
[DisallowMultipleComponent]
public class Chase : MonoBehaviour
{
    [SerializeField] float _speed = 3f;

    Transform _target = null;
    bool isActive = false;

    void Update()
    {
        if (!isActive || _target == null)
        {
            return;
        }
        transform.LookAt(_target);
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            isActive = true;
            _target = other.transform;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player"))
        {
            isActive = false;
            if (_target.transform == other.transform)
            {
                _target = null;
            }
        }
    }
}
