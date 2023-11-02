using UnityEngine;

public abstract class TutorialUITrigger : TutorialUI, IEnableTutorialUI, IDestroyableTutorialUI
{
    [SerializeField] private DestroyerTutorialUI _destroyerUI;
    [SerializeField] private SwitchTutorialUI _switchUI;

    [SerializeField] private Point _positionObject;

    private void Start()
    {
        _destroyerUI.InitTutorialUI(this);
        _switchUI.InitTutorialUI(this);

        gameObject.SetActive(false);
    }

    public void EnableUI()
    {
        if (gameObject.activeSelf)
            return;

        gameObject.SetActive(true);
    }

    public void DestroyUI()
    {
        Destroy(gameObject, DestroyTime);
    }

    private void LateUpdate()
    {
        if (_positionObject)
            transform.position = _positionObject.GetPosition();
    }
}
