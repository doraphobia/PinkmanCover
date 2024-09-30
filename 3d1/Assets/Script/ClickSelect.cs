using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject selectionIndicatorPrefab; //  selection marker prefab 
    private GameObject currentSelection = null; 
    private GameObject currentSelectionMarker = null; 
    private CameraControl cameraControl; 

    void Start()
    {
        cameraControl = FindObjectOfType<CameraControl>();
        if (cameraControl == null)
        {
            Debug.LogError(" not found .");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit)) 
            {
                GameObject selectedObject = hit.transform.gameObject;

                // Check  tag
                if (selectedObject.CompareTag("Selectable"))
                {

                    // Deselect
                    if (currentSelection != null && currentSelectionMarker != null)
                    {
                        Destroy(currentSelectionMarker); // Destroy 
                    }

                    // Select the new character
                    currentSelection = selectedObject;

                    if (selectionIndicatorPrefab != null)
                    {
                        Vector3 markerPosition = selectedObject.transform.position + new Vector3(0, 2.0f, 0);
                        currentSelectionMarker = Instantiate(selectionIndicatorPrefab, markerPosition, Quaternion.identity);

                        currentSelectionMarker.transform.SetParent(selectedObject.transform);
                    }
                    else
                    {
                        Debug.LogError(".");
                    }

                    if (cameraControl != null)
                    {
                        cameraControl.SetTarget(selectedObject.transform);
                    }
                    else
                    {
                        Debug.LogError("missing.");
                    }
                }
                else
                {

                    if (currentSelection != null && currentSelectionMarker != null)
                    {
                        Destroy(currentSelectionMarker); 
                        currentSelection = null; // Deselect 

                        // Stop the camera  following 
                        if (cameraControl != null)
                        {
                            cameraControl.SetTarget(null);
                        }
                    }
                }
            }
            else
            {
                Debug.Log(" did not hit.");
            }
        }
    }

    
    public GameObject GetCurrentSelection()
    {
        return currentSelection;
    }
}
