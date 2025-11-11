using System;
using UnityEngine;
using UnityEngine.UI;

public class InfiniteScroll : MonoBehaviour
{
    [SerializeField] private ScrollRect ScrollRect;
    [SerializeField] private RectTransform ViewPortTransform;
    [SerializeField] private RectTransform ContentPanelTransform;
    [SerializeField] private HorizontalLayoutGroup HorizontalLayoutGroup;

    [SerializeField] private RectTransform[] ItemList;

    private Vector2 oldVelocity;
    private bool isUpdated;
    
    
    private void Start()
    {
        oldVelocity = Vector2.zero;
        isUpdated = false;
        
        int ItemsToAdd = Mathf.CeilToInt(ViewPortTransform.rect.width / (ItemList[0].rect.width + HorizontalLayoutGroup.spacing));

        for (int i = 0; i < ItemsToAdd; i++)
        {
            RectTransform RT = Instantiate(ItemList[i % ItemList.Length], ContentPanelTransform);
            RT.SetAsLastSibling();
        }

        for (int i = 0; i < ItemList.Length; i++)
        {
            int num = ItemList.Length - i - 1;
            while (num < 0)
            {
                num += ItemList.Length;
            }
            
            RectTransform RT = Instantiate(ItemList[num], ContentPanelTransform);
            RT.SetAsFirstSibling();
        }

        ContentPanelTransform.localPosition = new Vector3((0 - ItemList[0].rect.width + HorizontalLayoutGroup.spacing) * ItemsToAdd,
            ContentPanelTransform.localPosition.y, ContentPanelTransform.localPosition.z);
    }


    private void Update()
    {
        if (isUpdated)
        {
            isUpdated = false;
            ScrollRect.velocity = oldVelocity;
        }
        
        if (ContentPanelTransform.localPosition.x > 0)
        {
            Canvas.ForceUpdateCanvases();
            oldVelocity = ScrollRect.velocity;
            ContentPanelTransform.localPosition -= new Vector3(ItemList.Length * (ItemList[0].rect.width + HorizontalLayoutGroup.spacing),0 ,0);
            isUpdated = true;
        }

        if (ContentPanelTransform.localPosition.x < 0 - ItemList.Length * (ItemList[0].rect.width + HorizontalLayoutGroup.spacing))
        {
            Canvas.ForceUpdateCanvases();
            oldVelocity = ScrollRect.velocity;
            ContentPanelTransform.localPosition += new Vector3(ItemList.Length * (ItemList[0].rect.width + HorizontalLayoutGroup.spacing),0 ,0);
            isUpdated = true;
        }
    }
}
