using UIinterface;
using UnityEngine;

public class PlayerCard : MonoBehaviour, IPlayerCard
{
    [SerializeField] private PlayerBody _playerBody;    

    [SerializeField] private BoxPlayer _containerPlayer;

    public PlayerBody GetPlayerBody() => _playerBody;

    public void SetPlayerInContainer() => _containerPlayer.SetPlayerBody(this);
}
