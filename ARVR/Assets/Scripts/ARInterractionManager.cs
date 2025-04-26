using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARInterractionManager : MonoBehaviour
{
    [SerializeField] private Camera aRCamera;
    private ARRaycastManager aRRaycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private GameObject aRPointer;
    private GameObject item3DModel;
    private bool isInitialPosition;
    private bool isOverUI;

    public GameObject Item3DModel
    {
        set
        {
            GameManager.instance.DebugConsoleMessage("Se asigna el modelo 3D");
            item3DModel = value;
            item3DModel.transform.position = aRPointer.transform.position;
            item3DModel.transform.parent = aRPointer.transform;
            isInitialPosition = true;
        }
    }

    void Start()
    {
        aRPointer = transform.GetChild(0).gameObject;
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
        GameManager.instance.onMainMenu += SetItemPosition;
    }

    void Update()
    {
        if (isInitialPosition)
        {
            GameManager.instance.DebugConsoleMessage("Se inisializza la pocicion");
            Vector2 _middlePointScreent = new Vector2(Screen.width / 2, Screen.height / 2);
            aRRaycastManager.Raycast(_middlePointScreent, hits, TrackableType.Planes);

            if (hits.Count > 0)
            {
                GameManager.instance.DebugConsoleMessage("Se encuentra la superficie");
                transform.position = hits[0].pose.position;
                aRPointer.SetActive(true);
                isInitialPosition = false;
            }
        }

        if(Input.touchCount > 0)
        {
            Touch touchOne = Input.GetTouch(0);

            if(touchOne.phase == TouchPhase.Began)
            {
                var touchPosition = touchOne.position;
                isOverUI = IsTapOverUI(touchPosition);
            }


            if (touchOne.phase == TouchPhase.Moved)
            {
                if (aRRaycastManager.Raycast(touchOne.position, hits, TrackableType.Planes))
                {
                    Pose hitPose = hits[0].pose;
                    if (!isOverUI)
                    {
                        transform.position = hitPose.position;
                    }
                }

            }
        }
    }

    private bool IsTapOverUI(Vector2 touchPosition)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(touchPosition.x, touchPosition.y);

        List<RaycastResult> result = new List<RaycastResult>();

        EventSystem.current.RaycastAll(eventData, result);
        return result.Count > 0;
    }

    public void SetItemPosition()
    {
        if (item3DModel != null)
        {
            item3DModel.transform.parent = null;
            aRPointer.SetActive(false);
            item3DModel = null;
        }
    }

    public void DeleteItem()
    {
        Destroy(item3DModel);
        aRPointer.SetActive(false);
        GameManager.instance.MainMenu();
    }
}
