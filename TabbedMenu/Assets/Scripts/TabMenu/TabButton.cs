using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TabGroup tabGroup;
    [SerializeField] private GameObject content;

    public Image TabImage;

    public bool IsSelected { get; private set; }

    public UnityEvent OnTabEnabled;
    public UnityEvent OnTapDisabled;

    private void Start()
    {
        DisableTabContent();
        tabGroup.AddTabButton(this);
    }

    public void EnableTabContent()
    {
        IsSelected = true;

        content.SetActive(true);
        OnTabEnabled?.Invoke();
    }

    public void DisableTabContent()
    {
        IsSelected = false;

        content.SetActive(false);
        OnTapDisabled?.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tabGroup.OnTabEnter(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        tabGroup.OnTabSelected(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tabGroup.OnTabExit(this);
    }
}