using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveBurnFlashingBarUI : MonoBehaviour
{
    private const string IS_FLASHING = "IsFlashing";
    [SerializeField] private StoveCounter stoveCounter;

    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        stoveCounter.OnProgressChange += StoveCounter_OnProgressChange;
        animator.SetBool(IS_FLASHING, false);
    }

    private void StoveCounter_OnProgressChange(object sender, IHasProgress.OnProgressChangeEventArgs e)
    {
        float burnShowProgressAmount = .5f;
        bool canFlash = stoveCounter.IsFried() && e.progressNormalized >= burnShowProgressAmount;
        animator.SetBool(IS_FLASHING, canFlash);
    }

    private void OnDestroy()
    {
        stoveCounter.OnProgressChange -= StoveCounter_OnProgressChange;
    }
}
