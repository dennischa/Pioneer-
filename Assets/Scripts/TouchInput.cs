﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TouchInput : MonoBehaviour
{
    // Update is called once per frame
    public LayerMask touchInputMask;

    private List<GameObject> touchList = new List<GameObject>();
    private GameObject[] touchesOld;
    public bool onMove;
    RaycastHit hit;
    public Vector2 pos;

    public Image joy;

    public JoyTouche jt;

    void Start()
    {
        pos = new Vector2(0, 0);
        onMove = false;
    }

    void Update()
    {

#if UNITY_EDITOR
       
            if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
            {
                touchesOld = new GameObject[touchList.Count];
                touchList.CopyTo(touchesOld);
                touchList.Clear();


                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (jt.GetTouche == false)
                joy.transform.position = Input.mousePosition - new Vector3(50, 50, 50);            


            }
       

#endif
        if (Input.touchCount > 0)
        {
            touchesOld = new GameObject[touchList.Count];
            touchList.CopyTo(touchesOld);
            touchList.Clear();

            foreach (Touch touch in Input.touches)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);


                if (Physics.Raycast(ray, out hit, touchInputMask))
                {
                    pos = hit.point;
                    GameObject recipient = hit.transform.gameObject;
                    touchList.Add(recipient);
                    if (touch.phase == TouchPhase.Began)
                    {
                        recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Ended)
                    {
                        recipient.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                    {
                        recipient.SendMessage("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Canceled)
                    {
                        recipient.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                }

            }

            foreach (GameObject g in touchesOld)
            {
                if (!touchList.Contains(g))
                    g.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
            }

        }
    }
}
