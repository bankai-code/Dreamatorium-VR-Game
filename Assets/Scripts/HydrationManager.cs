using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;


public class HydrationManager : MonoBehaviour
{
    public int maxHydration = 100;
    public float decreaseInterval = 10f;
    public float damageAmount = 0.5f;
    // public TextMeshProUGUI HydrationText;
    public Slider hydrationBar;
    public TextMeshProUGUI resetPromptText; // Reference to the reset prompt text field
    public TextMeshProUGUI rechargeText; // Reference to the recharge health text field

    private float timeSinceLastDecrease;
    private int currentHydration;
    private Coroutine rechargeCoroutine;

    private Color originalColor;

    public AudioClip liquidSlurpSound; // The audio clip to be played
    private AudioSource audioSource;

    void Start()
    {
        currentHydration = maxHydration;
        UpdateHydrationText();
        StartCoroutine(DecreaseHealthOverTime());

        originalColor = hydrationBar.fillRect.GetComponent<Image>().color;

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
        currentHydration -= Mathf.RoundToInt(damage);
        UpdateHydrationText();

        if (currentHydration <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Your death logic goes here
        // Debug.Log("Player died");
        rechargeCoroutine = StartCoroutine(ShowRechargeMessage());
    }

    IEnumerator ShowRechargeMessage()
    {
        while (currentHydration <= 0)
        {
            rechargeText.text = "Recharge Hydration. Drink Something!!!";
            yield return null;
        }
        rechargeText.text = "";
    }
    void UpdateHydrationText()
    {
        // HydrationText.text = currentHydration.ToString();
        hydrationBar.value = currentHydration;

        if(currentHydration <= 25f)
        {
            ChangeFillColor(Color.red);
        }
    }
    public void ResetHealth()
    {
        currentHydration = maxHydration;
        ChangeFillColor(originalColor);
        UpdateHydrationText();
        StartCoroutine(ShowResetPrompt());

        audioSource.clip = liquidSlurpSound;
        audioSource.Play();

    }
        IEnumerator ShowResetPrompt()
    {
        resetPromptText.text = "Hydration Reset!";
        yield return new WaitForSeconds(2f);
        resetPromptText.text = ""; // Clear the reset prompt text after 2 seconds
    }

    void ChangeFillColor(Color color)
    {
        // Get the fill image of the slider
        Image fillImage = hydrationBar.fillRect.GetComponent<Image>();

        // Set the color of the fill image
        fillImage.color = color;
    }
}
