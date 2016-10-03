using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchScreenMove : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public Image joystick;
    public bool onMove;

    void Start()
    {
        onMove = false;
    }

    public void OnPointerDown(PointerEventData ped)
    {
        // Debug.Log(ped.position);
        if (onMove == false)
        {
            onMove = true;
            joystick.transform.position = ped.position - new Vector2 (150, 150);
        }
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        onMove = false;
        joystick.transform.position = new Vector2(0, 0);
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        //OnPointerDown(ped);

        // Update is called once per frame
        /*void Update () {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit, 10.0f)){
                    transform.GetChild(0).transform.position = hit.transform.position;
                    Debug.Log(transform.GetChild(0).transform.position);
                    Debug.Log(hit.transform.position);
                }
            }

        }*/
    }
}