using UnityEngine;
using TMPro;
using System.Collections;

public class movetextbox : MonoBehaviour
{
    public TMP_Text textMeshPro;  // Assign in Inspector
    public float moveDistance = 200f;  // Distance to move up
    public float moveDuration = 2f;    // Time in seconds to complete the movement
    public float delayTime = 0f;

    private RectTransform rectTransform;
    private bool isMoving = false;  // To prevent multiple coroutine calls

    void Start()
    {
        if (textMeshPro == null)
        {
            textMeshPro = GetComponent<TMP_Text>();
        }

        rectTransform = textMeshPro.GetComponent<RectTransform>();

        if (rectTransform == null)
        {
            Debug.LogError("RectTransform not found on the text object.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isMoving)
        {
            StartCoroutine(MoveTextUp());
        }
    }

    IEnumerator MoveTextUp()
    {
        isMoving = true;  // Prevent multiple moves


        yield return new WaitForSeconds(delayTime);  // Wait before starting movement

        Vector2 startPosition = rectTransform.anchoredPosition;
        Vector2 targetPosition = startPosition + new Vector2(0, moveDistance);

        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;  // Wait for the next frame
        }

        rectTransform.anchoredPosition = targetPosition;  // reaches the target position
        isMoving = false;  // Allow new movement
    }
}


