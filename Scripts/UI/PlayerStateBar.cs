using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateBar : MonoBehaviour
{
    public Image HealthImage;
    public Image DeleteImage;
    private void Update()
    {
        if (DeleteImage.fillAmount > HealthImage.fillAmount)
        {
            DeleteImage.fillAmount -= Time.deltaTime;
        }
    }
    public void OnHealthChange(float persentage)
    {
        HealthImage.fillAmount = persentage;

    }
}

