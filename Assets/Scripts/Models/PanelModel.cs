using System;
using System.Collections.Generic;

namespace DefaultNamespace
{
    [Serializable]
    public class PanelModel
    {
        public string panelName;
        public List<PlankModel> plankList;

        public PanelModel()
        {
            plankList = new List<PlankModel>();
        }
    }
}