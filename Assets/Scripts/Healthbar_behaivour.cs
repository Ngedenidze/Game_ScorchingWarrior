
using UnityEngine;
using UnityEngine.UIElements;

public class Healthbar_behaivour : MonoBehaviour
{
    public Slider Slider1;
    public Color Low;
    public Color High;
    public Vector3 Offset;
    public RectTransform newFillRect;

    public void SetHealth(float health, float maxHealth)
    {


        Slider1.SetEnabled(health < maxHealth);
        Slider1.value = health;
        Slider1.highValue= maxHealth;
               // Slider1.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, Slider1.);
    }
  
    void Update()
    {

        Slider1.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);

    }
}
