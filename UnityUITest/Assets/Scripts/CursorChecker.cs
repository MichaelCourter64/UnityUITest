using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Checks for a mouse button 0 click to find all the UI GameObjects under the cursor at that moment.
/// </summary>
public class CursorChecker : MonoBehaviour
{
    [SerializeField] private GraphicRaycaster graphicRaycaster;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PointerEventData currentCursorEvent = new PointerEventData(null);
            currentCursorEvent.position = Input.mousePosition;

            List<RaycastResult> raycastResults = new List<RaycastResult>();

            string raycastsAsLog = "Found GameObjects: ";

            graphicRaycaster.Raycast(currentCursorEvent, raycastResults);

            foreach (RaycastResult result in raycastResults)
            {
                raycastsAsLog += string.Format("{0} / ", result.gameObject.name);
            }

            Debug.Log(raycastsAsLog);
        }
    }
}
