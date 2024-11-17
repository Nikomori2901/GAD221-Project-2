using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtProgressBar : MonoBehaviour
{
    public int MaxProgress;
    public int MinProgress;
    public int CurrentProgress;
    public GeneralSlider GeneralSlider;
    public GameObject ProgressBar;
    public GameObject TextInstruction;
    public GameObject TextVictory;
    public GameObject ArtImage;

    // Start is called before the first frame update
    void Start()
    {
        MaxProgress = 20;
        MinProgress = 0;
        CurrentProgress = MinProgress;
        GeneralSlider.SetMinProgress(MinProgress);
        TextVictory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            IncreaseProgress(2);
            Debug.Log(CurrentProgress);
        }

        //if (CurrentProgress == MaxProgress)
        //{
        //    TextInstruction.SetActive(false);
        //    ProgressBar.SetActive(false);
        //    TextVictory.SetActive(true);
        //    StartCoroutine(DeactivateVictoryScreen());
        //}
    }

    void IncreaseProgress(int progress)
    {
        CurrentProgress += progress;
        GeneralSlider.SetProgress(CurrentProgress);
        CheckVictory();
    }

    void CheckVictory()
    {
        Debug.Log(CurrentProgress + "=" + MaxProgress);
        if (CurrentProgress >= MaxProgress)
        {
            Debug.Log("Victory Success");
            Victory();
        }

        else
        {
            Debug.Log("Victory Fail");  
        }
    }

    void Victory()
    {
        MinigameVictory.instance.SuccessSFX();
        TextInstruction.SetActive(false);
        ProgressBar.SetActive(false);
        TextVictory.SetActive(true);
        StartCoroutine(DeactivateVictoryScreen());
    }

    IEnumerator DeactivateVictoryScreen()
    {
        yield return new WaitForSeconds(2);
        ArtImage.SetActive(false);
    }
}
