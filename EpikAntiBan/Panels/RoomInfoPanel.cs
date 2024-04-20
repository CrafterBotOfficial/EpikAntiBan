using UnityEngine;
using UnityEngine.UI;
using UniverseLib.UI;
using UniverseLib.UI.Panels;

namespace EpikAntiBan.Panels
{
    public class RoomInfoPanel : PanelBase
    {
        public RoomInfoPanel(UIBase owner) : base(owner) { }

        public override string Name => "Room Info";
        public override int MinWidth => 25;
        public override int MinHeight => 100;
        public override Vector2 DefaultAnchorMin => new(0.025f, 0.025f);
        public override Vector2 DefaultAnchorMax => new(0.20f, 0.20f);
        public override bool CanDragAndResize => true;

        public Text RoomInfoText;

        protected override void ConstructPanelContent()
        {
            RoomInfoText = UIFactory.CreateLabel(ContentRoot, "roominfotext", "Not loaded");
            UIFactory.SetLayoutElement(RoomInfoText.gameObject);
        }

        public const string RoomInfoTemplate =
            "Code: {0}\n" +
            "Is Modded: {1}\n" +
            "Gamemode: {2}\n";
    }
}
