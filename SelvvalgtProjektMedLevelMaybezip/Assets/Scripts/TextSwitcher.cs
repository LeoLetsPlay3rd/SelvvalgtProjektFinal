using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextSwitcher : MonoBehaviour
{
    public TMP_Text text1;
    public TMP_Text text2;
    public Image imageB;
    public TMP_Text textB;
    public Image imageN;
    public TMP_Text textN;
    public float switchDelay = 0.5f; // Time delay between text switches

    private float lastSwitchTime;

    private void Start()
    {
        lastSwitchTime = Time.time;
        ShowText1();
    }

    private void Update()
    {
        // Check for "n" key press
        if (Input.GetKeyDown(KeyCode.N))
        {
            // Ensure a delay between switches
            if (Time.time - lastSwitchTime >= switchDelay)
            {
                // Toggle between Text 1 and Text 2
                if (text1.gameObject.activeSelf)
                {
                    ShowText2();
                }
                else
                {
                    ShowText1();
                }

                lastSwitchTime = Time.time;
            }
        }

        // Check for "b" key press
        if (Input.GetKeyDown(KeyCode.B))
        {
            // Ensure a delay between switches
            if (Time.time - lastSwitchTime >= switchDelay)
            {
                // Toggle between Text 1 and Text 2
                if (text1.gameObject.activeSelf)
                {
                    ShowText2();
                }
                else
                {
                    ShowText1();
                }

                lastSwitchTime = Time.time;
            }
        }
    }

    private void ShowText1()
    {
        text1.gameObject.SetActive(true);
        text2.gameObject.SetActive(false);

        // Set opacity for imageB and textB when Text 1 is shown
        SetOpacity(imageB, 0.2f);
        SetOpacity(textB, 0.2f);

        // Set opacity for imageN and textN when Text 1 is shown
        SetOpacity(imageN, 1f);
        SetOpacity(textN, 1f);
    }

    private void ShowText2()
    {
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(true);

        // Set opacity for imageB and textB when Text 2 is shown
        SetOpacity(imageB, 1f);
        SetOpacity(textB, 1f);

        // Set opacity for imageN and textN when Text 2 is shown
        SetOpacity(imageN, 0.2f);
        SetOpacity(textN, 0.2f);
    }

    private void SetOpacity(Graphic graphic, float opacity)
    {
        Color color = graphic.color;
        color.a = opacity;
        graphic.color = color;
    }

    private void SetOpacity(TMP_Text text, float opacity)
    {
        Color color = text.color;
        color.a = opacity;
        text.color = color;
    }
}
