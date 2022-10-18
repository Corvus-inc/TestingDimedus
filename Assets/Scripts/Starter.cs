using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class Starter : MonoBehaviour
{
    [SerializeField] private List<PanelView> panelViews;
    [SerializeField] private Button saveButton;
    [SerializeField] private Button loadButton;

    private IPlankController _plankController;
    private ITransferController _transferController;

    private IdComparator _idComparator;
    private NameComparator _nameComparator;
    private PlankRectComparator _plankRectComparator;
    private List<PanelController> _panelControllers;
    private SaveLoadController _saveLoadController;
    
    private void Awake()
    {
        Construct();
    }

    private void Construct()
    {
        _transferController = new TransferController(panelViews);
        _plankController = new PlankController();

        _plankRectComparator = new PlankRectComparator();
        _idComparator = new IdComparator();
        _nameComparator = new NameComparator();

        _panelControllers = new List<PanelController>();
        foreach (var panelView in panelViews)
        {
            panelView.Controller = new PanelController(panelView, _plankRectComparator,  _idComparator, _nameComparator, _transferController,
                _plankController);
            _panelControllers.Add(panelView.Controller);
        }

        _saveLoadController = new SaveLoadController(saveButton, loadButton, _panelControllers);
    }
}
