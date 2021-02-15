using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigid;

    public Vector2 Velocity => _rigid.velocity;
    
    public void SetPosition(Vector3 position)
    {
        _rigid.position = position;
    }

    public void SetParent(Transform parent)
    {
        transform.SetParent(parent, false);
    }

    public void SetVelocity(Vector2 velocity)
    {
        _rigid.velocity = velocity;
    }
}

