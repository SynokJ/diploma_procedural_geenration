using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveControll : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;

    private const float _MOVE_SCALE = 10.0f;
    private const float _ROTATE_SCALE = 3.0f;

    void Update()
    {
        rb.velocity = _MOVE_SCALE * transform.forward * Input.GetAxis("Vertical");
        transform.Rotate(new Vector3(0.0f, Input.GetAxis("Horizontal") * _ROTATE_SCALE, 0.0f));
    }
}
