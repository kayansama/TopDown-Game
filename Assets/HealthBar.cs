using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image FillImage;
    public Text PercentageText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hp = GameManager.Instance.health.hp;
        FillImage.fillAmount = hp / 100f;
        PercentageText.text = Mathf.RoundToInt(hp) + "%";
    }


}
