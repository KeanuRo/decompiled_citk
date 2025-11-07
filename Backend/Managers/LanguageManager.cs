// Decompiled with JetBrains decompiler
// Type: Backend.Managers.LanguageManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using Backend.Interfaces;
using System;
using System.Collections;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

#nullable disable
namespace Backend.Managers;

public class LanguageManager : MonoBehaviour, IInitializable
{
  public SystemLanguage tempLanguage = (SystemLanguage) 10;
  public SystemLanguage language = (SystemLanguage) 10;
  public static LanguageManager inst;
  private XDocument gameText = (XDocument) null;

  public string this[string category, string item]
  {
    get
    {
      if (this.gameText.Root.Element((XName) category) == null)
      {
        Debug.LogError((object) ("Can't find category " + category));
        return item;
      }
      if (this.gameText.Root.Element((XName) category).Element((XName) item) == null)
      {
        Debug.LogError((object) ("Can't find item " + item));
        return item;
      }
      string str = this.gameText.Root.Element((XName) category).Element((XName) item).Value;
      if (this.gameText.Root.Element((XName) category).Element((XName) item).HasAttributes)
      {
        XAttribute xattribute1 = this.gameText.Root.Element((XName) category).Element((XName) item).Attributes().Where<XAttribute>((Func<XAttribute, bool>) (atr => atr.Name == (XName) "autoNewLine")).FirstOrDefault<XAttribute>();
        XAttribute xattribute2 = this.gameText.Root.Element((XName) category).Element((XName) item).Attributes().Where<XAttribute>((Func<XAttribute, bool>) (atr => atr.Name == (XName) "newLineChar")).FirstOrDefault<XAttribute>();
        XAttribute xattribute3 = this.gameText.Root.Element((XName) category).Element((XName) item).Attributes().Where<XAttribute>((Func<XAttribute, bool>) (atr => atr.Name == (XName) "newLineParagraph")).FirstOrDefault<XAttribute>();
        if (xattribute1 != null && xattribute1.Value == "true")
        {
          string oldValue = "|";
          if (xattribute2 != null)
            oldValue = xattribute2.Value;
          str = str.Replace(oldValue, "\n");
        }
        if (xattribute3 != null && xattribute3.Value == "true")
        {
          string oldValue = "@";
          str = str.Replace(oldValue, "\t");
        }
      }
      return str;
    }
  }

  public bool CheckItemAvailabilityInCategory(string category, string item)
  {
    if (this.gameText.Root.Element((XName) category) == null)
      throw new Exception("Can't find category " + category);
    return this.gameText.Root.Element((XName) category).Element((XName) item) != null;
  }

  public string GetRandomItem(string category)
  {
    if (this.gameText.Root.Element((XName) category) == null)
    {
      Debug.LogError((object) ("Can't find category " + category));
      return category;
    }
    int num = this.gameText.Root.Element((XName) category).Elements().Count<XElement>();
    XElement xelement = this.gameText.Root.Element((XName) category).Elements().Skip<XElement>(Random.Range(0, num)).First<XElement>();
    string randomItem = xelement.Value;
    if (xelement.HasAttributes)
    {
      XAttribute xattribute1 = xelement.Attributes().Where<XAttribute>((Func<XAttribute, bool>) (atr => atr.Name == (XName) "autoNewLine")).FirstOrDefault<XAttribute>();
      XAttribute xattribute2 = xelement.Attributes().Where<XAttribute>((Func<XAttribute, bool>) (atr => atr.Name == (XName) "newLineChar")).FirstOrDefault<XAttribute>();
      XAttribute xattribute3 = xelement.Attributes().Where<XAttribute>((Func<XAttribute, bool>) (atr => atr.Name == (XName) "newLineParagraph")).FirstOrDefault<XAttribute>();
      if (xattribute1 != null && xattribute1.Value == "true")
      {
        string oldValue = "|";
        if (xattribute2 != null)
          oldValue = xattribute2.Value;
        randomItem = randomItem.Replace(oldValue, "\n");
      }
      if (xattribute3 != null && xattribute3.Value == "true")
      {
        string oldValue = "@";
        randomItem = randomItem.Replace(oldValue, "\t");
      }
    }
    return randomItem;
  }

  public void SetLanguge(SystemLanguage newLang) => this.tempLanguage = newLang;

  public void ApplyNewLanguage()
  {
    if (this.language == this.tempLanguage)
      return;
    this.language = this.tempLanguage;
    this.Switch(this.language);
    MessageManager.inst.AddMessage(new MessageManager.Message()
    {
      firstButtonText = LanguageManager.inst["system", "OK"],
      messageText = LanguageManager.inst["system", "changes_will_be_made_after_restart"],
      buttonsNumber = 1
    });
  }

  public void GoBackToPrevLanguage() => this.tempLanguage = this.language;

  private void Switch(string language) => PlayerPrefs.SetString(nameof (language), language);

  private void Switch(SystemLanguage newLang)
  {
    if (newLang == 10)
    {
      this.Switch("en");
    }
    else
    {
      if (newLang != 30)
        return;
      this.Switch("ru");
    }
  }

  public void ParseGameTextFromXMLString(string xmlString)
  {
    this.gameText = XDocument.Parse(xmlString, LoadOptions.SetLineInfo);
  }

  IEnumerator IInitializable.Initialize()
  {
    Object.DontDestroyOnLoad((Object) ((Component) this).gameObject);
    LanguageManager.inst = this;
    this.language = (SystemLanguage) 10;
    string lng = "en";
    if (PlayerPrefs.HasKey("language"))
    {
      lng = PlayerPrefs.GetString("language");
      this.language = !(lng == "ru") ? (SystemLanguage) 10 : (SystemLanguage) 30;
    }
    else if (Application.systemLanguage == 10)
      PlayerPrefs.SetString("language", "en");
    else if (Application.systemLanguage == 30)
    {
      PlayerPrefs.SetString("language", "ru");
      lng = "ru";
      this.language = (SystemLanguage) 30;
    }
    else
      PlayerPrefs.SetString("language", "en");
    TextAsset a = Resources.Load($"{lng}_text/text") as TextAsset;
    this.ParseGameTextFromXMLString(a.text);
    Resources.UnloadAsset((Object) a);
    this.tempLanguage = this.language;
    yield return (object) null;
  }
}
