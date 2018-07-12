using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class OnToggleOnEvent : UnityEvent
{
    public OnToggleOnEvent() { }
}

[Serializable]
public class OnToggleOffEvent : UnityEvent
{
    public OnToggleOffEvent() { }
}

public class SlideUI : MonoBehaviour
{
    [Header("Slide Point")]
    public bool ToggledWayToRight = false;
    public bool OnToggled;
    public float ToggleOnSpeed = 10.0f;
    public float ToggleOffSpeed = 10.0f;
    private bool duringOnToggle;

    private float anchorX;
    private float width;

    [Header("Events")]
    [SerializeField]
    public OnToggleOnEvent onToggleOnEvent;
    [SerializeField]
    public OnToggleOnEvent onToggleOffEvent;

    private void Awake()
    {
    }

    // Use this for initialization
    void Start()
    {
        var trans = gameObject.GetComponent<RectTransform>();

        width = trans.rect.width;
        anchorX = trans.anchoredPosition.x;

        if (!OnToggled)
        {
            if (ToggledWayToRight)
            {
                anchorX -= width;
            }
            else
            {
                anchorX += width;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Toggle()
    {
        if (!duringOnToggle)
        {
            StartCoroutine(StartToggle(!OnToggled));
        }
    }

    public void Toggle(bool toggle)
    {
        if (!duringOnToggle)
        {
            StartCoroutine(StartToggle(toggle));
        }
    }

    private IEnumerator StartToggle(bool toggle)
    {
        var trans = gameObject.GetComponent<RectTransform>();

        duringOnToggle = true;
        float moved = 0.0f;
        float sp = Time.deltaTime * ToggleOnSpeed;

        var dest = anchorX;

        if (!toggle)
        {
            sp = Time.deltaTime * ToggleOffSpeed;

            if (ToggledWayToRight)
            {
                dest += width;
            }
            else
            {
                dest -= width;
            }
        }

        while (moved <= width - 0.2f)
        {
            float newVal = Mathf.Lerp(trans.anchoredPosition.x, dest, sp);
            moved += Math.Abs(trans.anchoredPosition.x - newVal);
            trans.anchoredPosition = new Vector2(newVal, trans.anchoredPosition.y);

            yield return new WaitForEndOfFrame();
        }

        if (toggle)
        {
            if(onToggleOnEvent != null)
                onToggleOnEvent.Invoke();
        }
        else
        {
            if (onToggleOffEvent != null)
                onToggleOffEvent.Invoke();
        }

        duringOnToggle = false;
        OnToggled = toggle;
    }
}