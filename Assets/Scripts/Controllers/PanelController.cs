using System;
using System.Collections.Generic;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class PanelController
    {
        private readonly VerticalLayoutGroup _verticalLayout;

        private readonly IdComparator _idComparator;
        private readonly NameComparator _nameComparator;
        private readonly PlankRectComparator _plankRectComparator;

        private readonly PanelView _panelView;
        
        private readonly IPlankController _plankController;
        private readonly ITransferController _transferController;
        
        private PanelModel _panelModel;
        
        public List<PlankView> PlankList { get; }

        public PanelController(
            PanelView panelView,
            PlankRectComparator plankRectComparator,
            IdComparator idComparator,
            NameComparator nameComparator,
            ITransferController transferController,
            IPlankController plankController)
        {
            PlankList = new List<PlankView>();

            _panelView = panelView;
            _verticalLayout = panelView.VerticalLayout;

            _plankRectComparator = plankRectComparator;
            _idComparator = idComparator;
            _nameComparator = nameComparator;

            _transferController = transferController;
            _plankController = plankController;
        }

        public void InitPlank(PlankModel plankModel)
        {
            var newPlank = _panelView.InstantPlank();
            var plank = newPlank.GetComponent<PlankView>();

            if (plank == null)
            {
                plank = newPlank.AddComponent<PlankView>();
            }

            plank.Id = plankModel.id;
            plank.Name = plankModel.name;
            plank.TransferController = _transferController;
            plank.PlankController = _plankController;

            PlankList.Add(plank);
            _panelView.SetCount(PlankList.Count);
        }

        public void SetPanelModel(PanelModel panelModel)
        {
            _panelModel = panelModel;
            _panelView.SetName(_panelModel.panelName);
        }

        public PanelModel GetPanelModel()
        {
            var newPanelModel = new PanelModel
            {
                panelName = _panelView.GetName()
            };
            foreach (var plankView in PlankList)
            {
                newPanelModel.plankList.Add(new PlankModel(){id = plankView.Id, name = plankView.Name});
            }

            return newPanelModel;
        }

        public void ClearPlanks()
        {
            foreach (var plank in PlankList)
            { 
                UnityEngine.Object.Destroy(plank.gameObject);
            }
            PlankList.Clear();
        }
        public void VisualSort()
        {
            for (var i = 0; i < PlankList.Count; i++)
            {
                PlankList[i].transform.SetSiblingIndex(i);
            }
        }

        public void SortOf(Comparator comparator, bool reverse = false)
        {
            switch (comparator)
            {
                case Comparator.Rect:
                    PlankList.Sort(_plankRectComparator);
                    break;

                case Comparator.Id:
                    PlankList.Sort(_idComparator);
                    if (reverse)
                    {
                        PlankList.Reverse();
                    }

                    break;

                case Comparator.Name:
                    PlankList.Sort(_nameComparator);
                    if (reverse)
                    {
                        PlankList.Reverse();
                    }

                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(comparator), comparator, null);
            }
        }

        public void RebuildLayout()
        {
            _verticalLayout.SetLayoutVertical();
            _verticalLayout.SetLayoutHorizontal();
        }
    }

    public enum Comparator
    {
        Rect,
        Name,
        Id
    }
}