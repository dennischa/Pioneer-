using UnityEngine;
using UnityEngine.UI;

public class JoyTouche : MonoBehaviour
{
    public bool GetTouche;
    public Image joy;

    void Start()
    {
        GetTouche = false;
    }
    public void TouchDown()
    {
        GetTouche = true;
        Debug.Log(GetTouche);
    }
    public void TouchUp()
    {
        GetTouche = false;
        
        Debug.Log(GetTouche);
    }
}