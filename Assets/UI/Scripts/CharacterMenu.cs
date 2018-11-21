using System;
using Engine;
using UnityEngine;

public class CharacterMenu : MonoBehaviour
{
    private GameObject _inventoryBackground;

    private PlayerStats _character;
    private GameObject _activeTab;

    private void Start()
    {
        _inventoryBackground = transform.Find("InventoryBackground").gameObject;
        //_inventoryBackground.GetComponent<>();
        _inventoryBackground.SetActive(false);

        Hide();
    }

    private void OnGUI()
    {
        if (Input.GetKeyUp(KeyCode.I) && !IsShown)
            Show(CharacterMenuTab.Inventory);
        if (Input.GetKeyUp(KeyCode.Escape) && IsShown)
            Hide();
    }

    public bool IsShown
    {
        get { return _activeTab != null; }
    }

    public void Show(CharacterMenuTab tab)
    {
        Show();
        HideActiveTab();

        switch (tab)
        {
            case CharacterMenuTab.None:
                Hide();
                break;
            case CharacterMenuTab.Inventory:
                _activeTab = _inventoryBackground;
                Draw();
                break;
            default:
                throw new NotImplementedException(tab.ToString());
        }

        _activeTab.SetActive(true);
    }

    private void Draw()
    {
        Item[] items = CurrentGame.Team.Characters[0].Items;

        Instantiate(items[0].Image, transform.position,Quaternion.identity);
    }

    private void Show()
    {
        if (IsShown)
            return;

        Time.timeScale = 0;
    }

    public void Hide()
    {
        if (!IsShown)
            return;

        HideActiveTab();
        Time.timeScale = 1;
    }

    public void HideActiveTab()
    {
        if (_activeTab != null)
        {
            _activeTab.SetActive(false);
            _activeTab = null;
        }
    }
}

public enum CharacterMenuTab
{
    None = 0,
    Inventory
}