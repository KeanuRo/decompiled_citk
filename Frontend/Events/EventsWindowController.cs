// Decompiled with JetBrains decompiler
// Type: Frontend.Events.EventsWindowController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using Backend.Gamedesign;
using Backend.Gamedesign.EventSystem.DataStructures;
using Backend.Gamedesign.EventSystem.Utils;
using Backend.Gamedesign.Utils;
using Backend.Gamedesign.Utils.UnitsOfWork;
using Backend.Managers;
using Frontend.ButtonActions;
using Frontend.MapWindow;
using Frontend.SceneLoadManagement;
using Frontend.Tutorial;
using Frontend.UpPanel;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
namespace Frontend.Events;

public class EventsWindowController : MonoBehaviour
{
  [SerializeField]
  private TutorialController tutorialController;
  [SerializeField]
  private Scrollbar paperSlider;
  [SerializeField]
  private RectTransform paperRectView;
  [SerializeField]
  private RectTransform paperRectContent;
  [SerializeField]
  private SimplePopUpShowerWithUpdate paperVariantAltText;
  [SerializeField]
  private Button rotateTextDownButton;
  [SerializeField]
  private UpPanelController upPanelController;
  [SerializeField]
  private TextMeshProUGUI politicName;
  [SerializeField]
  private Sprite[] positions;
  [SerializeField]
  private Image positionImage;
  [SerializeField]
  private SimplePopUpShowerWithUpdate positionName;
  [SerializeField]
  private SimplePopUpShowerWithUpdate phoneVariantPoliticNamePopUp;
  [SerializeField]
  private Scrollbar[] scrollbars;
  [SerializeField]
  private Sprite[] eventImages;
  [SerializeField]
  private Color selectedAnswerColor;
  [SerializeField]
  private Color normalAnswerColor;
  [SerializeField]
  private Color deactivatedAnswerColor;
  [SerializeField]
  private string selectedAnswerTag;
  [SerializeField]
  private string normalAnswerTag;
  [SerializeField]
  private string deactivatedAnswerTag;
  [SerializeField]
  private List<GameObject> dialogAnswers;
  [SerializeField]
  private List<GameObject> folderAnswers;
  [SerializeField]
  private GameObject paperObject;
  [SerializeField]
  private GameObject folderObject;
  [SerializeField]
  private GameObject dialogObject;
  [SerializeField]
  private TextMeshProUGUI paperHeader;
  [SerializeField]
  private TextMeshProUGUI folderHeader;
  [SerializeField]
  private TextMeshProUGUI dialogHeader;
  [SerializeField]
  private TextMeshProUGUI paperText;
  [SerializeField]
  private TextMeshProUGUI folderText;
  [SerializeField]
  private TextMeshProUGUI dialogText;
  [SerializeField]
  private Image paperImage;
  [SerializeField]
  private Image folderImage;
  [SerializeField]
  private Image dialogImage;
  [SerializeField]
  private GameObject folderNextButton;
  [SerializeField]
  private GameObject dialogNextButton;
  private EventType eventType;
  private UnitOfWork[] unitOfWorks;
  private EventDrawInfo eventDrawInfo = new EventDrawInfo();
  private int currentEventId;
  private int selectedAnswer = -1;
  private bool finalTextRead = false;

  private void Start()
  {
    this.currentEventId = GameStateManager.inst.GameState.currentEventsIds.Pop().id;
    (this.eventType, this.unitOfWorks) = EventManager.inst.StartEvent(this.currentEventId, GameStateManager.inst.GameState, this.eventDrawInfo);
    this.InitRepaint();
  }

  public void OnTextLinkEnter(string linkId)
  {
    (string description, string header) linkText = EventUtils.GetLinkText(GameStateManager.inst.GameState, GameStateManager.inst.GameRules, linkId);
    PopUpWindowManager.inst.Show(linkText.description, linkText.header, (MonoBehaviour) this);
  }

  public void OnTextLinkExit(string linkId) => PopUpWindowManager.inst.Hide((MonoBehaviour) this);

  public void RotatePaperTextDown()
  {
    this.paperSlider.value = 0.0f;
    LayoutRebuilder.ForceRebuildLayoutImmediate(this.paperRectView);
  }

  private void InitRepaint()
  {
    this.folderObject.SetActive(this.eventType == EventType.Default);
    this.dialogObject.SetActive(this.eventType == EventType.Dialog);
    this.paperObject.SetActive(this.eventType == EventType.Message);
    switch (this.eventType)
    {
      case EventType.Default:
        this.InitRepaintFolder();
        break;
      case EventType.Dialog:
        this.InitRepaintDialog();
        break;
      case EventType.Message:
        this.InitRepaintPaper();
        break;
    }
    this.tutorialController.ChangeContext(new Dictionary<string, string>()
    {
      ["eventType"] = this.eventType.ToString()
    });
    this.upPanelController.Repaint();
  }

  private static void ForceRebuildMesh(TextMeshProUGUI textMesh)
  {
    ((TMP_Text) textMesh).ForceMeshUpdate(false, false);
    LayoutRebuilder.ForceRebuildLayoutImmediate(((TMP_Text) textMesh).transform.parent.GetComponent<RectTransform>());
    ((LayoutGroup) ((TMP_Text) textMesh).transform.parent.GetComponent<VerticalLayoutGroup>()).CalculateLayoutInputVertical();
    LayoutRebuilder.ForceRebuildLayoutImmediate(((TMP_Text) textMesh).transform.parent.GetComponent<RectTransform>());
  }

  private void InitRepaintDialog()
  {
    this.dialogNextButton.SetActive(false);
    ((TMP_Text) this.dialogText).text = this.eventDrawInfo.eventDesc;
    ((TMP_Text) this.dialogHeader).text = this.eventDrawInfo.eventTitle;
    this.dialogImage.sprite = PortraitsManager.inst.GetPortrait(GameStateManager.inst.GameState, this.eventDrawInfo.character.Value);
    ((TMP_Text) this.politicName).text = PoliticUtils.GetPoliticFullName(GameStateManager.inst.GameState, this.eventDrawInfo.character.Value);
    PoliticPosition? politicPosition = GameStateManager.inst.GameState.politicPositions[this.eventDrawInfo.character.Value];
    if (politicPosition.HasValue)
    {
      this.positionImage.sprite = this.positions[(int) politicPosition.Value];
      ((Component) this.positionImage).gameObject.SetActive(true);
      this.positionName.ChangeText(PoliticUtils.GetPositionStringName(GameStateManager.inst.GameState, politicPosition.Value), string.Empty);
    }
    else
      ((Component) this.positionImage).gameObject.SetActive(false);
    EventsWindowController.ForceRebuildMesh(this.dialogText);
    this.RepaintAnswers();
    (string description, string header) descriptionForLink = CharacterUtils.GetPoliticDescriptionForLink(GameStateManager.inst.GameState, this.eventDrawInfo.character.Value);
    this.phoneVariantPoliticNamePopUp.ChangeText(descriptionForLink.description, descriptionForLink.header);
  }

  private void InitRepaintFolder()
  {
    this.folderNextButton.SetActive(false);
    ((TMP_Text) this.folderText).text = this.eventDrawInfo.eventDesc;
    ((TMP_Text) this.folderHeader).text = this.eventDrawInfo.eventTitle;
    this.folderImage.sprite = this.eventImages[this.eventDrawInfo.image];
    EventsWindowController.ForceRebuildMesh(this.folderText);
    this.RepaintAnswers();
  }

  private void InitRepaintPaper()
  {
    ((TMP_Text) this.paperText).text = this.eventDrawInfo.eventDesc;
    ((TMP_Text) this.paperHeader).text = this.eventDrawInfo.eventTitle;
    this.paperImage.sprite = this.eventImages[this.eventDrawInfo.image];
    EventsWindowController.ForceRebuildMesh(this.paperText);
    LayoutRebuilder.ForceRebuildLayoutImmediate(this.paperRectView);
    GameObject gameObject = ((Component) this.rotateTextDownButton).gameObject;
    Rect rect = this.paperRectContent.rect;
    double height1 = (double) rect.height;
    rect = this.paperRectView.rect;
    double height2 = (double) rect.height;
    int num = height1 > height2 ? 1 : 0;
    gameObject.SetActive(num != 0);
    this.paperVariantAltText.enabled = !string.IsNullOrEmpty(this.eventDrawInfo.eventNextButtonAltText);
    if (!this.paperVariantAltText.enabled)
      return;
    this.paperVariantAltText.ChangeText(this.eventDrawInfo.eventNextButtonAltText, string.Empty);
  }

  private void RepaintAnswers()
  {
    if (this.eventType == EventType.Message)
      return;
    List<GameObject> list = this.eventType == EventType.Dialog ? this.dialogAnswers : this.folderAnswers;
    Frontend.Utils.Utils.PopulateList(list, this.eventDrawInfo.optionsCount);
    for (int index = 0; index < this.eventDrawInfo.optionsCount; ++index)
    {
      GameObject gameObject = list[index];
      bool isActive = !this.finalTextRead && index < this.eventDrawInfo.optionsCount;
      Color textColor = this.selectedAnswer == -1 ? this.normalAnswerColor : (this.selectedAnswer == index ? this.selectedAnswerColor : this.deactivatedAnswerColor);
      string textTag = this.selectedAnswer == -1 ? this.normalAnswerTag : (this.selectedAnswer == index ? this.selectedAnswerTag : this.deactivatedAnswerTag);
      string text = isActive ? this.eventDrawInfo.optionsNames[index] : string.Empty;
      bool displayConditions = !string.IsNullOrEmpty(this.eventDrawInfo.optionsConditions[index]);
      string optionsCondition = this.eventDrawInfo.optionsConditions[index];
      string description = this.eventDrawInfo.optionsNamesAlt[index];
      gameObject.GetComponent<AnswerEntity>().number = index;
      gameObject.GetComponent<AnswerEntity>().Repaint(isActive, textColor, text, textTag, isActive && this.eventDrawInfo.optionsEnabled[index], displayConditions, optionsCondition, description);
    }
  }

  private void FinalRepaint(string text)
  {
    this.finalTextRead = true;
    this.RepaintAnswers();
    if (this.eventType == EventType.Dialog)
      ((TMP_Text) this.dialogText).text = text;
    else if (this.eventType == EventType.Default)
      ((TMP_Text) this.folderText).text = text;
    foreach (Scrollbar scrollbar in this.scrollbars)
      scrollbar.value = 1f;
    this.upPanelController.Repaint();
  }

  public void OnAnswerPress(int number)
  {
    if (number == this.selectedAnswer)
    {
      this.selectedAnswer = -1;
      (this.eventType == EventType.Dialog ? this.dialogNextButton : this.folderNextButton).SetActive(false);
    }
    else
    {
      (this.eventType == EventType.Dialog ? this.dialogNextButton : this.folderNextButton).SetActive(true);
      this.selectedAnswer = number;
    }
    this.RepaintAnswers();
    List<GameObject> gameObjectList = this.eventType == EventType.Dialog ? this.dialogAnswers : this.folderAnswers;
  }

  public void NextButtonPress()
  {
    if (this.finalTextRead)
      this.LeaveWindow();
    else if (this.eventType == EventType.Message)
    {
      this.LeaveWindow();
    }
    else
    {
      if (this.unitOfWorks[this.selectedAnswer] != null)
        this.unitOfWorks[this.selectedAnswer].Execute(GameStateManager.inst.GameState, GameStateManager.inst.GameRules, GameStateManager.inst.GameScenario);
      this.FinalRepaint(EventManager.inst.FinishEvent(this.currentEventId, GameStateManager.inst.GameState, this.selectedAnswer));
    }
  }

  private void LeaveWindow()
  {
    if (GamedesignSettingsManager.inst.IsPauseAfterEventEnabled())
      MapWindowController.ResetGameSpeed();
    SceneLoadManager.inst.LoadScene(6, displayAnimation: false);
  }
}
