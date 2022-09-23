using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Scene03
{

    public class ReactiveCamera : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField]
        float _radius = 3.5f;
        [SerializeField]
        float _height = 10.0f;
        [SerializeField]
        float _speed = 4.0f;
        [SerializeField]
        Transform _target;


        #region AudioReactive
        [SerializeField]
        int _duration = 100;
        [SerializeField]
        Vector3 _offSet;
        int _curFrame = 0;
        bool _isMoving = false;
        bool _startFlag = false;
        Vector3 _nextPosition;
        Vector3 _prevPosition;
        Vector3 _dir;

        #endregion
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            ///_duration = OSCRecieveController.CamEaseTime;
            if (_isMoving == false)
            {
                if (OSCReciever.S3CamMove == 1.0f)
                {
                    _startFlag = true;
                    _isMoving = true;
                    _nextPosition = Random.insideUnitSphere * _radius + _offSet;
                    _prevPosition = this.transform.position;
                    _dir = (_nextPosition - _prevPosition) / _duration;
                }
            }
            if (_startFlag == true)
            {
                this.transform.position = _prevPosition + _dir * _curFrame * Easing.easeInOutCubic((float)(_curFrame) / (float)(_duration));
                _curFrame++;
                if (_curFrame == _duration)
                {
                    _isMoving = false;
                    _startFlag = false;
                    _curFrame = 0;
                }
            }
            this.transform.LookAt(_target, new Vector3(0, 1, 0));
        }
    }
}