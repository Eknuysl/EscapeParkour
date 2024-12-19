using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform Center;
    [SerializeField] Transform Left;
    [SerializeField] Transform Right;

    private int _currentPos = 0;

    public float _sideSpeed;
    public float _runningSpeed;
    public float _jumpForce;

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
        if (!isGameStarted || !isGameOver)
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
            transform.position = new Vector3(transform.position.x, transform.position.y,
                transform.position.z + _runningSpeed * Time.deltaTime);
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

            if (_currentPos == 0)
            {
                if (Vector3.Distance(transform.position,
                        new Vector3(Center.position.x, transform.position.y, transform.position.z)) >= 0.1f)
                {
                    Vector3 dir = new Vector3(Center.position.x, transform.position.y, transform.position.z) -
                                  transform.position;
                    transform.Translate(dir.normalized * (_sideSpeed * Time.deltaTime), Space.World);
                }
            }
            else if (_currentPos == 1)
            {
                if (Vector3.Distance(transform.position,
                        new Vector3(Left.position.x, transform.position.y, transform.position.z)) >= 0.1f)
                {
                    Vector3 dir = new Vector3(Left.position.x, transform.position.y, transform.position.z) -
                                  transform.position;
                    transform.Translate(dir.normalized * (_sideSpeed * Time.deltaTime), Space.World);
                }
            }
            else if (_currentPos == 2)
            {
                if (Vector3.Distance(transform.position,
                        new Vector3(Right.position.x, transform.position.y, transform.position.z)) >= 0.1f)
                {
                    Vector3 dir = new Vector3(Right.position.x, transform.position.y, transform.position.z) -
                                  transform.position;
                    transform.Translate(dir.normalized * (_sideSpeed * Time.deltaTime), Space.World);
                }
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _rigidbody.velocity = Vector3.up * _jumpForce;
                StartCoroutine(Jump());
            }
        }
    }

    IEnumerator Jump()
    {
        _animator.SetInteger("isJump", 1);
        yield return new WaitForSeconds(0.1f);
        _animator.SetInteger("isJump", 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "object")
        {
            isGameStarted = false;
            isGameOver = true;
            _animator.applyRootMotion = true;
            _animator.SetInteger("died", 1);

        }
    }
}
