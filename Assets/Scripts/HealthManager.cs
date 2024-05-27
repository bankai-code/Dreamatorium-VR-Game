using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public float decreaseInterval = 5f;
    public float damageAmount = 0.5f;
    // public TextMeshProUGUI healthText;
    public Slider healthBar;
    public TextMeshProUGUI resetPromptText; // Reference to the reset prompt text field
    public TextMeshProUGUI rechargeText; // Reference to the recharge health text field

    private float timeSinceLastDecrease;
    private int currentHealth;
    private Coroutine rechargeCoroutine;

    private Color originalColor;

    public AudioClip eatingSound; // The audio clip to be played
    private AudioSource audioSource;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
        StartCoroutine(DecreaseHealthOverTime());

        originalColor = healthBar.fillRect.GetComponent<Image>().color;

        audioSource = GetComponent<AudioSource>();
    }

    IEnumerator DecreaseHealthOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(decreaseInterval);
            TakeDamage(damageAmount);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= Mathf.RoundToInt(damage);
        UpdateHealthText();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Your death logic goes here
        Debug.Log("Player died");
        rechargeCoroutine = StartCoroutine(ShowRechargeMessage());
    }

    IEnumerator ShowRechargeMessage()
    {
        while (currentHealth <= 0)
        {
            rechargeText.text = "Recharge Health";
            yield return null;
        }
        rechargeText.text = "";
    }

    void UpdateHealthText()
    {
        // healthText.text = currentHealth.ToString();
        healthBar.value = currentHealth;

        if(currentHealth <= 25f)
        {
            ChangeFillColor(Color.red);
        }
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
        ChangeFillColor(originalColor);
        UpdateHealthText();
        StartCoroutine(ShowResetPrompt());

        audioSource.clip = eatingSound;
        audioSource.Play();
    }

    IEnumerator ShowResetPrompt()
    {
        resetPromptText.text = "Stamina Reset!";
        yield return new WaitForSeconds(2f);
        resetPromptText.text = ""; // Clear the reset prompt text after 2 seconds
    }
    
    void ChangeFillColor(Color color)
    {
        // Get the fill image of the slider
        Image fillImage = healthBar.fillRect.GetComponent<Image>();

        // Set the color of the fill image
        fillImage.color = color;
    }
}
