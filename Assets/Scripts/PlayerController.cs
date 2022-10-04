using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    // Reference to Instace of Remote Config
    private ApplyRemoteConfigSettings rcInstance;

    [SerializeField]
    private float m_MovementSpeed = 5.0f, m_CharacterSize = 1.0f;

    [SerializeField]
    private Animator m_AnimatorController;

    [SerializeField]
    private LayerMask m_InputCollisionLayer;

    // [SerializeField]
    // private GameManager m_GameManager;

    private bool m_HasKey = false;

    private Rigidbody m_Rigidbody;

    private int m_VelocityHash = Animator.StringToHash("Velocity");

    private Camera m_MainCamera;
    
    private RaycastHit m_HitInfo;
    
    const float k_MinMovementDistance = 1.2f;

    void Start()
    {   
        m_Rigidbody = GetComponent<Rigidbody>();
        m_MainCamera = Camera.main;
    }

    private void KeyCollected()
    {
        m_HasKey = true;

        //TODO: Put this outside of the PlayerController
        GameObject.FindObjectOfType<GameplayUI>().KeyCollected();
    }

    private void OnTriggerEnter(Collider other)
    {
        //TODO: Cache the string value
        if (other.CompareTag("Chest"))
        {
            // TODO: Maybe cache the getcomponent read, although it is only read once
            other.gameObject.GetComponent<Chest>().Open();

            KeyCollected();
        }

        if (other.CompareTag("Door"))
        {
            Debug.Log("Triggered by a door");

            if(m_HasKey)
            {
                Debug.Log("Opened the door");

                other.gameObject.GetComponent<Door>().Open();

                // TODO: Change this number to a member variable
                StartCoroutine(LevelCompleted());
            }
        }
    }

    private IEnumerator LevelCompleted()
    {
        yield return new WaitForSeconds(2.15f);

        GameManager.LevelCompleted();
    }

    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
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
        // apply animation
        m_AnimatorController.SetFloat(m_VelocityHash, m_Rigidbody.velocity.magnitude);
    }

    void MoveToPosition(Vector2 screenPosition)
    {
        Ray ray = m_MainCamera.ScreenPointToRay(screenPosition);

        if (Physics.Raycast(ray, out m_HitInfo, Mathf.Infinity, m_InputCollisionLayer))
        {
            ApplyMoveToPosition();
        }
		// Did we click on something else thats not the ground? If so find where that object is
        else if (Physics.Raycast(ray, out m_HitInfo, Mathf.Infinity))
        {
            Ray downRay = new Ray(m_HitInfo.point, Vector3.down);

            // And now cast down to find the ground point to move to
            if (Physics.Raycast(downRay, out m_HitInfo, Mathf.Infinity, m_InputCollisionLayer))
            {
                ApplyMoveToPosition();
            }
        }
    }

    void ApplyMoveToPosition()
    {
        // don't move if touching close to character
        if (Vector3.Distance(m_Rigidbody.position, m_HitInfo.point) < k_MinMovementDistance)
        {
            return;
        }

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

    public void SetMovementSpeed(float speed)
    {
        m_MovementSpeed = speed;
        Debug.Log("Movement Speed Set! " + m_MovementSpeed);
    }

    public void SetCharacterSize(float size)
    {
        m_CharacterSize = size;
        gameObject.transform.localScale = new Vector3(m_CharacterSize,m_CharacterSize,m_CharacterSize);
        Debug.Log("Local Scale Set! " + gameObject.transform.localScale);
    }
}
