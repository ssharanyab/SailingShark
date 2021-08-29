using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController _controller;
    private Vector3 _direction;
    public float forwardSpeed;
    private int _desiredLane = 1; //0: Left, 1:Center, 2:Right
    public float laneDistance = 4;
    public float jumpforce;
    public float Gravity = -20;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!PlayerManager.isGameStarted)
            return;
        _direction.z = forwardSpeed;
        

        if (_controller.isGrounded)
        {
            _direction.y = -1;
            if (SwipeManager.swipeUp)
            {
                Jump();
            }
        }
        else
        {
            _direction.y += Gravity * Time.deltaTime;
        }
        if (SwipeManager.swipeRight)
        {
            _desiredLane++;
            if (_desiredLane == 3)
                _desiredLane = 2;

        }
        if (SwipeManager.swipeLeft)
        {
            _desiredLane--;
            if (_desiredLane == -1)
                _desiredLane = 0;

        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (_desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (_desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        // transform.position = targetPosition;
        // _controller.center = _controller.center;
        if (transform.position ==targetPosition)
            
        {
            return;
        }

        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude<diff.sqrMagnitude)
        {
            _controller.Move(diff);
        }
        else
        {
            _controller.Move(diff);
        }
    }

    private void FixedUpdate()
    {
        if(!PlayerManager.isGameStarted)
            return;
        _controller.Move(_direction*Time.fixedDeltaTime);
    }

    private void Jump()
    {
        _direction.y = jumpforce;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        {
            PlayerManager.GameOver = true;
            FindObjectOfType<AudioManager>().PlaySound("Game over");
        }
    }
}
