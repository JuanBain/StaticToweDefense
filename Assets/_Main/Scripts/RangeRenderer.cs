using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangeRenderer : MonoBehaviour
{
    public LineRenderer CircleRenderer;

    // Start is called before the first frame update
    void Start()
    {
        DrawCircle(40, 1.5f);
    }


    void DrawCircle(int steps, float radius)
    {
        CircleRenderer.positionCount = steps+1;
        for (int currentStep = 0; currentStep <= steps - 1; currentStep++)
        {
            float circumferenceProgress = (float)currentStep / steps;
            float currentRadian = circumferenceProgress * 2 * Mathf.PI;
            float xScaled = Mathf.Cos(currentRadian);
            float yScaled = Mathf.Sin(currentRadian);
            float x = xScaled * radius;
            float y = yScaled * radius;
            Vector3 currentPosition = new Vector3(x, y, 0);
            CircleRenderer.SetPosition(currentStep, currentPosition);
        }

        CircleRenderer.SetPosition(steps, new Vector3(1.5f, 0, 0));
    }
}