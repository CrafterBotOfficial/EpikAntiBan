using EpikAntiBan.Panels;
using EpikAntiBan.Patches;
using ExitGames.Client.Photon;
using Photon.Pun;

namespace EpikAntiBan
{
    public class PunCallbacks : MonoBehaviourPunCallbacks
    {
        private void Update()
        {
            GorillaTaggerPatch.RoomInfoPanel.RoomInfoText.text = PhotonNetwork.InRoom ?
                string.Format(RoomInfoPanel.RoomInfoTemplate,
                PhotonNetwork.CurrentRoom.Name,
                PhotonNetwork.CurrentRoom.CustomProperties["gameMode"].ToString().Contains("MODDED_"),
                PhotonNetwork.CurrentRoom.CustomProperties["gameMode"]
                ) : "Not in room!";
        }

        public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
        {
            if (propertiesThatChanged.TryGetValue("gameMode", out object gameMode))
            {
                MonkeNotificationLib.NotificationController.AppendMessage("EpikAntiBan", "The gamemode has changed unexpectedly. " + gameMode, false, 6);
                PhotonNetwork.Disconnect();
            }
        }
    }
}
