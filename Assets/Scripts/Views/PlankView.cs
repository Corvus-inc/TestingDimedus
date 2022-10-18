using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlankView : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private TMP_Text id;
    [SerializeField] private new TMP_Text name;

    private PanelView _panelView;
    private RectTransform _rectTransform;

    public IPlankController PlankController { get; set; }
    public ITransferController TransferController { get; set; }

    public string Id
    {
        get => id.text;
        set => id.text = value;
    }
    public string Name
    {
        get => name.text;
        set => name.text = value;
    }

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        GetPanelParent();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        PlankController.SetCurrentPlank(gameObject);
        PlankController.AddCanvasToPlank();
    }

    public void OnDrag(PointerEventData eventData)
    {
        PlankController.TranslatePlank(eventData);

        _panelView.Controller.SortOf(Comparator.Rect);
        _panelView.Controller.VisualSort();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        PlankController.DestroyCanvas();
        TransferController.TransferPlank(this);

        _panelView.Controller.RebuildLayout();
    }

    public RectTransform GetRectTransform()
    {
        return _rectTransform;
    }

    public void GetPanelParent()
    {
        _panelView = GetComponentInParent<PanelView>();
    }
}