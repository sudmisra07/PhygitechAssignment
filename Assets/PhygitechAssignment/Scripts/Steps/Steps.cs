using System;
using UnityEngine;

public class Steps : MonoBehaviour
{
    public int stepIndex;
    [SerializeField] private GameObject stepObject;

    private void OnEnable()
    {
        StepManager.OnShowStep += ShowStep;
    }

    private void OnDisable()
    {
        StepManager.OnShowStep -= ShowStep;
    }

    private void ShowStep(int index)
    {
        if(index == stepIndex)
            stepObject.SetActive(true);
        else
            stepObject.SetActive(false);
    }
}
