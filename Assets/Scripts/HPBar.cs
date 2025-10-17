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
    private void ChangeHPBar(int currentHP)
    {
        Bar.fillAmount = currentHP / 100f;
    }

    private void OnDisable()
    {
        Player.OnDamage -= ChangeHPBar;
    }
}
