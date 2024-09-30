using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject movementIndicatorPrefab;  
    private CharacterSelection characterSelection; 
    private GameObject currentIndicator;  

    void Start()
    {
        characterSelection = FindObjectOfType<CharacterSelection>();
    }

    void Update()
    {
        GameObject selectedCharacter = characterSelection.GetCurrentSelection();

        if (selectedCharacter != null && selectedCharacter == gameObject)
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                Ray movePosition = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(movePosition, out var hitInfo))
                {
                    // Move 
                    agent.SetDestination(hitInfo.point);

                    PlaceMovementIndicator(hitInfo.point);
                }
            }
        }
    }

    private void PlaceMovementIndicator(Vector3 position)
    {
        if (currentIndicator != null)
        {
            Destroy(currentIndicator);
        }

        // Instantiate a new 
        if (movementIndicatorPrefab != null)
        {
            currentIndicator = Instantiate(movementIndicatorPrefab, position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("d");
        }
    }
}
