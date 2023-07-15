using UnityEngine;

/// <summary>
/// Transform.RotateAround‚ğ—p‚¢‚½‰~‰^“®
/// </summary>
public class UseRotateAround : MonoBehaviour
{
    // ’†S“_
    [SerializeField] private Vector3 _center = Vector3.zero;

    // ‰ñ“]²
    [SerializeField] private Vector3 _axis = Vector3.up;

    // ‰~‰^“®üŠú
    [SerializeField] private float _period = 2;
    [SerializeField] private float _DownSpeed = -1f;

    private void Update()
    {
        // ’†S“_center‚Ìü‚è‚ğA²axis‚ÅAperiodüŠú‚Å‰~‰^“®
        transform.RotateAround(
            _center,
            _axis,
            360 / _period * Time.deltaTime
        );
        transform.Translate(0f, _DownSpeed, 0f);
    }
}