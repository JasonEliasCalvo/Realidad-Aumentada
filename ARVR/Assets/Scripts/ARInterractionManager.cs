using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public GameObject Item3DModel
    {
        set
        {
            GameManager.instance.DebugConsoleMessage("Se asigna el modelo 3D");
            item3DModel = value;
            item3DModel.transform.position = aRPointer.transform.position;
            item3DModel.transform.rotation = aRPointer.transform.rotation;
            isInitialPosition = true;
        }
    }

    void Start()
    {
        aRPointer = transform.GetChild(0).gameObject;
        aRRaycastManager = GameObject.FindObjectOfType<ARRaycastManager>();
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
                transform.position = aRPointer.transform.position;

                aRPointer.SetActive(true);
            }
        }
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
}
