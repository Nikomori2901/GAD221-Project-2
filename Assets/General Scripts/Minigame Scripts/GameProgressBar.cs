using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameProgressBar : MonoBehaviour
{
    public int MaxProgress = 20;
    public int MinProgress = 0;
    public int CurrentProgress;
    public GeneralSlider GeneralSlider;
    public GameObject ProgressBar;
    public GameObject TextInstruction;
    public GameObject TextVictory;
    public GameObject GameImage;
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
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            IncreaseProgress(2);

        }

        if (CurrentProgress == MaxProgress)
        {
            MinigameVictory.instance.SuccessSFX();
            TextInstruction.SetActive(false);
            ProgressBar.SetActive(false);
            TextVictory.SetActive(true);
            StartCoroutine(DeactivateVictoryScreen());
        }
    }

    void IncreaseProgress(int progress)
    {
        CurrentProgress += progress;
        GeneralSlider.SetProgress(CurrentProgress);
    }

    IEnumerator DeactivateVictoryScreen()
    {
        yield return new WaitForSeconds(2);
        GameImage.SetActive(false);
    }
}
