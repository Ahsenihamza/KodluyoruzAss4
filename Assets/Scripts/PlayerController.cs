using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerSettings _playerSettings;

        private CharacterController _controller;
        private Vector3 _moveDirection;
        private Vector3 _moveRotation;
        private float _currentYRotationValue;
        private bool _isJumping;

        // Start is called before the first frame update
        private void Start()
        {
            _controller = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        private void Update()
        {
            if(!_isJumping)
            {
                _moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            }
            else
            {
                _moveDirection = new Vector3(0, _playerSettings.jumpForce, 0);
            }

            _currentYRotationValue += Input.GetAxis("Horizontal");
            _moveRotation = new Vector3(0, _currentYRotationValue, 0);
            _moveDirection = Quaternion.Euler(_moveRotation) * _moveDirection;

            if (_controller.isGrounded && !_isJumping)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _moveDirection.y = _playerSettings.jumpForce;
                    StartCoroutine(Jump());
                }
            }
            transform.rotation = Quaternion.Euler(_moveRotation);

            if(!_isJumping)
            {
                _moveDirection.y += _moveDirection.y + Physics.gravity.y * _playerSettings.garvityScale;
            }

            _controller.Move(_moveDirection * Time.deltaTime * _playerSettings.moveSpeed);

        }

        private IEnumerator Jump()
        {
            _isJumping = true;
            yield return new WaitForSeconds(_playerSettings.jumpTime);
            _isJumping = false;
        }


    }
    [System.Serializable]
    public struct PlayerSettings
    {
        public float moveSpeed;
        public float jumpForce;
        public float garvityScale;
        public float jumpTime;
    }

}


