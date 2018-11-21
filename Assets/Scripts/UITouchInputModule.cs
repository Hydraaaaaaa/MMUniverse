using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
//namespace UnityEngine.EventSystems
//{
[AddComponentMenu("Event/Touch Input Module")]
public class UITouchInputModule : PointerInputModule
{
    protected UITouchInputModule()
    {
    }

    private Vector2 m_LastMousePosition;
    private Vector2 m_MousePosition;

    [SerializeField]
    private bool m_AllowActivationOnStandalone;

    public bool allowActivationOnStandalone
    {
        get
        {
            return m_AllowActivationOnStandalone;
        }
        set
        {
            m_AllowActivationOnStandalone = value;
        }
    }

    public override void UpdateModule()
    {
        m_LastMousePosition = m_MousePosition;
        m_MousePosition = Input.mousePosition;
    }

    public override bool IsModuleSupported()
    {
#if UNITY_CLOUD_BUILD
                return m_AllowActivationOnStandalone || Application.isMobilePlatform;
#else
        return m_AllowActivationOnStandalone || Input.touchSupported;
#endif
    }

    public override bool ShouldActivateModule()
    {
        if (!base.ShouldActivateModule())
            return false;

        if (UseFakeInput())
        {
            bool wantsEnable = Input.GetMouseButtonDown(0);

            wantsEnable |= (m_MousePosition - m_LastMousePosition).sqrMagnitude > 0.0f;
            return wantsEnable;
        }

        for (int i = 0; i < Input.touchCount; ++i)
        {
            Touch input = Input.GetTouch(i);

            if (input.phase == TouchPhase.Began
                || input.phase == TouchPhase.Moved
                || input.phase == TouchPhase.Stationary)
                return true;
        }
        return false;
    }

    private bool UseFakeInput()
    {
#if UNITY_CLOUD_BUILD
                return !Application.isMobilePlatform;
#else
        return !Input.touchSupported;
#endif
    }

    public override void Process()
    {
        if (UseFakeInput())
            FakeTouches();
        else
            ProcessTouchEvents();
    }

    /// <summary>
    /// For debugging touch-based devices using the mouse.
    /// </summary>
    private void FakeTouches()
    {
#if UNITY_CLOUD_BUILD
                PointerInputModule.MouseButtonEventData data = this.GetMousePointerEventData()[PointerEventData.InputButton.Left];
#else
        PointerInputModule.MouseButtonEventData data = this.GetMousePointerEventData().GetButtonState(PointerEventData.InputButton.Left).eventData;
#endif
        if (data.PressedThisFrame())
        {
            data.buttonData.delta = Vector2.zero;
        }
        this.ProcessTouchPress(data.buttonData, data.PressedThisFrame(), data.ReleasedThisFrame());
        if (Input.GetMouseButton(0))
        {
            this.ProcessMove(data.buttonData);
            this.ProcessDrag(data.buttonData);
        }
    }

    /// <summary>
    /// Process all touch events.
    /// </summary>
    private void ProcessTouchEvents()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            Touch input = Input.GetTouch(i);
            if (input.fingerId != 0) continue;

            bool released;
            bool pressed;
            var pointer = GetTouchPointerEventData(input, out pressed, out released);

            ProcessTouchPress(pointer, pressed, released);

            if (!released)
            {
                ProcessMove(pointer);
                ProcessDrag(pointer);
            }
            else
            {
                RemovePointerData(pointer);
            }
        }
    }

    private void ProcessTouchPress(PointerEventData pointerEvent, bool pressed, bool released)
    {
#if UNITY_CLOUD_BUILD
            var currentOverGo = pointerEvent.pointerCurrentRaycast.go;
#else
        var currentOverGo = pointerEvent.pointerCurrentRaycast.gameObject;
#endif
        // PointerDown notification
        if (pressed)
        {
            pointerEvent.eligibleForClick = true;
            pointerEvent.delta = Vector2.zero;
            pointerEvent.dragging = false;

#if !UNITY_CLOUD_BUILD
            pointerEvent.useDragThreshold = true;
#endif
            pointerEvent.pressPosition = pointerEvent.position;
            pointerEvent.pointerPressRaycast = pointerEvent.pointerCurrentRaycast;

            if (pointerEvent.pointerEnter != currentOverGo)
            {
                // send a pointer enter to the touched element if it isn't the one to select...
                HandlePointerExitAndEnter(pointerEvent, currentOverGo);
                pointerEvent.pointerEnter = currentOverGo;
            }

            // search for the control that will receive the press
            // if we can't find a press handler set the press
            // handler to be what would receive a click.
            var newPressed = ExecuteEvents.ExecuteHierarchy<IPointerDownHandler>(currentOverGo, pointerEvent, ExecuteEvents.pointerDownHandler);

            // didnt find a press handler... search for a click handler
            if (newPressed == null)
                newPressed = ExecuteEvents.GetEventHandler<IPointerClickHandler>(currentOverGo);

            //Debug.Log("Pressed: " + newPressed);

            float unscaledTime = Time.unscaledTime;
            if (newPressed == pointerEvent.lastPress)
            {
                float duration = unscaledTime - pointerEvent.clickTime;
                if (duration < 0.3f)
                {
                    pointerEvent.clickCount++;
                }
                else
                {
                    pointerEvent.clickCount = 1;
                }
                pointerEvent.clickTime = unscaledTime;
            }
            else
            {
                pointerEvent.clickCount = 0;
            }

            pointerEvent.pointerPress = newPressed;
            pointerEvent.rawPointerPress = currentOverGo;
            pointerEvent.clickTime = unscaledTime;

            // Save the drag handler as well
            pointerEvent.pointerDrag = ExecuteEvents.GetEventHandler<IDragHandler>(currentOverGo);

#if UNITY_CLOUD_BUILD
                if (pointerEvent.pointerDrag != null)
                    ExecuteEvents.Execute<IBeginDragHandler> (pointerEvent.pointerDrag, pointerEvent, ExecuteEvents.beginDragHandler);
#else
            if (pointerEvent.pointerDrag != null)
                ExecuteEvents.Execute<IInitializePotentialDragHandler>(pointerEvent.pointerDrag, pointerEvent, ExecuteEvents.initializePotentialDrag);
#endif
            //    Debug.Log("Setting Drag Handler to: " + pointer.pointerDrag);

            // Selection tracking
            var selectHandlerGO = ExecuteEvents.GetEventHandler<ISelectHandler>(currentOverGo);
            eventSystem.SetSelectedGameObject(selectHandlerGO, pointerEvent);
        }

        // PointerUp notification
        if (released)
        {
            //Debug.Log("Executing pressup on: " + pointer.pointerPress);
            ExecuteEvents.Execute<IPointerUpHandler>(pointerEvent.pointerPress, pointerEvent, ExecuteEvents.pointerUpHandler);

            //Debug.Log("KeyCode: " + pointer.eventData.keyCode);

            // see if we mouse up on the same element that we clicked on...
            var pointerUpHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(currentOverGo);

            // PointerClick and Drop events
            if (pointerEvent.pointerPress == pointerUpHandler && pointerEvent.eligibleForClick)
            {
                ExecuteEvents.Execute<IPointerClickHandler>(pointerEvent.pointerPress, pointerEvent, ExecuteEvents.pointerClickHandler);
            }
            else if (pointerEvent.pointerDrag != null)
            {
                ExecuteEvents.ExecuteHierarchy(currentOverGo, pointerEvent, ExecuteEvents.dropHandler);
            }

            pointerEvent.eligibleForClick = false;
            pointerEvent.pointerPress = null;
            pointerEvent.rawPointerPress = null;
            pointerEvent.dragging = false;

            if (pointerEvent.pointerDrag != null)
                ExecuteEvents.Execute<IEndDragHandler>(pointerEvent.pointerDrag, pointerEvent, ExecuteEvents.endDragHandler);

            pointerEvent.pointerDrag = null;

            // send exit events as we need to simulate this on touch up on touch device
            ExecuteEvents.ExecuteHierarchy<IPointerExitHandler>(pointerEvent.pointerEnter, pointerEvent, ExecuteEvents.pointerExitHandler);
            pointerEvent.pointerEnter = null;
        }
    }

    public override void DeactivateModule()
    {
        base.DeactivateModule();
        base.ClearSelection();
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(UseFakeInput() ? "Input: Faked" : "Input: Touch");
        if (UseFakeInput())
        {
            var pointerData = base.GetLastPointerEventData(-1);
            if (pointerData != null)
                sb.AppendLine(pointerData.ToString());
        }
        else
        {
            foreach (var pointerEventData in m_PointerData)
                sb.AppendLine(pointerEventData.ToString());
        }
        return sb.ToString();
    }
}
//}



