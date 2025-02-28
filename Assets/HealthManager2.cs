using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image _healthBar;
    public float _healthAmount = 100f; // player health amount
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    /*(public void Update()
    {
        if (_healthAmount <= 0)
        {
            Application.LoadLevel(Application.LoadLevel);// reloads scene
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            //TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Heal(5);
        }
    }

    public void TakeDamage(float damage)
    {
        _healthAmount -= damage;
        _healthBar.fillAmount = _healthAmount / 100f;
    }

    public void Heal(float _healingAmount) //public so I can call it wherever
    {
        _healthAmount += _healingAmount; // adds
        _healthAmount = Mathf.Clamp(_healthAmount, 0f, 100f); // Health cant go above or below 0 or above 100

        _healthBar.fillAmount = _healthAmount / 100f; // sets hp bar to amount healed
    }*/
}
