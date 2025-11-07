// Decompiled with JetBrains decompiler
// Type: Frontend.ButtonActions.SimplePopUpShowerWithUpdate
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using Backend.Managers;
using UnityEngine;

#nullable disable
namespace Frontend.ButtonActions;

public class SimplePopUpShowerWithUpdate : MonoBehaviour
{
  [SerializeField]
  private bool rightSided = true;
  [SerializeField]
  private string text = string.Empty;
  [SerializeField]
  private string title = string.Empty;
  [Header("Добавить, если окно нужно показывать в конкретном месте")]
  [SerializeField]
  private GameObject popUpPlace = (GameObject) null;

  public void ChangeText(string newText, string newTitle)
  {
    this.text = newText;
    this.title = newTitle;
    if (!((Object) PopUpWindowManager.inst.Owner == (Object) this))
      return;
    PopUpWindowManager.inst.Show(this.text, this.title, (MonoBehaviour) this, (Object) this.popUpPlace == (Object) null ? new Vector3?() : new Vector3?(this.popUpPlace.transform.position), this.rightSided);
  }

  public void Show()
  {
    if (!this.enabled)
      return;
    PopUpWindowManager.inst.Show(this.text, this.title, (MonoBehaviour) this, (Object) this.popUpPlace == (Object) null ? new Vector3?() : new Vector3?(this.popUpPlace.transform.position), this.rightSided);
  }

  public void Hide() => PopUpWindowManager.inst.Hide((MonoBehaviour) this);

  private void OnDisable() => PopUpWindowManager.inst.Hide((MonoBehaviour) this);
}
