using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundProgressBar : MonoBehaviour
{
    public int MaxProgress = 20;
    public int MinProgress = 0;
    public int CurrentProgress;
    public GeneralSlider GeneralSlider;
    public GameObject ProgressBar;
    public GameObject TextInstruction;
    public GameObject TextVictory;
    public GameObject SoundImage;
    // Start is called before the first frame update
    void Start()
    {
        CurrentProgress = MinProgress;
        GeneralSlider.SetMinProgress(MinProgress);
        TextVictory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1))
        {
            IncreaseProgress(2);

        }
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
        MinigameVictory.SuccessSFX();
        TextInstruction.SetActive(false);
        ProgressBar.SetActive(false);
        TextVictory.SetActive(true);
        StartCoroutine(DeactivateVictoryScreen());
        
    }

    void IncreaseProgress(int progress)
    {
        CurrentProgress += progress;
        GeneralSlider.SetProgress(CurrentProgress);
        CheckVictory();
    }

    IEnumerator DeactivateVictoryScreen()
    {
        yield return new WaitForSeconds(2);
        SoundImage.SetActive(false);
        gameObject.SetActive(false);
    }
}
