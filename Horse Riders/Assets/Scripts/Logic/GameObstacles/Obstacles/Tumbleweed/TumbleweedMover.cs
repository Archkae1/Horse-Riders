using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TumbleweedMover : MonoBehaviour
{
    [SerializeField] private GameSettings gameSettings;
    private float speed;
    private new Rigidbody rigidbody;

    public void Load()
    {
        rigidbody = GetComponent<Rigidbody>();
        speed = gameSettings.tumbleweedSpeed;
        speed += Random.Range(-0.2f, 0.2f);
    }

    private void FixedUpdate()
    {
        speed = gameSettings.tumbleweedSpeed;
        rigidbody.velocity = new Vector3(0, 0, -speed);
        transform.eulerAngles -= new Vector3(speed * 3f, 0f, 0f);
    }

    public void StopMove()
    {
        rigidbody.velocity = Vector3.zero;
    }
}
