using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;

    private Rigidbody2D rig;

    private float initSpeed;
    private bool _isRunning;
    private Vector2 _direction;
    
    public Vector2 direction
    {
        get{return _direction; }
        set{_direction = value; }
    }

    public bool isRunning
    {
        get{return _isRunning; }
        set{_isRunning = value; }
    }
  
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        initSpeed = speed;
    }

    private void Update()
    {
        OnInput();
        OnRun();
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    #region Movement
    
    void OnInput()
    {
        _direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void OnMove()
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            _isRunning = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initSpeed;
            _isRunning = false;
        }
    }

    #endregion    
}
