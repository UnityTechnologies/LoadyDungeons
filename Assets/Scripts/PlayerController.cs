using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float m_MovementSpeed = 5.0f;

    private Rigidbody m_Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            var targetPosition = transform.position + Vector3.left * m_MovementSpeed * Time.deltaTime;
            m_Rigidbody.MovePosition(targetPosition);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            var targetPosition = transform.position + Vector3.right * m_MovementSpeed * Time.deltaTime;
            m_Rigidbody.MovePosition(targetPosition);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            var targetPosition = transform.position + Vector3.forward * m_MovementSpeed * Time.deltaTime;
            m_Rigidbody.MovePosition(targetPosition);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            var targetPosition = transform.position + Vector3.back * m_MovementSpeed * Time.deltaTime;
            m_Rigidbody.MovePosition(targetPosition);
        }
    }
}
