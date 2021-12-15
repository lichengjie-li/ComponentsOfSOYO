using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public delegate void PointrDown(Vector2 pos);
public delegate void PointrUp();
public delegate void DragStick(Vector2 pos);

/// <summary>
/// 虚拟摇杆移动方式，主要用于Canvas布局
/// </summary>
public class VirtualJoystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public event PointrDown OnTouchDown;
    public event PointrUp OnTouchUp;
    public event DragStick OnDraging;

    /// <summary>
    /// 摇杆半径
    /// </summary>
    private float radius
    {
        get
        {
            return (stickImg.rectTransform.rect.size.x - dragImg.rectTransform.rect.size.x) / 2;
        }
    }
    /// <summary>
    /// 摇杆底图
    /// </summary>
    [SerializeField]
    Image stickImg;
    /// <summary>
    /// 摇杆拖拽点
    /// </summary>
    [SerializeField]
    Image dragImg;

    /// <summary>
    /// 摇杆原点
    /// </summary>
    Vector2 stickOrigin;

    /// <summary>
    /// 画布
    /// </summary>
    [SerializeField]
    Canvas controlCanvas;

    /// <summary>
    /// 摇杆所在画布
    /// </summary>
    RectTransform parentCanvas;

    /// <summary>
    /// 摇杆的默认位置
    /// </summary>
    private Vector2 Sticktemporary
    {
        get
        {
            if (Screen.width > Screen.height)
                return new Vector2(0, stickImg.rectTransform.rect.size.y / 1.5f);
            else
                return new Vector2(0, stickImg.rectTransform.rect.size.y * 0.6f);
        }
    }


    /// <summary>
    /// 摇杆的大小
    /// </summary>
    private Vector2 JoyStickScale(int i)
    {
        if (Screen.width > Screen.height)
            return new Vector2(parentCanvas.sizeDelta.y / (4 * i), parentCanvas.sizeDelta.y / (4 * i));
        else
            return new Vector2(parentCanvas.sizeDelta.x / (3 * i), parentCanvas.sizeDelta.x / (3 * i));
    }

    /// <summary>
    /// 用于存放当摇杆移动到边界后维持持续移动的向量
    /// </summary>
    private Vector2 vector;

    /// <summary>
    /// 是否触碰摇杆
    /// </summary>
    bool isDrag = true;
    /// <summary>
    /// 是否拖拽摇杆
    /// </summary>
    bool drag = false;

    void Start()
    {
        parentCanvas = controlCanvas.GetComponent<RectTransform>();

    }

    void Update()
    {
        stickImg.rectTransform.sizeDelta = JoyStickScale(1);
        dragImg.rectTransform.sizeDelta = JoyStickScale(2);
        radius = (stickImg.rectTransform.rect.size.x - dragImg.rectTransform.rect.size.x) / 2;
        stickImg.transform.localPosition = Sticktemporary;
        stickOrigin = RectTransformUtility.WorldToScreenPoint(controlCanvas.GetComponent<Camera>(), stickImg.transform.position);
        if (!isDrag)
        {
            OnDraging(vector);
        }
    }

    /// <summary>
    /// 停止移动
    /// </summary>
    public void StopMove()
    {
        if (OnTouchUp != null)
        {
            OnTouchUp();
        }
    }

    /// <summary>
    /// 游戏结束 不允许移动
    /// </summary>
    public void End()
    {
        isDrag = true;
        vector = Vector2.zero;
        dragImg.rectTransform.anchoredPosition = Vector2.zero;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDrag = true;
        drag = false;
        vector = Vector2.zero;
        dragImg.rectTransform.anchoredPosition = Vector2.zero;
        if (OnTouchUp != null)
        {
            OnTouchUp();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDrag = false;

        if (!drag)
        {
            Vector2 pointer = eventData.position;
            Vector2 localPosMoreRadius = pointer - stickOrigin;
            Vector2 localPos = Vector2.ClampMagnitude(localPosMoreRadius, radius);
            dragImg.rectTransform.anchoredPosition = localPos;
            vector = localPos.normalized;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDrag)  // 当在可以拖动摇杆的区域，并且执行了按下方法后，才可以拖动
        {
            drag = true;
            Vector2 pointer = eventData.position;
            Vector2 localPosMoreRadius = pointer - stickOrigin;
            Vector2 localPos = Vector2.ClampMagnitude(localPosMoreRadius, radius);
            dragImg.rectTransform.anchoredPosition = localPos;
            vector = localPos.normalized;
        }
    }

}
