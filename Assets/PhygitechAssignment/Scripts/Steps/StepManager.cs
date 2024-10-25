using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
public class StepManager : MonoBehaviour
{
    [SerializeField] private Steps[] steps;
    [SerializeField] private StepInformation[] stepInfos;
    [SerializeField] private GameObject stepObjectParent;
    [SerializeField] private GameObject initialCanvas;
    [SerializeField] private GameObject vrCanvas;
    [SerializeField] private AudioSource audioSource;

    int currentStep = 0;

    [SerializeField] private Button Previous;
    [SerializeField] private Button Next;
    [SerializeField] private Button Exit;

    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text infoText;

    public static event Action<int> OnShowStep;

    private void Awake()
    {
        XRSettings.eyeTextureResolutionScale = 2f;
    }
    private void OnEnable()
    {
        Previous.onClick.AddListener(PreviousStep);
        Next.onClick.AddListener(NextStep);
        Exit.onClick.AddListener(CloseVRModule);
    }

    private void OnDisable()
    {
        Previous.onClick.RemoveListener(PreviousStep);
        Next.onClick.RemoveListener(NextStep);
        Exit.onClick.RemoveListener(CloseVRModule);
    }

    public void ShowFirstStep()
    {
        currentStep = 0;
        StartStep();
        stepObjectParent.SetActive(true);
    }

    private void PreviousStep()
    {
        currentStep = Mathf.Clamp((currentStep - 1), 0, steps.Length - 1);
        StartStep();
    }

    private void NextStep()
    {
        currentStep = Mathf.Clamp((currentStep + 1), 0, steps.Length - 1);
        StartStep();
    }

    private void StartStep()
    {
        audioSource.Stop();
        OnShowStep?.Invoke(currentStep);
        Previous.interactable = currentStep != 0;
        Next.gameObject.SetActive(currentStep != steps.Length - 1);
        Exit.gameObject.SetActive(currentStep == steps.Length - 1);
        titleText.text = stepInfos[currentStep].title;
        infoText.text = stepInfos[currentStep].info;
        audioSource.clip = stepInfos[currentStep].VO;
        audioSource.Play();
    }

    private void CloseVRModule()
    {
        stepObjectParent.SetActive(false);
        initialCanvas.SetActive(true);
        vrCanvas.SetActive(false);
        audioSource.Stop();
    }

}

[Serializable]
public struct StepInformation
{
    public string title;
    [Multiline] public string info;
    public AudioClip VO;
}