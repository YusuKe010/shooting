using UnityEngine;

/// <summary>
/// Transform.RotateAround��p�����~�^��
/// </summary>
public class UseRotateAround : MonoBehaviour
{
    // ���S�_
    [SerializeField] private Vector3 _center = Vector3.zero;

    // ��]��
    [SerializeField] private Vector3 _axis = Vector3.up;

    // �~�^������
    [SerializeField] private float _period = 2;
    [SerializeField] private float _DownSpeed = -1f;

    private void Update()
    {
        // ���S�_center�̎�����A��axis�ŁAperiod�����ŉ~�^��
        transform.RotateAround(
            _center,
            _axis,
            360 / _period * Time.deltaTime
        );
        transform.Translate(0f, _DownSpeed, 0f);
    }
}