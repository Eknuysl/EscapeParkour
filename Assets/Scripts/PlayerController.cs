using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform Center;
    [SerializeField] Transform Left;
    [SerializeField] Transform Right;

    private int _currentPos = 0;
    

    public float _sideSpeed;
    public float _runningSpeed;
    public float _jumpForce ;
    public bool magnet = false;
    public float fallMultiplier = 2.5f; // Hızlı düşüş çarpanı

    [SerializeField] Rigidbody _rigidbody;

    bool isGameStarted = false;
    bool isGameOver = false;
    [SerializeField] Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        isGameStarted = false;
        isGameOver = false;
        _currentPos = 0; // 0=Center, 1=Left, 2=Right
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameStarted && !isGameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Game is Started!");
                isGameStarted = true;
                _animator.SetInteger("isRunning", 1);
                _animator.speed = 1.3f;
            }
        }

        if (isGameStarted)
        {
            // İleri doğru hareket
            transform.position = new Vector3(transform.position.x, transform.position.y,
                transform.position.z + _runningSpeed * Time.deltaTime);

            // Sağa ve sola geçiş
            HandleSideMovement();

            // Zıplama
            if (Input.GetKeyDown(KeyCode.UpArrow) && Mathf.Abs(_rigidbody.velocity.y) < 0.01f)
            {
                _rigidbody.velocity = Vector3.up * _jumpForce;
                StartCoroutine(Jump());
            }

            // Daha hızlı düşüş
            if (_rigidbody.velocity.y < 0)
            {
                _rigidbody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
        }
    }

    void HandleSideMovement()
    {
        if (_currentPos == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _currentPos = 1;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _currentPos = 2;
            }
        }
        else if (_currentPos == 1)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _currentPos = 0;
            }
        }
        else if (_currentPos == 2)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _currentPos = 0;
            }
        }

        // Yan hareket
        Vector3 targetPosition = transform.position;

        if (_currentPos == 0)
            targetPosition.x = Center.position.x;
        else if (_currentPos == 1)
            targetPosition.x = Left.position.x;
        else if (_currentPos == 2)
            targetPosition.x = Right.position.x;

        if (Vector3.Distance(transform.position, targetPosition) >= 0.1f)
        {
            Vector3 dir = targetPosition - transform.position;
            transform.Translate(dir.normalized * (_sideSpeed * Time.deltaTime), Space.World);
        }
    }

    IEnumerator Jump()
    {
        _animator.SetInteger("isJump", 1);
        yield return new WaitForSeconds(0.1f);
        _animator.SetInteger("isJump", 0);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Object")
        {
            isGameStarted = false;
            isGameOver = true;
            _animator.applyRootMotion = true;
            _animator.SetInteger("died", 1);
            Invoke("gameOver", 2);
        }
        
        
    }
    public void gameOver()
    {
        SceneManager.LoadScene("Game Over"); 
    }
    
}
