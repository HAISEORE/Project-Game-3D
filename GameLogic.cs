using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Import the SceneManager

public class GameLogic : MonoBehaviour
{
    public GameObject counter;
    public GameObject slenderMan; // Reference to the Slender Man GameObject
    public int pageCountToSpawnSlenderMan = 2; // Number of pages required to spawn Slender Man

    private int pageCount;
    private SlenderManAI slenderManAI;

    void Start()
    {
        pageCount = 0;
        counter.GetComponent<Text>().text = pageCount + "/8";

        slenderManAI = slenderMan.GetComponent<SlenderManAI>();
        slenderManAI.chaseProbability = 0f;
    }

    void Update()
    {
        counter.GetComponent<Text>().text = pageCount + "/8";

        // Check if the pageCount reaches the threshold to spawn Slender Man
        if (pageCount >= pageCountToSpawnSlenderMan)
        {
            slenderManAI.chaseProbability = 0.7f;
            // slenderMan.SetActive(true); // Activate Slender Man
        }

        // Check if the pageCount reaches 8 to end the game and load the Survive scene
        if (pageCount >= 8)
        {
            SceneManager.LoadScene("Survive");
        }
    }

    public void IncrementPageCount()
    {
        pageCount++;
    }
}
