using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public Image BGimage, TSimage;
    public Vector2 InputDirection { set; get; }
    public float Horizontal { get; internal set; }
    public float Vertical { get; internal set; }

    private void Start()
    {
        InputDirection = Vector2.zero;
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos = Vector2.zero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle( BGimage.rectTransform, ped.position, ped.pressEventCamera, out pos)) // ce je kliknjen thumbstick
        {
            pos.x = (pos.x / BGimage.rectTransform.sizeDelta.x);
            pos.y = (pos.y / BGimage.rectTransform.sizeDelta.y);

            // nastavimo pivot(sredisce) thumbsticka na sredino
            float x = 0;
            float y = 0;

            if (BGimage.rectTransform.pivot.x == 1) //thumbstick desno
            {
                x = pos.x * 2 + 1;
            }
            else //thumbstick levo
            {
                x = pos.x * 2 - 1;
            }

            if (BGimage.rectTransform.pivot.y == 1) //thumbstick gor
            {
                y = pos.y * 2 + 1;
            }
            else //thumbstick dol
            {
                y = pos.y * 2 - 1;
            }

            InputDirection = new Vector2(x, y); 

            if (InputDirection.magnitude > 1) //tudi ce potegnes bolj dalec
            {
                InputDirection = InputDirection.normalized;
            }
            else
            {
                InputDirection = InputDirection;
            }

            //premikanje manjsega kroga v thumbsticku ... deljeno z 3, da ne gre predalec ven
            TSimage.rectTransform.anchoredPosition = new Vector2(InputDirection.x * (BGimage.rectTransform.sizeDelta.x / 3), InputDirection.y * (BGimage.rectTransform.sizeDelta.y / 3));
        }
    }
    public virtual void OnPointerDown(PointerEventData ped) // ko premikaš thumbstick
    {
        OnDrag(ped);
    }
    public virtual void OnPointerUp(PointerEventData ped) // ko spustis thumbstick gre na sredino
    {
        InputDirection = Vector2.zero;
        TSimage.rectTransform.anchoredPosition = Vector2.zero;
    }
}
