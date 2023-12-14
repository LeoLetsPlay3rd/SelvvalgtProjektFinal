using UnityEngine;
using UnityEngine.UI;

public class DualCanvasFader : MonoBehaviour
{
    public CanvasGroup canvas1Group;
    public CanvasGroup canvas2Group;
    public float fadeSpeed = 2.0f;
    public float proximityDistance = 5.0f;

    private Transform player;
    private bool hasFadedInCanvas1 = false;
    private bool hasInteracted = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (canvas1Group == null)
        {
            canvas1Group = transform.Find("Canvas1").GetComponent<CanvasGroup>();
        }

        if (canvas2Group == null)
        {
            canvas2Group = transform.Find("Canvas2").GetComponent<CanvasGroup>();
        }

        // Initially set alpha to 0 (completely transparent) for both canvases
        canvas1Group.alpha = 0f;
        canvas2Group.alpha = 0f;
    }

    private void Update()
    {
        if (player == null)
            return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < proximityDistance)
        {
            if (!hasFadedInCanvas1)
            {
                // Automatically fade in Canvas 1 when the player is in proximity
                StartCoroutine(FadeCanvas(canvas1Group, 1f));
                hasFadedInCanvas1 = true;
            }

            if (Input.GetKeyDown(KeyCode.F) && !hasInteracted)
            {
                // Toggle between Canvas 1 and Canvas 2 when F is pressed
                StartCoroutine(FadeCanvas(canvas1Group, 0f));
                StartCoroutine(FadeCanvas(canvas2Group, 1f));
                hasInteracted = true;
            }

            if (Input.GetKeyDown(KeyCode.C) && IsCanvas2Active())
            {
                // Close Canvas 2 when C is pressed
                StartCoroutine(FadeCanvas(canvas2Group, 0f));
                hasInteracted = true;
            }
        }
        else
        {
            // If player is not in proximity, reset the state
            hasFadedInCanvas1 = false;
            hasInteracted = false;

            // Fade out both canvases
            StartCoroutine(FadeCanvas(canvas1Group, 0f));
            StartCoroutine(FadeCanvas(canvas2Group, 0f));
        }
    }

    public bool IsCanvas2Active()
    {
        return canvas2Group.alpha > 0f;
    }

    private System.Collections.IEnumerator FadeCanvas(CanvasGroup canvasGroup, float targetAlpha)
    {
        float startAlpha = canvasGroup.alpha;
        float elapsedTime = 0f;

        while (elapsedTime < fadeSpeed)
        {
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = targetAlpha;
    }
}
