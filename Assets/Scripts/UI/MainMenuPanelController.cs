using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UISystems
{
    public class MainMenuPanelController : GenericUIPanelController
    {
        //Start buttonu -> menü kapansın oyun başlasın
        //Score board buttonu ->menü kapansın score board açılsın score board kapanınca yine menüye dönsün
        //Settings buttonu -> menü kapansın settings açılsın, orada da başka settingler açılsın, kapanınca menüye geri dönsün,setting oyunda da açılsın

        [SerializeField] private Button _startGameButton;
        [SerializeField] private Button _scoreBoardButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _rewardButton;

        private void Start()
        {
            _startGameButton.onClick.AddListener(StartButtonFunction);
            _scoreBoardButton.onClick.AddListener(ScoreBoardButtonFunction);
            _settingsButton.onClick.AddListener(SettingsButtonFunction);
            _rewardButton.onClick.AddListener(RewardButtonFunction);

            UIManager.Instance().currentUIPanelController = this;
        }

        #region Button Functions
        private void StartButtonFunction()
        {
           SceneManager.LoadScene("SampleScene");
           
        }
        private void ScoreBoardButtonFunction()
        {
            ClosePanel();
            UIManager.Instance().OpenPanel(UIPanelTypes.scoreBoardPanel,true);
        }
        private void SettingsButtonFunction()
        {
            ClosePanel();
            UIManager.Instance().OpenPanel(UIPanelTypes.settingsPanel,true);

        }
        private void RewardButtonFunction()
        {
            ClosePanel();
            UIManager.Instance().OpenPanel(UIPanelTypes.creditsPanel,true);

        }
        #endregion

        public override void ClosePanel()
        {
            this.gameObject.SetActive(false);
        }
        public override void OpenPanel()
        {
            this.gameObject.SetActive(true);
        }


    }
}


