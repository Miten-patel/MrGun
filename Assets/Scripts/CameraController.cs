using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private Transform _player;

    // Update is called once per frame
    void Update()
    {
        CameraFollow();
    }

    public void CameraFollow()
    {
        if (_player.transform.position.y > transform.position.y && _player != null)
        {

            Vector3 newPos = new Vector3(transform.position.x, _player.position.y, transform.position.z);
            transform.position = newPos;
        }
    }
}
