using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionPromptUI : MonoBehaviour
{
  private Camera _mainCam;
  [SerializeField] private GameObject _uiPanel;
  [SerializeField] private TextMeshProUGUI _promptText;
  
  private void Start() {
      _mainCam = Camera.main;
      _uiPanel.SetActive(false);
      }
      public bool IsDisplayed = false;
      public void SetUp(string promptText) {
        _promptText.text = promptText;
        _uiPanel.SetActive(true);
        IsDisplayed = true; 
      }
    
      public void Close(){
          _uiPanel.SetActive(false);
          IsDisplayed = false;
      }
    
}
