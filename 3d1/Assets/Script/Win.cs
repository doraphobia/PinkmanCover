using UnityEngine;
using UnityEngine.UI;

public class CharacterArrivalTracker : MonoBehaviour
{
    public Transform[] characters;  
    public Transform target;        // The spot they need to arrive at
    public float arrivalDistance = 1.0f;  // Distance 
    public Text progressText;       // UI Text 
    public GameObject winCanvas;   

    private int arrivedCount = 0;   // Tracks 
    private bool isWin = false;     

    void Start()
    {
        if (winCanvas == null)
        {
            Debug.LogError("s!");
        }
        else
        {
            winCanvas.SetActive(false);  // Hide
        }

        if (progressText == null)
        {
            Debug.LogError("P!");
        }

        if (target == null)
        {
            Debug.LogError("k!");
        }

        if (characters == null || characters.Length == 0)
        {
            Debug.LogError(",!");
        }
        else
        {
            foreach (Transform character in characters)
            {
                if (character == null)
                {
                    Debug.LogError(" missing.");
                }
            }
        }

        UpdateProgressUI(); 
    }

    void Update()
    {
        if (!isWin)  
        {
            CheckCharacterArrival();
        }
    }

    void CheckCharacterArrival()
    {
        arrivedCount = 0;  

        foreach (Transform character in characters)
        {
            if (character != null) 
            {
                if (Vector3.Distance(character.position, target.position) <= arrivalDistance)
                {
                    arrivedCount++;
                }
            }
        }

        UpdateProgressUI();

        // Check 
        if (arrivedCount == characters.Length && characters.Length > 0)
        {
            isWin = true;
            ShowWinMessage();
        }
    }

    void UpdateProgressUI()
    {
        if (progressText != null)
        {
            progressText.text = "Arrived: " + arrivedCount + " / " + characters.Length;
        }
        else
        {
            Debug.LogError("!");
        }
    }

    // Display the win 
    void ShowWinMessage()
    {
        if (winCanvas != null)
        {
            winCanvas.SetActive(true);
        }
        else
        {
            Debug.LogError("u!");
        }
    }
}
