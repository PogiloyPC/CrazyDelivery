using SceneControleInterface;
using UIinterface;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerContainer")]
public class BoxPlayer : ScriptableObject
{
    [SerializeField] private PlayerBody _bodyPlayer;

    public void SetPlayerBody(IPlayerCard playerCard) => _bodyPlayer = playerCard.GetPlayerBody();

    public PlayerBody InstantiatePlayer(IContainerStartPosition startPosition) =>
        Instantiate(_bodyPlayer, startPosition.GetStartPosition(), Quaternion.identity);
}
