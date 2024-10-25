using System;
using UnityEngine;
using UnityEngine.UI;

public class InitialCanvas : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [Space]
    [SerializeField] private Button objectiveBtn;
    [SerializeField] private Button vrModuleBtn;
    [SerializeField] private Button exitObjectiveBtn;
    [Space]
    [SerializeField] private GameObject mainCanvas;
    [SerializeField] private GameObject objectiveCanvas;
    [SerializeField] private GameObject vrCanvas;
    [SerializeField] private StepManager stepManager;


    private void OnEnable()
    {
        objectiveBtn.onClick.AddListener(ShowObjective);
        vrModuleBtn.onClick.AddListener(ShowVRModule);
        exitObjectiveBtn.onClick.AddListener(HideObjective);
    }

    private void OnDisable()
    {
        objectiveBtn.onClick.RemoveListener(ShowObjective);
        vrModuleBtn.onClick.RemoveListener(ShowVRModule);
        exitObjectiveBtn.onClick.RemoveListener(HideObjective);
    }

    private void Start()
    {
        HideObjective();
    }

    private void ShowObjective()
    {
        mainCanvas.SetActive(false);
        objectiveCanvas.SetActive(true);
    }

    private void ShowVRModule()
    {
        canvas.SetActive(false);
        vrCanvas.SetActive(true);
        stepManager.ShowFirstStep();
    }

    private void HideObjective()
    {
        objectiveCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }

}
