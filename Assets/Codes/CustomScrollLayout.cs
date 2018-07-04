using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomScrollLayout : MonoBehaviour {
    [Header("Horizontal or Vertical")]
    public bool IsVertical;
    [Header("ScrollRect ViewPort Content")]
    public GameObject contentView;
    [Header("Content Childs")]
    public GameObject[] childs;

    private ScrollRect scrollRect;
    private RectTransform contentViewRect;
    private EventTrigger eventTrigger;
    private bool onDrag;

    private int childLen;
    public float childSize;
    public float[] childDistance;

	// Use this for initialization
	void Start () {
        scrollRect = gameObject.GetComponent<ScrollRect>();
        eventTrigger = gameObject.GetComponent<EventTrigger>();

        if (scrollRect == null)
        {
            Debug.LogError("ScrollRect is Null");
        }
        else
        {
            scrollRect.vertical = IsVertical;
            scrollRect.horizontal = !IsVertical;
        }

        if (contentView == null)
        {
            Debug.LogError("Content View is Null");
        }
        else
        {
            Initialize();
            contentViewRect = contentView.GetComponent<RectTransform>();
        }

        if (eventTrigger == null)
        {
            Debug.LogError("EventTrigger is Null");
        }
    }
	
	// Update is called once per frame
	void Update () {
        int len = childs.Length;

        for (int i = 0; i < len; ++i)
        {

        }

        if (IsVertical)
        {
            Debug.Log(contentViewRect.anchoredPosition.y);
        }
        else
        {
            var pos = contentViewRect.anchoredPosition.x;

            if (pos < 0)
            {
                childs[len-1].transform.SetAsFirstSibling();
            }
        }
    }

    // ToDo : Need append function
    public void Initialize()
    {
        if (contentView != null)
        {
            // Initialize Childs if user for dynamic content childs
            var c = contentView.transform.childCount;
            childLen = contentView.transform.childCount;

            childs = new GameObject[childLen];
            childDistance = new float[childLen];

            int i = 0;
            foreach (Transform obj in contentView.transform)
            {
                childs[i] = obj.gameObject;
                i++;
            }
        }
    }

    #region Event Trigger
    public void BeginDrag()
    {
        onDrag = true;
    }

    public void EndDrag()
    {
        onDrag = false;
    }
    #endregion
}
