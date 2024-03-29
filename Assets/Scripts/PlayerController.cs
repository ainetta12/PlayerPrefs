using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
       
       private CharacterController _controller;
       private Transform _camera;
       private float _horizontal;
       private float _vertical;

       [SerializeField] private float _playerSpeed = 5;
       [SerializeField]private Transform sensorPosition;
       [SerializeField] private float sensorRadius = 0.2f;
       [SerializeField] private float groundLayer;

       private float gravity = -9.81f;
       private Vector3 _playergravity;
       private float turnSmoothVeloity;
       private float turnSmoothTime = 0.1f;
       private bool _isGrounded;

       Manager _manager;

        void Awake()
       {
           _controller = GetComponent<CharacterController>();
           _camera = Camera.main.transform;

           _manager = GameObject.Find("Manager").GetComponent<Manager>();
       }

       void Update()
       {
           _horizontal = Input.GetAxisRaw("Horizontal");
           _vertical = Input.GetAxisRaw("Vertical");

           Movement();
        
       }

       void Movement()
       {
           Vector3 direction = new Vector3(_horizontal, 0, _vertical);

           if (direction != Vector3.zero)

           {
               float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _camera.eulerAngles.y;
               float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVeloity, turnSmoothTime);
               transform.rotation = Quaternion.Euler(0, smoothAngle, 0);
               Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
               _controller.Move(moveDirection * _playerSpeed * Time.deltaTime);
           }

       }

       void OnTriggerEnter (Collider other)
       {
        if(other.gameObject.layer == 7)
        {
            _manager.userName = 1;
            _manager.SaveData();
            
        }

        if(other.gameObject.layer == 8)
        {
            _manager.userName = 2;
            _manager.SaveData();

        }

        if(other.gameObject.layer == 9)
        {
            _manager.userName = 3;
            _manager.SaveData();

        }

       }



}       
