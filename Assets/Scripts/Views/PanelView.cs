using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DefaultNamespace;

public class PanelView : MonoBehaviour
{
    [SerializeField] private TMP_Text counter;
    [SerializeField] private TMP_Text panelName;
    [SerializeField] private GameObject toggles;
    [SerializeField] private GameObject prefabPlank;
    [SerializeField] private GameObject panelContent;
    [SerializeField] private VerticalLayoutGroup verticalLayout;

    public PanelController Controller { get; set; }

    public VerticalLayoutGroup VerticalLayout => verticalLayout;
    private void Awake()
    {
        if (toggles == null) return;
        var togglesView = toggles.GetComponentsInChildren<ToggleView>();
        new ToggleController(togglesView[0], togglesView[1], Controller);
    }

    public GameObject InstantPlank()
    {
       return Instantiate(prefabPlank, panelContent.transform);
    }

    public void SetParent(GameObject plank)
    {
        plank.transform.SetParent(panelContent.transform, false);
    }

    public void SetCount(int count)
    {
        counter.text = count.ToString();
    }

    public void SetName(string name)
    {
        panelName.text = name;
    }

    public string GetName()
    {
       return  panelName.text;
    }
}