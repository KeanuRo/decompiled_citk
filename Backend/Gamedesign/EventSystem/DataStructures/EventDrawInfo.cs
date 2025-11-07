// Decompiled with JetBrains decompiler
// Type: Backend.Gamedesign.EventSystem.DataStructures.EventDrawInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using System.Text;

#nullable disable
namespace Backend.Gamedesign.EventSystem.DataStructures;

public class EventDrawInfo
{
  public string eventTitle;
  public string eventNextButtonAltText = (string) null;
  public string eventDesc;
  public int image;
  public Characters? character = new Characters?();
  public int optionsCount;
  public string[] optionsNames;
  public string[] optionsNamesAlt;
  public string[] optionsConditions;
  public bool[] optionsEnabled;

  public override string ToString()
  {
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.Append($"Title: {this.eventTitle}\n");
    stringBuilder.Append($"Desc: {this.eventDesc}\n");
    for (int index = 0; index < this.optionsCount; ++index)
    {
      stringBuilder.Append($"Option {index} name: {this.optionsNames[index]}\n");
      stringBuilder.Append($"Option {index} AltName: {this.optionsNamesAlt[index]}\n");
    }
    return stringBuilder.ToString();
  }
}
