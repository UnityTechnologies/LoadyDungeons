using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float m_MovementSpeed = 5.0f;

    [SerializeField]
    private Animator m_AnimatorController;

    private bool m_HasKey = false;

    private Rigidbody m_Rigidbody;

    private int m_VelocityHash = Animator.StringToHash("Velocity");

    private Camera m_MainCamera;
    
    private RaycastHit m_HitInfo;
    
    const float k_MinMovementDistance = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_MainCamera = Camera.main;
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
            KeyCollected();
        }

        if (other.CompareTag("Door"))
        {
            Debug.Log("Triggered by a door");

            if(m_HasKey)
            {
                Debug.Log("Opened the door");

                GameManager.LevelCompleted();
            }
        }
    }

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            MoveToPosition(Input.mousePosition);
        }
        else
        {
            m_Rigidbody.velocity = Vector3.zero;
        }

#elif UNITY_IOS || UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            MoveToPosition(touch.position);
        }
        else
        {
            m_Rigidbody.velocity = Vector3.zero;
        }
#endif
        // apply aniamtion
        m_AnimatorController.SetFloat(m_VelocityHash, m_Rigidbody.velocity.magnitude);
    }

    void MoveToPosition(Vector2 screenPosition)
    {
        if (Physics.Raycast(m_MainCamera.ScreenPointToRay(screenPosition), out m_HitInfo))
        {
            // don't move if touching close to character
            if (Vector3.Distance(m_Rigidbody.position, m_HitInfo.point) > k_MinMovementDistance)
            {
                // rotation
                m_Rigidbody.transform.LookAt(m_HitInfo.point, Vector3.up);
                // lock rotation to y 
                Vector3 eulerAngle = m_Rigidbody.transform.eulerAngles;
                m_Rigidbody.transform.eulerAngles = new Vector3(0, eulerAngle.y, 0);

                // calculate move direction vector
                Vector3 movementDirection = m_HitInfo.point - m_Rigidbody.position;
                movementDirection.Normalize();

                // apply calculated velocity
                m_Rigidbody.velocity = movementDirection * m_MovementSpeed;
            }
        }
    }
}
