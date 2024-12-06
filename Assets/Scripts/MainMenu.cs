using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void StartButton()
    {
        PhaseManager.instance.NextPhase();
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
