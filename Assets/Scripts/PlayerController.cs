using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float m_MovementSpeed = 5.0f;

    private bool m_HasKey = false;

    private Rigidbody m_Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void KeyCollected()
    {
        m_HasKey = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Cache the string value
        if (other.CompareTag("Chest"))
        {
            Debug.Log("Triggered by a chest");
            m_HasKey = true;
        }

        if (other.CompareTag("Door"))
        {
            Debug.Log("Triggered by a door");

            if(m_HasKey)
            {
                Debug.Log("Opened the door");

                //TODO: Cache this object search
                GameManager.LoadLoadingScene();
            }
        }
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
