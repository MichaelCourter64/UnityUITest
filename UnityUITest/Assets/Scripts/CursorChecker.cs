using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Checks for a mouse button 0 click to find all the UI GameObjects under the cursor at that moment.
/// </summary>
public class CursorChecker : MonoBehaviour
{
    [Tooltip("Usually found in a Canvas GameObject")]
    [SerializeField] private GraphicRaycaster graphicRaycaster;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            FindUiUnderMouseCursorAndLog();
        }
    }

    private void FindUiUnderMouseCursorAndLog()
    {
        List<RaycastResult> uiRaycastResults = FindUiElementsUnderPointer(Input.mousePosition, graphicRaycaster);

        string uiRaycastResultsLog = RaycastGameObjectResultsToLogString(uiRaycastResults);

        Debug.Log(uiRaycastResultsLog);
    }

    private List<RaycastResult> FindUiElementsUnderPointer(Vector3 pointerPosition, GraphicRaycaster graphicRaycaster)
    {
        PointerEventData currentCursorEvent = new PointerEventData(null)
        {
            position = pointerPosition
        };

        List<RaycastResult> uiRaycastResults = new List<RaycastResult>();

        graphicRaycaster.Raycast(currentCursorEvent, uiRaycastResults);

        return uiRaycastResults;
    }

    private string RaycastGameObjectResultsToLogString(List<RaycastResult> raycastResults)
    {
        string raycastGameObjectsAsLog = "Found GameObjects: ";

        foreach (RaycastResult result in raycastResults)
        {
            raycastGameObjectsAsLog += string.Format("{0} / ", result.gameObject.name);
        }

        return raycastGameObjectsAsLog;
    }
}
