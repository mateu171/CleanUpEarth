using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    private Image Bar;

    private void Start()
    {
        Bar = GetComponent<Image>();
        Player.OnDamage += ChangeHPBar;
    }
    private void ChangeHPBar(float currentHP,float maxHP)
    {
        Bar.fillAmount = (float)(currentHP / maxHP);
    }

    private void OnDisable()
    {
        Player.OnDamage -= ChangeHPBar;
    }
}
