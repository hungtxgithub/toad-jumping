using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dashing : MonoBehaviour
{

    private TrailRenderer _trailRender;
    private Rigidbody2D _rigidbody;

    [Header("Dashing")]
    [SerializeField] private float _dashingVelocity = 2f;
    [SerializeField] private float _dashingTime = 0.1f;
    private Vector2 _dashingDir;
    private bool _isDashing;
    private bool _canDash = true;
    private Timer _timer;

    // Start is called before the first frame update
    void Start()
    {
        _trailRender = GetComponent<TrailRenderer>(); 
        _rigidbody = GetComponent<Rigidbody2D>();
        _timer = gameObject.AddComponent<Timer>();
        _timer.Duration = 2;
        _dashingDir = new Vector2(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        var dashInput = Input.GetButtonDown("Jump");

        //if (dashInput && _canDash)
        //{
        //    _isDashing = true;
        //    _canDash = false;
        //    _trailRender.emitting = true;
        //    _dashingDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        //    if(_dashingDir == Vector2.zero)
        //    {
        //        _dashingDir = new Vector2(transform.localScale.x, 0);
        //    }
        //    // Add stopping dash
        //    StopCoroutine(StopDashing());
        //}

        //_dashingDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (dashInput)
        {
            _isDashing = true;
            _timer.Run();
        }

        if (_timer.Finished)
        {
            _rigidbody.velocity = Vector2.zero;
            _isDashing = false;
        }

        if (_isDashing)
        {
            if(!_timer.Finished)
            _rigidbody.velocity = _dashingDir.normalized * _dashingVelocity;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _rigidbody.angularVelocity = 0;
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    private IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(_dashingTime);
        _trailRender.emitting = false;
        _isDashing = false;
    }
}
