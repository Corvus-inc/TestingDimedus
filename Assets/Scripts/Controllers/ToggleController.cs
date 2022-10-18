using System;

namespace DefaultNamespace
{
    public class ToggleController : IDisposable
    {
        private readonly ToggleView _toggleSortId;
        private readonly ToggleView _toggleSortName;
        private readonly PanelController _panelController;


        public ToggleController(ToggleView toggleSortId, ToggleView toggleSortName, PanelController panelController)
        {
            _toggleSortId = toggleSortId;
            _toggleSortName = toggleSortName;
            _panelController = panelController;

            toggleSortId.onToggle += SortToggleId;
            toggleSortName.onToggle += SortToggleName;
        }

        private void SortToggleId(bool reverse)
        {
            _panelController.SortOf(Comparator.Id, reverse);
            _panelController.VisualSort();
        }
        
        private void SortToggleName(bool reverse)
        {
            _panelController.SortOf(Comparator.Name, reverse);
            _panelController.VisualSort();
        }

        public void Dispose()
        {
            _toggleSortId.onToggle -= SortToggleId;
            _toggleSortName.onToggle -= SortToggleName;
        }
    }
}