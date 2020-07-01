using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationPanel : MonoBehaviour
{
    [SerializeField] private float activeTime = 2;
    [SerializeField] private float fadeTime = 0.5f;
    private float activeTimer;
    private float fadeTimer;
    [SerializeField] private Image image = null;
    [SerializeField] private Text text = null;
    private Color solidColor = new Color(1, 1, 1, 1);
    private Color clearColor = new Color(1, 1, 1, 0);
    private void OnEnable()
    {
        image.color = solidColor;
        text.color = solidColor;
        activeTimer = activeTime;
        fadeTimer = fadeTime;
    }

    private void Update()
    {
        if (activeTimer >= 0)
        {
            activeTimer -= Time.deltaTime;
        }
        else
        {
            fadeTimer -= Time.deltaTime;
            float t = fadeTimer / fadeTime;

            image.color = Color.Lerp(solidColor, clearColor, 1-t);
            text.color = Color.Lerp(solidColor, clearColor, 1-t);
        }

        if (fadeTimer <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
