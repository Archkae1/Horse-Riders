using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TumbleweedMover : MonoBehaviour
{
    [SerializeField] private float speed;
    private new Rigidbody rigidbody;

    public float setSpeed { set { speed = value; } }

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector3(0, 0, -speed);
        transform.eulerAngles -= new Vector3(speed * 3f, 0f, 0f);
    }

    public void LoadTumbleweedMover()
    {
        rigidbody = GetComponent<Rigidbody>();
        speed += Random.Range(-0.2f, 0.2f);
    }

    public void StopMove()
    {
        rigidbody.velocity = Vector3.zero;
    }
}
