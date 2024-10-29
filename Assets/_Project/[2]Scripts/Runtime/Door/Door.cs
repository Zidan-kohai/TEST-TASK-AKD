using Helper;
using System.Collections;
using UnityEngine;

namespace Runtime.Door
{
    public class Door : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] private Transform _doorVisual;
        [SerializeField] private float _speed;
        [SerializeField] private float lerp = 0.0f;


        [Header("Open")]
        [SerializeField] private Vector3 _openEndPosition;
        [SerializeField] private Vector3 _openEndRotation;
        private Quaternion _openEndRotationQuaternion;


        [Header("Close")]
        [SerializeField] private Vector3 _closeEndPosition;
        [SerializeField] private Vector3 _closeEndRotation;
        private Quaternion _closeEndRotationQuaternion;

        private WaitForEndOfFrame waitForEndOfFrame = new();
        private Coroutine Coroutine;

        private void Awake()
        {
            _openEndRotationQuaternion = Quaternion.Euler(_openEndRotation);
            _closeEndRotationQuaternion = Quaternion.Euler(_closeEndRotation);
        }

        private IEnumerator Open()
        {
            while (lerp < 1)
            {
                lerp += _speed * Time.deltaTime;

                _doorVisual.transform.localPosition = Vector3.Lerp(_closeEndPosition, _openEndPosition, lerp);

                _doorVisual.transform.rotation = Quaternion.Slerp(_closeEndRotationQuaternion, _openEndRotationQuaternion, lerp);

                yield return waitForEndOfFrame;
            }
        }

        private IEnumerator Close()
        {
            while (lerp > 0)
            {
                lerp -= _speed * Time.deltaTime;

                _doorVisual.transform.localPosition = Vector3.Lerp(_closeEndPosition, _openEndPosition, lerp);

                _doorVisual.transform.rotation = Quaternion.Slerp(_closeEndRotationQuaternion, _openEndRotationQuaternion, lerp);

                yield return waitForEndOfFrame;
            }
        }


        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == Tags.Player)
            {
                if(Coroutine != null)
                    StopCoroutine(Coroutine);
                Coroutine = StartCoroutine(Open());
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == Tags.Player)
            {
                if (Coroutine != null)
                    StopCoroutine(Coroutine);
                Coroutine = StartCoroutine(Close());
            }
        }
    }
}
