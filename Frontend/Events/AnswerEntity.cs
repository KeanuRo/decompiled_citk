// Decompiled with JetBrains decompiler
// Type: Frontend.Events.AnswerEntity
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1AEE2D60-F9AC-4BB1-9F59-FC7C8812BBA8
// Assembly location: C:\Users\Киану\RiderProjects\SampleCitK2Mod\lib\Assembly-CSharp.dll

using Frontend.ButtonActions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
namespace Frontend.Events;

public class AnswerEntity : MonoBehaviour
{
  [SerializeField]
  private Button button;
  [SerializeField]
  private TextMeshProUGUI textMesh;
  public int number = 0;
  [SerializeField]
  private EventsWindowController controller;
  [SerializeField]
  private GameObject conditionsGreen;
  [SerializeField]
  private GameObject conditionsRed;
  [SerializeField]
  private GameObject conditionsGrey;
  [SerializeField]
  private SimplePopUpShowerWithUpdate descriptionPopUp;
  [SerializeField]
  private SimplePopUpShowerWithUpdate conditionsGreenPopUp;
  [SerializeField]
  private SimplePopUpShowerWithUpdate conditionsRedPopUp;

  public void Press() => this.controller.OnAnswerPress(this.number);

  public void Repaint(
    bool isActive,
    Color textColor,
    string text,
    string textTag,
    bool isInteractable,
    bool displayConditions,
    string conditionsText,
    string description)
  {
    ((Behaviour) this.textMesh).enabled = false;
    this.gameObject.SetActive(isActive);
    if (!isActive)
      return;
    ((TMP_Text) this.textMesh).text = $"<{textTag}>{text}</{textTag}>";
    ((Graphic) this.textMesh).color = textColor;
    ((Behaviour) this.textMesh).enabled = true;
    ((TMP_Text) this.textMesh).ForceMeshUpdate(false, false);
    ((Selectable) this.button).interactable = true;
    ((Selectable) this.button).interactable = isInteractable;
    if (string.IsNullOrEmpty(description))
    {
      this.descriptionPopUp.enabled = false;
    }
    else
    {
      this.descriptionPopUp.enabled = true;
      this.descriptionPopUp.ChangeText(description, string.Empty);
    }
    if (!displayConditions)
    {
      this.conditionsGreen.SetActive(false);
      this.conditionsRed.SetActive(false);
      this.conditionsGrey.SetActive(true);
    }
    else if (isInteractable)
    {
      this.conditionsGreen.SetActive(true);
      this.conditionsRed.SetActive(false);
      this.conditionsGrey.SetActive(false);
      this.conditionsGreenPopUp.ChangeText(conditionsText, string.Empty);
    }
    else
    {
      this.conditionsGreen.SetActive(false);
      this.conditionsRed.SetActive(true);
      this.conditionsGrey.SetActive(false);
      this.conditionsRedPopUp.ChangeText(conditionsText, string.Empty);
    }
  }
}
