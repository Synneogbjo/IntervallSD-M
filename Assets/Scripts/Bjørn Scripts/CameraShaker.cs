using System.Collections;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    private Transform _Target;

    private bool _IsShaking;
    
    private float _PendingShakeDuration;
    private float _Strength;

    private void Start()
    {
        _Target = GetComponent<Transform>();
    }

    public void Shake(float duration, float strength)
    {
        if (duration > 0)
        {
            _PendingShakeDuration += duration;
            _Strength = strength;
        }
    }

    private void Update()
    {
        if (_PendingShakeDuration > 0 && !_IsShaking)
        {
            StartCoroutine(DoShake());
        }
    }

    IEnumerator DoShake()
    {
        _IsShaking = true;

        var startTime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < startTime + _PendingShakeDuration)
        {
            var randomPoint = new Vector3(Random.Range(-_Strength, _Strength), Random.Range(-_Strength, _Strength), 0f);
            _Target.localPosition = _Target.position + randomPoint;
            yield return null;
        }

        _PendingShakeDuration = 0f;
        _Target.localPosition = _Target.position;
        _IsShaking = false;
    }
}