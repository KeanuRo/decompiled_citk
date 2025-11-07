// Decompiled with JetBrains decompiler
// Type: Backend.Managers.ModsManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0000-0000-0000
// Assembly location: ...\lib\Assembly-CSharp.dll

using Backend.Interfaces;
using Backend.Managers.Steam;
using Backend.Mod;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Steamworks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Networking;

#nullable disable
namespace Backend.Managers;

public class ModsManager : MonoBehaviour, IInitializable
{
  private readonly JsonSerializerSettings jsonSettings = new JsonSerializerSettings()
  {
    TypeNameHandling = (TypeNameHandling) 4,
    Converters = (IList<JsonConverter>) new List<JsonConverter>()
    {
      (JsonConverter) new StringEnumConverter()
    }
  };
  public static ModsManager inst = (ModsManager) null;
  public Dictionary<string, ModsManager.ModEntry> availableMods = new Dictionary<string, ModsManager.ModEntry>();
  private CallResult<SteamUGCQueryCompleted_t> OnSteamUGCQueryCompletedCallResult;
  private UGCQueryHandle_t queryHandle_T;
  private uint page = 1;
  private long totalPages = -1;
  private bool needToProccess = false;
  private string lastEnabledModId = string.Empty;
  private string tempEnabledModId = string.Empty;

  private IEnumerator LoadImageFromDisc(string pathToImage, Action<Sprite> onSuccess)
  {
    using (UnityWebRequest requ = UnityWebRequestTexture.GetTexture("file:///" + pathToImage, true))
    {
      yield return (object) requ.SendWebRequest();
      if (requ.result != 1)
      {
        Debug.Log((object) ("Mod icon loading error: " + requ.error));
      }
      else
      {
        Texture2D texture = DownloadHandlerTexture.GetContent(requ);
        onSuccess(Sprite.Create(texture, new Rect(Vector2.zero, new Vector2((float) texture.width, (float) texture.height)), Vector2.one * 0.5f));
        texture = (Texture2D) null;
      }
    }
  }

  private void LoadModByPath(string potentialModFolder)
  {
    FileInfo fileInfo = new FileInfo(Path.Combine(potentialModFolder, "info.json"));
    if (!fileInfo.Exists)
      return;
    try
    {
      ModInfo modInfo = JsonConvert.DeserializeObject<ModInfo>(File.ReadAllText(fileInfo.FullName), this.jsonSettings);
      if (VersionManager.inst.Version != modInfo.version)
        return;
      this.availableMods.Add(modInfo.id, new ModsManager.ModEntry()
      {
        modInfo = modInfo,
        pathToModFolder = potentialModFolder,
        icon = (Sprite) null
      });
      this.StartCoroutine(this.LoadImageFromDisc(Path.Combine(potentialModFolder, "icon.png"), (Action<Sprite>) (loaded => this.availableMods[modInfo.id].icon = loaded)));
    }
    catch (Exception ex)
    {
      MessageManager.inst.AddMessage(new MessageManager.Message()
      {
        messageText = string.Format(LanguageManager.inst["system", "error_while_loading_mods_list"], (object) ex),
        firstButtonText = "OK",
        buttonsNumber = 1
      });
    }
  }

  private void LoadAllPhysicalModsInfo()
  {
    foreach (string enumerateDirectory in Directory.EnumerateDirectories(Path.Combine(Application.persistentDataPath, "mods")))
      this.LoadModByPath(enumerateDirectory);
  }

  private IEnumerator LoadAllSteamModsInfo()
  {
    if (SteamManager.Initialized)
    {
      this.needToProccess = true;
      this.ProcessModsFromSteam();
      while (this.needToProccess)
        yield return (object) 0;
    }
  }

  private void ProcessModsFromSteam()
  {
    try
    {
      // ISSUE: method pointer
      this.OnSteamUGCQueryCompletedCallResult = CallResult<SteamUGCQueryCompleted_t>.Create(new CallResult<SteamUGCQueryCompleted_t>.APIDispatchDelegate((object) this, __methodptr(OnSteamUGCQueryCompleted)));
      CSteamID steamId = SteamUser.GetSteamID();
      this.queryHandle_T = SteamUGC.CreateQueryUserUGCRequest(((CSteamID) ref steamId).GetAccountID(), (EUserUGCList) 6, (EUGCMatchingUGCType) 0, (EUserUGCListSortOrder) 2, SteamUtils.GetAppID(), SteamUtils.GetAppID(), this.page);
      this.OnSteamUGCQueryCompletedCallResult.Set(SteamUGC.SendQueryUGCRequest(this.queryHandle_T), (CallResult<SteamUGCQueryCompleted_t>.APIDispatchDelegate) null);
    }
    catch
    {
      Debug.LogError((object) "ModsInformationLoadingError");
    }
  }

  private void AddSteamModsFromOnePage(SteamUGCQueryCompleted_t pCallback)
  {
    for (uint index = 0; index < pCallback.m_unNumResultsReturned; ++index)
    {
      SteamUGCDetails_t steamUgcDetailsT;
      ulong num1;
      string potentialModFolder;
      uint num2;
      if (SteamUGC.GetQueryUGCResult(pCallback.m_handle, index, ref steamUgcDetailsT) && SteamUGC.GetItemInstallInfo(steamUgcDetailsT.m_nPublishedFileId, ref num1, ref potentialModFolder, (uint) byte.MaxValue, ref num2))
        this.LoadModByPath(potentialModFolder);
    }
  }

  private void OnSteamUGCQueryCompleted(SteamUGCQueryCompleted_t pCallback, bool bIOFailure)
  {
    this.AddSteamModsFromOnePage(pCallback);
    if (this.totalPages == -1L)
      this.totalPages = (long) (pCallback.m_unTotalMatchingResults / 50U) + (pCallback.m_unTotalMatchingResults % 50U > 0U ? 1L : 0L);
    if ((long) this.page < this.totalPages)
    {
      ++this.page;
      this.ProcessModsFromSteam();
    }
    else
      this.needToProccess = false;
  }

  public string CurrentlySelectedId => this.tempEnabledModId;

  public void ApplyNewModId()
  {
    if (this.lastEnabledModId != this.tempEnabledModId)
      MessageManager.inst.AddMessage(new MessageManager.Message()
      {
        firstButtonText = LanguageManager.inst["system", "OK"],
        messageText = LanguageManager.inst["system", "changes_will_be_made_after_restart"],
        buttonsNumber = 1
      });
    this.lastEnabledModId = this.tempEnabledModId;
    PlayerPrefs.SetString("mod_id", this.lastEnabledModId);
  }

  public void ResetModId() => this.tempEnabledModId = this.lastEnabledModId;

  public void SetNewTempModId(string id) => this.tempEnabledModId = id;

  private void LoadTranslationMod(ModsManager.ModEntry modEntry)
  {
    LanguageManager.inst.ParseGameTextFromXMLString(File.ReadAllText(Path.Combine(modEntry.pathToModFolder, "text.xml")));
  }

  private void LoadCSharpMod(ModsManager.ModEntry modEntry)
  {
    TypeInfo typeInfo = Assembly.LoadFrom(Path.Combine(modEntry.pathToModFolder, "code.dll")).DefinedTypes.FirstOrDefault<TypeInfo>((Func<TypeInfo, bool>) (type => type.IsDefined(typeof (ModEntryPointAttribute))));
    if ((Type) typeInfo == (Type) null)
      throw new Exception("Can not load the mod, no entry class found. Please, decorate the entry class with ModEntryPointAttribute");
    MethodInfo methodInfo = typeInfo.DeclaredMethods.FirstOrDefault<MethodInfo>((Func<MethodInfo, bool>) (method => method.IsDefined(typeof (ModEntryPointAttribute))));
    if (methodInfo == (MethodInfo) null)
      throw new Exception($"Can not load the mod, no entry method in {typeInfo.Name} found. Please, decorate the entry method with ModEntryPointAttribute");
    if (!methodInfo.IsStatic)
      throw new Exception($"Entry method {methodInfo.Name} is not static. In order to load the mod this method should be static.");
    methodInfo.Invoke((object) null, (object[]) null);
  }

  private void LoadMod(string modId)
  {
    if (string.IsNullOrEmpty(modId))
      return;
    try
    {
      if (this.availableMods[modId].modInfo.modType == ModInfo.ModType.Translation)
        this.LoadTranslationMod(this.availableMods[modId]);
      else
        this.LoadCSharpMod(this.availableMods[modId]);
    }
    catch (Exception ex)
    {
      Debug.Log((object) ex);
      this.lastEnabledModId = this.tempEnabledModId = string.Empty;
      PlayerPrefs.SetString("mod_id", this.lastEnabledModId);
      MessageManager.inst.AddMessage(new MessageManager.Message()
      {
        messageText = string.Format(LanguageManager.inst["system", "error_while_loading_mod"], (object) ex),
        firstButtonText = "OK",
        buttonsNumber = 1
      });
    }
  }

  IEnumerator IInitializable.Initialize()
  {
    ModsManager.inst = this;
    UnityEngine.Object.DontDestroyOnLoad((UnityEngine.Object) this.gameObject);
    if (!PlayerPrefs.HasKey("mod_id"))
      PlayerPrefs.SetString("mod_id", string.Empty);
    this.lastEnabledModId = this.tempEnabledModId = PlayerPrefs.GetString("mod_id");
    if (!Directory.Exists(Path.Combine(Application.persistentDataPath, "mods")))
      Directory.CreateDirectory(Path.Combine(Application.persistentDataPath, "mods"));
    this.LoadAllPhysicalModsInfo();
    yield return (object) this.StartCoroutine(this.LoadAllSteamModsInfo());
    if (!string.IsNullOrEmpty(this.lastEnabledModId) && !this.availableMods.ContainsKey(this.lastEnabledModId))
    {
      this.lastEnabledModId = this.tempEnabledModId = string.Empty;
      PlayerPrefs.SetString("mod_id", this.lastEnabledModId);
    }
    this.LoadMod(this.lastEnabledModId);
  }

  public class ModEntry
  {
    public ModInfo modInfo;
    public string pathToModFolder;
    public Sprite icon;
  }
}
