using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class SaveLoadController
    {
        private PanelModel _panelModel;
        private readonly List<PanelController> _listController;

        public SaveLoadController(Button saveBtn, Button loadBtn, List<PanelController> listController)
        {
            _listController = listController;

            saveBtn.onClick.AddListener(SaveData);
            loadBtn.onClick.AddListener(LoadData);
        }


        private void SaveData()
        {
            for (int i = 0; i < _listController.Count; i++)
            {
                _panelModel = _listController[i].GetPanelModel();
                SavingSystem.SavingSystem.Save(_panelModel, $"{Application.dataPath}/Json/List{i}.json");
            }
        }

        private void LoadData()
        {
            for (int i = 0; i < _listController.Count; i++)
            {
                _panelModel = new PanelModel();
                _panelModel = SavingSystem.SavingSystem.Load($"{Application.dataPath}/Json/List{i}.json", _panelModel);
                
                if (_panelModel.plankList.Count == 0)
                {
                    GenerateModel();
                }

                _listController[i].ClearPlanks();
                                 
                _listController[i].SetPanelModel(_panelModel);
                for (var j = 0; j < _panelModel.plankList.Count; j++)
                {
                    _listController[i].InitPlank(_panelModel.plankList[j]);
                }
            }
        }

        private void GenerateModel()
        {
            string[] names = {"Sofia", "Roberto", "Frank", "Isabella", "Willi"};

            _panelModel = new PanelModel();
            _panelModel.panelName = "Default";
            for (var i = 0; i < 5; i++)
            {
                var newModel = new PlankModel()
                {
                    id = Random.Range(0, 10).ToString(),
                    name = names[i]
                };
                _panelModel.plankList.Add(new PlankModel() {id = newModel.id, name = newModel.name});
            }
        }
    }
}