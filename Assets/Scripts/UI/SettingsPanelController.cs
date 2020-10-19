using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UISystems;

public class SettingsPanelController : GenericUIPanelController
{
    public override void ClosePanel()
    {
        UIManager.Instance().ClosePanel(UIPanelTypes.settingsPanel);
    }
    public override void OpenPanel()
    {
        this.gameObject.SetActive(true);

    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.J))
        {
            ClosePanel();
        }
    }
}
