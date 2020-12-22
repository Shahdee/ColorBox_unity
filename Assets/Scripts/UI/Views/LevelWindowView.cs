using TMPro;
using UnityEngine;

namespace UI.Views
{
    public class LevelWindowView : AbstractWindowView
    {
        public TextMeshProUGUI LevelNumber => _levelNumber;
        
        [SerializeField] private TextMeshProUGUI _levelNumber;
    }
}
