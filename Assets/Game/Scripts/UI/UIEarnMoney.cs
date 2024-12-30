using UnityEngine;
using UnityEngine.EventSystems;

public class UIEarnMoney : MonoBehaviour, IPointerClickHandler
{
    [Header("Earnings Settings")]
    [SerializeField] private float cooldown = 0.2f;

    [SerializeField] private UIMenu uIMenu;

    private float lastTapTime;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Time.time - lastTapTime < cooldown)
        {
            return;
        }

        lastTapTime = Time.time;

        GameManager.Instance.playerData.money += GameManager.Instance.playerData.income;
        GameManager.Instance.SavePlayerData();
        uIMenu.SetupMoneyUI(GameManager.Instance.playerData);
    }
}