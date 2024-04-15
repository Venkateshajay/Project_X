using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ButtonEffect2 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler 
{
    public float hoverScale = 1.2f;
    public float hoverTime = 0.2f;
    public float clickScale = 0.9f;
    public float clickTime = 0.1f;

    public Image blackImage;
    //public Image lightenedImage;
    public TextMeshProUGUI text;

    [Header("Colors")]
    public Color32 blackImageColor = new Color32(255, 255, 255, 255);
    //public Color32 lightenedImageColor = new Color32(255, 255, 255, 200);
    public Color32 textColor = Color.black;

    private Vector3 startScale;
    private Color32 originalBlackColor;
    private Color32 originalLightenedColor;
    private Color32 originalTextColor;

    private void Start()
    {
        startScale = transform.localScale;
        originalBlackColor = blackImage.color;
        //originalLightenedColor = lightenedImage.color;
        originalTextColor = text.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        LeanTween.cancel(gameObject);
        LeanTween.scale(gameObject, startScale * hoverScale, hoverTime);
        blackImage.color = blackImageColor;
        //lightenedImage.color = lightenedImageColor;
        text.color = textColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        LeanTween.cancel(gameObject);
        LeanTween.scale(gameObject, startScale, hoverTime);
        blackImage.color = originalBlackColor;
        //lightenedImage.color = originalLightenedColor;
        text.color = originalTextColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        LeanTween.cancel(gameObject);
        LeanTween.scale(gameObject, startScale * hoverScale * clickScale, clickTime).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(gameObject, startScale * hoverScale, clickTime).setEase(LeanTweenType.easeInOutSine).setDelay(clickTime);
        LeanTween.cancel(gameObject);
        LeanTween.scale(gameObject, startScale, 0f);
        blackImage.color = originalBlackColor;
        //lightenedImage.color = originalLightenedColor;
        text.color = originalTextColor;
    }

}
