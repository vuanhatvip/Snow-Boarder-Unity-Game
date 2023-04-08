using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Physics")]
    [Tooltip("Add amount for Toreque")] [SerializeField] private float m_torqueAmount = 1f;
    [Tooltip("Boost Speed")] [SerializeField] private float m_boostSpeed = 30f;
    [Tooltip("Base Speed")] [SerializeField] private float m_baseSpeed = 15f;

    Rigidbody2D _rb2d;
    SurfaceEffector2D _surfaceEffector2D;
    bool _canMove = true;

    // Start is called before the first frame update
    void Start()
    {
       _rb2d = GetComponent<Rigidbody2D>();
       _surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_canMove)
        {
            return;
        }

        RotatePlayer();
        RespondToBoost();
    }

    private void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _surfaceEffector2D.speed = m_boostSpeed;
        }
        else
        {
            _surfaceEffector2D.speed = m_baseSpeed;
        }
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _rb2d.AddTorque(m_torqueAmount);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _rb2d.AddTorque(-m_torqueAmount);
        }
    }

    public void DisableControl()
    {
        _canMove = false;
    }
}
