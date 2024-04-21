using EpikAntiBan.Panels;
using EpikAntiBan.Patches;
using ExitGames.Client.Photon;
using Photon.Pun;

namespace EpikAntiBan
{
    public class PunCallbacks : MonoBehaviourPunCallbacks
    {
        private void LateUpdate()
        {
            var room = PhotonNetwork.CurrentRoom ?? null;
            GorillaTaggerPatch.RoomInfoPanel.RoomInfoText.text =
                room is object ?
                string.Format(RoomInfoPanel.RoomInfoTemplate,
                        room.Name,
                        room.CustomProperties["gameMode"].ToString().Contains("MODDED_"),
                        room.CustomProperties["gameMode"],
                        room.PlayerCount
                ) : "Not in room!";
        }

        public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
        {
            if (propertiesThatChanged.TryGetValue("gameMode", out object gameMode))
            {
                string LogMessage = "The gamemode has changed unexpectedly. " + gameMode;
                Main.Logger.LogMessage(LogMessage);
                Main.Logger.LogFatal(LogMessage);
                PhotonNetwork.Disconnect();
            }
        }
    }
}
