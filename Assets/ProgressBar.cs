using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Image FillImage;
    public Text PercentageText;
    public float TotalTime = 10f;
    private float timeRemaining;

    void Start()
    {
        timeRemaining = TotalTime;
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            float fillAmount = 1 - (timeRemaining / TotalTime);
            if (fillAmount >= 0.97f)
            {
                fillAmount = 1;
                timeRemaining = 0;
            }
            FillImage.fillAmount = fillAmount;
            PercentageText.text = Mathf.RoundToInt(fillAmount * 100) + "%";
            if (fillAmount == 1)
            {
                Debug.Log("You won!");
                GameManager.Instance.ExitOpened();
            }
        }
    }

    public void BumpProgress(float amount)
    {
        timeRemaining += amount * TotalTime;
        timeRemaining = Mathf.Clamp(timeRemaining, 0, TotalTime);
    }
}
