using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class TransferController : ITransferController
    {
        private readonly List<PanelView> _listPanel;

        public TransferController(List<PanelView> listPanel)
        {
            _listPanel = listPanel;
        }

        public void TransferPlank(PlankView plankView)
        {
            var currentPanel = plankView.GetComponentInParent<PanelView>();
            var plankX = plankView.transform.position.x;

            var fourCornersArray = new Vector3[4];
            currentPanel.GetComponent<RectTransform>().GetWorldCorners(fourCornersArray);

            var currentRightBorder = fourCornersArray[2].x;
            var currentLeftBorder = fourCornersArray[0].x;

            if (plankX > currentRightBorder ||
                plankX < currentLeftBorder)
            {
                foreach (var panel in _listPanel)
                {
                    panel.GetComponent<RectTransform>().GetWorldCorners(fourCornersArray);
                    
                    var rightBorder = fourCornersArray[2].x;
                    var leftBorder = fourCornersArray[0].x;
                    
                    if (plankX < rightBorder && plankX > leftBorder)
                    {
                        currentPanel.Controller.PlankList.Remove(plankView);
                     
                        panel.Controller.PlankList.Add(plankView);
                        panel.SetParent(plankView.gameObject);
                        panel.SetCount(panel.Controller.PlankList.Count);
                        
                        currentPanel.SetCount(currentPanel.Controller.PlankList.Count);
                        
                        plankView.GetPanelParent();
                        return;
                    }
                }
            }
        }
    }
}