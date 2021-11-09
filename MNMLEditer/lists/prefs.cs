using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D3Studio.lists
{
    public static class prefs
    {
        public static prefsType readPrefs(string file)
        {
            Dictionary<string, string> p = new Dictionary<string, string>();
            string[] lines = File.ReadAllLines(file);
            foreach(string line in lines)
            {
                string[] parts = line.Split(' ');
                p.Add(parts[0].Trim('"'), parts[1].Trim('"'));
            }
            return new prefsType(p);
        }

        public static prefsTypeXbox readPrefsXbox(string file)
        {
            Dictionary<string, string> p = new Dictionary<string, string>();
            string[] lines = File.ReadAllLines(file);
            foreach (string line in lines)
            {
                string[] parts = line.Split(' ');
                p.Add(parts[0].Trim('"'), parts[1].Trim('"'));
            }
            return new prefsTypeXbox(p);
        }

        public static prefsTypeXbox readPrefsPS(string file)
        {
            Stream fileDecrypted = TonicBox.Data.XorMagic.Savedecryptfile(file);
            Dictionary<string, string> p = new Dictionary<string, string>();
            foreach (string line in ReadLines(fileDecrypted, Encoding.UTF8))
            {
                string[] parts = line.Split(' ');
                p.Add(parts[0].Trim('"'), parts[1].Trim('"'));
            }
            return new prefsTypeXbox(p);
        }

        public static void writePrefs(string file, prefsType p)
        {
            if (File.Exists(file))
                File.Delete(file);
            File.Create(file).Dispose();
            PropertyInfo[] properties = typeof(prefsType).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                File.AppendAllLines(file, new[] { property.Name + " \"" + property.GetValue(p).ToString() + "\"" });
            }
        }

        public static void writePrefsXbox(string file, prefsTypeXbox p)
        {
            if (File.Exists(file))
                File.Delete(file);
            File.Create(file).Dispose();
            PropertyInfo[] properties = typeof(prefsTypeXbox).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                File.AppendAllLines(file, new[] { property.Name + " \"" + property.GetValue(p).ToString() + "\"" });
            }
        }

        public static void writePrefsPS(string file, prefsTypeXbox p)
        {
            if (File.Exists(file))
                File.Delete(file);
            File.Create(file).Dispose();
            PropertyInfo[] properties = typeof(prefsTypeXbox).GetProperties();
            string outText = "";
            foreach (PropertyInfo property in properties)
            {
                outText = outText + property.Name + " \"" + property.GetValue(p).ToString() + "\"\r\n";
            }
            FileStream fileStream = new FileStream(file, FileMode.Truncate, FileAccess.ReadWrite, FileShare.ReadWrite);
            using (Stream stream1 = new MemoryStream())
            {
                stream1.Write(Encoding.ASCII.GetBytes(outText), 0, outText.Length);
                stream1.Position = 0L;
                Stream stream2 = TonicBox.Data.XorMagic.Saveencryptstream(stream1);
                stream2.Position = 0L;
                stream2.CopyTo(fileStream);
            }
            fileStream.Close();
        }

        public static IEnumerable<string> ReadLines(Stream streamProvider,Encoding encoding)
        {
            using (var stream = streamProvider)
            using (var reader = new StreamReader(stream, encoding))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }

    public class prefsTypeXbox
    {
        public prefsTypeXbox(Dictionary<string, string> p)
        {
            this.PreferencesVersion = Convert.ToInt32(p["PreferencesVersion"]);
            this.PlayedCutscene0 = Convert.ToInt32(p["PlayedCutscene0"]);
            this.PlayedCutscene1 = Convert.ToInt32(p["PlayedCutscene1"]);
            this.PlayedCutscene2 = Convert.ToInt32(p["PlayedCutscene2"]);
            this.PlayedCutscene3 = Convert.ToInt32(p["PlayedCutscene3"]);
            this.PlayedCutscene4 = Convert.ToInt32(p["PlayedCutscene4"]);
            this.FirstTimeFlowCompleted = Convert.ToInt32(p["FirstTimeFlowCompleted"]);
            this.DisplayModeFlags = Convert.ToInt32(p["DisplayModeFlags"]);
            this.DisplayModeWindowMode = Convert.ToInt32(p["DisplayModeWindowMode"]);
            this.DisplayModeWinLeft = Convert.ToInt32(p["DisplayModeWinLeft"]);
            this.DisplayModeWinTop = Convert.ToInt32(p["DisplayModeWinTop"]);
            this.DisplayModeWinWidth = Convert.ToInt32(p["DisplayModeWinWidth"]);
            this.DisplayModeWinHeight = Convert.ToInt32(p["DisplayModeWinHeight"]);
            this.DisplayModeUIOptWidth = Convert.ToInt32(p["DisplayModeUIOptWidth"]);
            this.DisplayModeUIOptHeight = Convert.ToInt32(p["DisplayModeUIOptHeight"]);
            this.DisplayModeWidth = Convert.ToInt32(p["DisplayModeWidth"]);
            this.DisplayModeHeight = Convert.ToInt32(p["DisplayModeHeight"]);
            this.DisplayModeRefreshRate = Convert.ToInt32(p["DisplayModeRefreshRate"]);
            this.DisplayModeBitDepth = Convert.ToInt32(p["DisplayModeBitDepth"]);
            this.Gamma = Convert.ToSingle(p["Gamma"]);
            this.MipOffset = Convert.ToInt32(p["MipOffset"]);
            this.ShadowQuality = Convert.ToInt32(p["ShadowQuality"]);
            this.ShadowDetail = Convert.ToInt32(p["ShadowDetail"]);
            this.PhysicsQuality = Convert.ToInt32(p["PhysicsQuality"]);
            this.ClutterQuality = Convert.ToInt32(p["ClutterQuality"]);
            this.Vsync = Convert.ToInt32(p["Vsync"]);
            this.Letterbox = Convert.ToInt32(p["Letterbox"]);
            this.Antialiasing = Convert.ToInt32(p["Antialiasing"]);
            this.LockCursorInFullscreenWindowed = Convert.ToInt32(p["LockCursorInFullscreenWindowed"]);
            this.LimitForegroundFPS = Convert.ToInt32(p["LimitForegroundFPS"]);
            this.MaxForegroundFPS = Convert.ToInt32(p["MaxForegroundFPS"]);
            this.LimitBackgroundFPS = Convert.ToInt32(p["LimitBackgroundFPS"]);
            this.MaxBackgroundFPS = Convert.ToInt32(p["MaxBackgroundFPS"]);
            this.DisableTrilinearFiltering = Convert.ToInt32(p["DisableTrilinearFiltering"]);
            this.ColorCorrection = Convert.ToInt32(p["ColorCorrection"]);
            this.MipBias = Convert.ToSingle(p["MipBias"]);
            this.ReflectionQuality = Convert.ToInt32(p["ReflectionQuality"]);
            this.HardwareClass = Convert.ToInt32(p["HardwareClass"]);
            this.PCIVendor = Convert.ToInt32(p["PCIVendor"]);
            this.PCIDevice = Convert.ToInt32(p["PCIDevice"]);
            this.flSafeZoneLeft = Convert.ToSingle(p["flSafeZoneLeft"]);
            this.flSafeZoneTop = Convert.ToSingle(p["flSafeZoneTop"]);
            this.flSafeZoneRight = Convert.ToSingle(p["flSafeZoneRight"]);
            this.flSafeZoneBottom = Convert.ToSingle(p["flSafeZoneBottom"]);
            this.MasterVolume = Convert.ToSingle(p["MasterVolume"]);
            this.EffectVolume = Convert.ToSingle(p["EffectVolume"]);
            this.MusicVolume = Convert.ToSingle(p["MusicVolume"]);
            this.NarrationVolume = Convert.ToSingle(p["NarrationVolume"]);
            this.AmbientVolume = Convert.ToSingle(p["AmbientVolume"]);
            this.ChannelsToUse = Convert.ToInt32(p["ChannelsToUse"]);
            this.SoundDriver = Convert.ToInt32(p["SoundDriver"]);
            this.SpeakerMode = Convert.ToInt32(p["SpeakerMode"]);
            this.ReverseSpeakers = Convert.ToInt32(p["ReverseSpeakers"]);
            this.QuestSubtitlesEnabled = Convert.ToInt32(p["QuestSubtitlesEnabled"]);
            this.CinematicsSubtitlesEnabled = Convert.ToInt32(p["CinematicsSubtitlesEnabled"]);
            this.PlayInBackground = Convert.ToInt32(p["PlayInBackground"]);
            this.MuteSound = Convert.ToInt32(p["MuteSound"]);
            this.MuteEffects = Convert.ToInt32(p["MuteEffects"]);
            this.MuteAmbient = Convert.ToInt32(p["MuteAmbient"]);
            this.MuteVoice = Convert.ToInt32(p["MuteVoice"]);
            this.MuteMusic = Convert.ToInt32(p["MuteMusic"]);
            this.ItemsOnGroundSetting = Convert.ToInt32(p["ItemsOnGroundSetting"]);
            this.ItemTagsAsIcons = Convert.ToInt32(p["ItemTagsAsIcons"]);
            this.ShowItemTooltipOnDrop = Convert.ToInt32(p["ShowItemTooltipOnDrop"]);
            this.ShowMonsterHPBars = Convert.ToInt32(p["ShowMonsterHPBars"]);
            this.ShowItemsOnGround = Convert.ToInt32(p["ShowItemsOnGround"]);
            this.ShowHPBarNumbers = Convert.ToInt32(p["ShowHPBarNumbers"]);
            this.ShowHealNumbers = Convert.ToInt32(p["ShowHealNumbers"]);
            this.ShowDamageNumbers = Convert.ToInt32(p["ShowDamageNumbers"]);
            this.ShowCriticals = Convert.ToInt32(p["ShowCriticals"]);
            this.ShowDefensiveMessages = Convert.ToInt32(p["ShowDefensiveMessages"]);
            this.InventoryZoom = Convert.ToInt32(p["InventoryZoom"]);
            this.ShowPlayerNames = Convert.ToInt32(p["ShowPlayerNames"]);
            this.ShowPlayerHPBars = Convert.ToInt32(p["ShowPlayerHPBars"]);
            this.AutoEquipItems = Convert.ToInt32(p["AutoEquipItems"]);
            this.EnableSmartCoopMinimap = Convert.ToInt32(p["EnableSmartCoopMinimap"]);
            this.AlwaysShowCampaignObjectives = Convert.ToInt32(p["AlwaysShowCampaignObjectives"]);
            this.AlwaysShowAdventureObjectives = Convert.ToInt32(p["AlwaysShowAdventureObjectives"]);
            this.ShowTutorials = Convert.ToInt32(p["ShowTutorials"]);
            this.ShowBreadCrumbs = Convert.ToInt32(p["ShowBreadCrumbs"]);
            this.ShowClock = Convert.ToInt32(p["ShowClock"]);
            this.ShowAdvancedTooltips = Convert.ToInt32(p["ShowAdvancedTooltips"]);
            this.ElectiveMode = Convert.ToInt32(p["ElectiveMode"]);
            this.DisableCutscenes = Convert.ToInt32(p["DisableCutscenes"]);
            this.DisableOSShortcuts = Convert.ToInt32(p["DisableOSShortcuts"]);
            this.UseCommandAsControl = Convert.ToInt32(p["UseCommandAsControl"]);
            this.UseCommandClickAsRightClick = Convert.ToInt32(p["UseCommandClickAsRightClick"]);
            this.NotifyFriendOnline = Convert.ToInt32(p["NotifyFriendOnline"]);
            this.NotifyFriendOffline = Convert.ToInt32(p["NotifyFriendOffline"]);
            this.NotifyFriendRequest = Convert.ToInt32(p["NotifyFriendRequest"]);
            this.NotifyFriendAchievement = Convert.ToInt32(p["NotifyFriendAchievement"]);
            this.NotifyDisplayWindow = Convert.ToInt32(p["NotifyDisplayWindow"]);
            this.NotifyDuration = Convert.ToInt32(p["NotifyDuration"]);
            this.AllowQuickJoin = Convert.ToInt32(p["AllowQuickJoin"]);
            this.NotifyAuctionHouseEvent = Convert.ToInt32(p["NotifyAuctionHouseEvent"]);
            this.NotifyFriendBroadcastDisabled = Convert.ToInt32(p["NotifyFriendBroadcastDisabled"]);
            this.ShowLocalPlayersListDisabled = Convert.ToInt32(p["ShowLocalPlayersListDisabled"]);
            this.NotifyGuildMemberOnlineDisabled = Convert.ToInt32(p["NotifyGuildMemberOnlineDisabled"]);
            this.MatureLanguageFilter = Convert.ToInt32(p["MatureLanguageFilter"]);
            this.EchoQuestDialogToChat = Convert.ToInt32(p["EchoQuestDialogToChat"]);
            this.KeybindingVersion = Convert.ToInt32(p["KeybindingVersion"]);
            this.MatchmakeRegionOverride = Convert.ToInt32(p["MatchmakeRegionOverride"]);
            this.MatchmakeRegionStrict = Convert.ToInt32(p["MatchmakeRegionStrict"]);
            this.MatchmakeLanguageStrict = Convert.ToInt32(p["MatchmakeLanguageStrict"]);
        }
        public int PreferencesVersion { get; set; }
        public int PlayedCutscene0 { get; set; }
        public int PlayedCutscene1 { get; set; }
        public int PlayedCutscene2 { get; set; }
        public int PlayedCutscene3 { get; set; }
        public int PlayedCutscene4 { get; set; }
        public int FirstTimeFlowCompleted { get; set; }
        public int DisplayModeFlags { get; set; }
        public int DisplayModeWindowMode { get; set; }
        public int DisplayModeWinLeft { get; set; }
        public int DisplayModeWinTop { get; set; }
        public int DisplayModeWinWidth { get; set; }
        public int DisplayModeWinHeight { get; set; }
        public int DisplayModeUIOptWidth { get; set; }
        public int DisplayModeUIOptHeight { get; set; }
        public int DisplayModeWidth { get; set; }
        public int DisplayModeHeight { get; set; }
        public int DisplayModeRefreshRate { get; set; }
        public int DisplayModeBitDepth { get; set; }
        public float Gamma { get; set; }
        public int MipOffset { get; set; }
        public int ShadowQuality { get; set; }
        public int ShadowDetail { get; set; }
        public int PhysicsQuality { get; set; }
        public int ClutterQuality { get; set; }
        public int Vsync { get; set; }
        public int Letterbox { get; set; }
        public int Antialiasing { get; set; }
        public int LockCursorInFullscreenWindowed { get; set; }
        public int LimitForegroundFPS { get; set; }
        public int MaxForegroundFPS { get; set; }
        public int LimitBackgroundFPS { get; set; }
        public int MaxBackgroundFPS { get; set; }
        public int DisableTrilinearFiltering { get; set; }
        public int ColorCorrection { get; set; }
        public float MipBias { get; set; }
        public int ReflectionQuality { get; set; }
        public int HardwareClass { get; set; }
        public int PCIVendor { get; set; }
        public int PCIDevice { get; set; }
        public float flSafeZoneLeft { get; set; }
        public float flSafeZoneTop { get; set; }
        public float flSafeZoneRight { get; set; }
        public float flSafeZoneBottom { get; set; }
        public float MasterVolume { get; set; }
        public float EffectVolume { get; set; }
        public float MusicVolume { get; set; }
        public float NarrationVolume { get; set; }
        public float AmbientVolume { get; set; }
        public int ChannelsToUse { get; set; }
        public int SoundDriver { get; set; }
        public int SpeakerMode { get; set; }
        public int ReverseSpeakers { get; set; }
        public int QuestSubtitlesEnabled { get; set; }
        public int CinematicsSubtitlesEnabled { get; set; }
        public int PlayInBackground { get; set; }
        public int MuteSound { get; set; }
        public int MuteEffects { get; set; }
        public int MuteAmbient { get; set; }
        public int MuteVoice { get; set; }
        public int MuteMusic { get; set; }
        public int ItemsOnGroundSetting { get; set; }
        public int ItemTagsAsIcons { get; set; }
        public int ShowItemTooltipOnDrop { get; set; }
        public int ShowMonsterHPBars { get; set; }
        public int ShowItemsOnGround { get; set; }
        public int ShowHPBarNumbers { get; set; }
        public int ShowHealNumbers { get; set; }
        public int ShowDamageNumbers { get; set; }
        public int ShowCriticals { get; set; }
        public int ShowDefensiveMessages { get; set; }
        public int InventoryZoom { get; set; }
        public int ShowPlayerNames { get; set; }
        public int ShowPlayerHPBars { get; set; }
        public int AutoEquipItems { get; set; }
        public int EnableSmartCoopMinimap { get; set; }
        public int AlwaysShowCampaignObjectives { get; set; }
        public int AlwaysShowAdventureObjectives { get; set; }
        public int ShowTutorials { get; set; }
        public int ShowBreadCrumbs { get; set; }
        public int ShowClock { get; set; }
        public int ShowAdvancedTooltips { get; set; }
        public int ElectiveMode { get; set; }
        public int DisableCutscenes { get; set; }
        public int DisableOSShortcuts { get; set; }
        public int UseCommandAsControl { get; set; }
        public int UseCommandClickAsRightClick { get; set; }
        public int NotifyFriendOnline { get; set; }
        public int NotifyFriendOffline { get; set; }
        public int NotifyFriendRequest { get; set; }
        public int NotifyFriendAchievement { get; set; }
        public int NotifyDisplayWindow { get; set; }
        public int NotifyDuration { get; set; }
        public int AllowQuickJoin { get; set; }
        public int NotifyAuctionHouseEvent { get; set; }
        public int NotifyFriendBroadcastDisabled { get; set; }
        public int ShowLocalPlayersListDisabled { get; set; }
        public int NotifyGuildMemberOnlineDisabled { get; set; }
        public int MatureLanguageFilter { get; set; }
        public int EchoQuestDialogToChat { get; set; }
        public int KeybindingVersion { get; set; }
        public int MatchmakeRegionOverride { get; set; }
        public int MatchmakeRegionStrict { get; set; }
        public int MatchmakeLanguageStrict { get; set; }
}

    public class prefsType
    {
        public prefsType(Dictionary<string,string> p)
        {
            this.PreferencesVersion = Convert.ToInt32(p["PreferencesVersion"]); //46"
            this.PlayedCutscene0 = Convert.ToInt32(p["PlayedCutscene0"]); //1"
            this.PlayedCutscene1 = Convert.ToInt32(p["PlayedCutscene1"]); //0"
            this.PlayedCutscene2 = Convert.ToInt32(p["PlayedCutscene2"]); //0"
            this.PlayedCutscene3 = Convert.ToInt32(p["PlayedCutscene3"]); //0"
            this.PlayedCutscene4 = Convert.ToInt32(p["PlayedCutscene4"]); //0"
            this.FirstTimeFlowCompleted = Convert.ToInt32(p["FirstTimeFlowCompleted"]); //1"
            this.WhatsNewSeen = Convert.ToSingle(p["WhatsNewSeen"]); //2.600000"
            this.AnniversarySeen = Convert.ToInt32(p["AnniversarySeen"]); //0"
            this.LeaderboardSeenSeason = Convert.ToInt32(p["LeaderboardSeenSeason"]); //0"
            this.SeasonTutorialsSeen = Convert.ToInt32(p["SeasonTutorialsSeen"]); //0"
            this.EulaAcceptedNX64 = Convert.ToInt32(p["EulaAcceptedNX64"]); //0"
            this.WhatsNewSeenNX64 = Convert.ToInt32(p["WhatsNewSeenNX64"]); //1"
            this.DisplayModeFlags = Convert.ToInt32(p["DisplayModeFlags"]); //10"
            this.DisplayModeWindowMode = Convert.ToInt32(p["DisplayModeWindowMode"]); //0"
            this.DisplayModeWinLeft = Convert.ToInt32(p["DisplayModeWinLeft"]); //0"
            this.DisplayModeWinTop = Convert.ToInt32(p["DisplayModeWinTop"]); //0"
            this.DisplayModeWinWidth = Convert.ToInt32(p["DisplayModeWinWidth"]); //1024"
            this.DisplayModeWinHeight = Convert.ToInt32(p["DisplayModeWinHeight"]); //768"
            this.DisplayModeUIOptWidth = Convert.ToInt32(p["DisplayModeUIOptWidth"]); //1024"
            this.DisplayModeUIOptHeight = Convert.ToInt32(p["DisplayModeUIOptHeight"]); //768"
            this.DisplayModeWidth = Convert.ToInt32(p["DisplayModeWidth"]); //1024"
            this.DisplayModeHeight = Convert.ToInt32(p["DisplayModeHeight"]); //768"
            this.DisplayModeRefreshRate = Convert.ToInt32(p["DisplayModeRefreshRate"]); //60"
            this.DisplayModeBitDepth = Convert.ToInt32(p["DisplayModeBitDepth"]); //32"
            this.DisplayModeMSAALevel = Convert.ToInt32(p["DisplayModeMSAALevel"]); //0"
            this.Gamma = Convert.ToSingle(p["Gamma"]); //1.500000"
            this.MipOffset = Convert.ToInt32(p["MipOffset"]); //0"
            this.ShadowQuality = Convert.ToInt32(p["ShadowQuality"]); //6"
            this.ShadowDetail = Convert.ToInt32(p["ShadowDetail"]); //1"
            this.PhysicsQuality = Convert.ToInt32(p["PhysicsQuality"]); //1"
            this.ClutterQuality = Convert.ToInt32(p["ClutterQuality"]); //3"
            this.Vsync = Convert.ToInt32(p["Vsync"]); //1"
            this.LargeCursor = Convert.ToInt32(p["LargeCursor"]); //0"
            this.Letterbox = Convert.ToInt32(p["Letterbox"]); //0"
            this.Antialiasing = Convert.ToInt32(p["Antialiasing"]); //1"
            this.DisableScreenShake = Convert.ToInt32(p["DisableScreenShake"]); //0"
            this.DisableChromaEffects = Convert.ToInt32(p["DisableChromaEffects"]); //0"
            this.SSAO = Convert.ToInt32(p["SSAO"]); //1"
            this.LockCursorInFullscreenWindowed = Convert.ToInt32(p["LockCursorInFullscreenWindowed"]); //0"
            this.LimitForegroundFPS = Convert.ToInt32(p["LimitForegroundFPS"]); //1"
            this.MaxForegroundFPS = Convert.ToInt32(p["MaxForegroundFPS"]); //150"
            this.LimitBackgroundFPS = Convert.ToInt32(p["LimitBackgroundFPS"]); //1"
            this.MaxBackgroundFPS = Convert.ToInt32(p["MaxBackgroundFPS"]); //8"
            this.DisableTrilinearFiltering = Convert.ToInt32(p["DisableTrilinearFiltering"]); //0"
            this.ColorCorrection = Convert.ToInt32(p["ColorCorrection"]); //1"
            this.MipBias = Convert.ToSingle(p["MipBias"]); //-0.000000"
            this.ReflectionQuality = Convert.ToInt32(p["ReflectionQuality"]); //1"
            this.HardwareClass = Convert.ToInt32(p["HardwareClass"]); //4"
            this.PCIVendor = Convert.ToInt32(p["PCIVendor"]); //0"
            this.PCIDevice = Convert.ToInt32(p["PCIDevice"]); //0"
            this.flSafeZoneLeft = Convert.ToSingle(p["flSafeZoneLeft"]); //0.001746"
            this.flSafeZoneTop = Convert.ToSingle(p["flSafeZoneTop"]); //0.000871"
            this.flSafeZoneRight = Convert.ToSingle(p["flSafeZoneRight"]); //0.998254"
            this.flSafeZoneBottom = Convert.ToSingle(p["flSafeZoneBottom"]); //0.999129"
            this.MasterVolume = Convert.ToSingle(p["MasterVolume"]); //1.000000"
            this.EffectVolume = Convert.ToSingle(p["EffectVolume"]); //0.800000"
            this.MusicVolume = Convert.ToSingle(p["MusicVolume"]); //0.800000"
            this.NarrationVolume = Convert.ToSingle(p["NarrationVolume"]); //0.800000"
            this.AmbientVolume = Convert.ToSingle(p["AmbientVolume"]); //0.800000"
            this.ChannelsToUse = Convert.ToInt32(p["ChannelsToUse"]); //32"
            this.SoundDriver = Convert.ToInt32(p["SoundDriver"]); //0"
            this.SpeakerMode = Convert.ToInt32(p["SpeakerMode"]); //0"
            this.ReverseSpeakers = Convert.ToInt32(p["ReverseSpeakers"]); //0"
            this.QuestSubtitlesEnabled = Convert.ToInt32(p["QuestSubtitlesEnabled"]); //0"
            this.CinematicsSubtitlesEnabled = Convert.ToInt32(p["CinematicsSubtitlesEnabled"]); //0"
            this.PlayInBackground = Convert.ToInt32(p["PlayInBackground"]); //0"
            this.MuteSound = Convert.ToInt32(p["MuteSound"]); //0"
            this.MuteEffects = Convert.ToInt32(p["MuteEffects"]); //0"
            this.MuteAmbient = Convert.ToInt32(p["MuteAmbient"]); //0"
            this.MuteVoice = Convert.ToInt32(p["MuteVoice"]); //0"
            this.MuteMusic = Convert.ToInt32(p["MuteMusic"]); //0"
            this.ItemsOnGroundSetting = Convert.ToInt32(p["ItemsOnGroundSetting"]); //3"
            this.ItemTagsAsIcons = Convert.ToInt32(p["ItemTagsAsIcons"]); //0"
            this.ShowItemTooltipOnDrop = Convert.ToInt32(p["ShowItemTooltipOnDrop"]); //1"
            this.ShowMonsterHPBars = Convert.ToInt32(p["ShowMonsterHPBars"]); //0"
            this.ShowItemsOnGround = Convert.ToInt32(p["ShowItemsOnGround"]); //0"
            this.ShowHPBarNumbers = Convert.ToInt32(p["ShowHPBarNumbers"]); //0"
            this.ShowHealNumbers = Convert.ToInt32(p["ShowHealNumbers"]); //0"
            this.ShowDamageNumbers = Convert.ToInt32(p["ShowDamageNumbers"]); //0"
            this.ShowCriticals = Convert.ToInt32(p["ShowCriticals"]); //1"
            this.ShowDefensiveMessages = Convert.ToInt32(p["ShowDefensiveMessages"]); //1"
            this.InventoryZoom = Convert.ToInt32(p["InventoryZoom"]); //0"
            this.ShowPlayerNames = Convert.ToInt32(p["ShowPlayerNames"]); //0"
            this.ShowPlayerHPBars = Convert.ToInt32(p["ShowPlayerHPBars"]); //0"
            this.AutoEquipItems = Convert.ToInt32(p["AutoEquipItems"]); //1"
            this.EnableSmartCoopMinimap = Convert.ToInt32(p["EnableSmartCoopMinimap"]); //0"
            this.AlwaysShowCampaignObjectives = Convert.ToInt32(p["AlwaysShowCampaignObjectives"]); //0"
            this.AlwaysShowAdventureObjectives = Convert.ToInt32(p["AlwaysShowAdventureObjectives"]); //1"
            this.SelectedTextLocale = Convert.ToInt32(p["SelectedTextLocale"]); //2"
            this.SelectedAudioLocale = Convert.ToInt32(p["SelectedAudioLocale"]); //2"
            this.ShowTutorials = Convert.ToInt32(p["ShowTutorials"]); //1"
            this.ShowBreadCrumbs = Convert.ToInt32(p["ShowBreadCrumbs"]); //1"
            this.ShowClock = Convert.ToInt32(p["ShowClock"]); //1"
            this.ShowAdvancedTooltips = Convert.ToInt32(p["ShowAdvancedTooltips"]); //0"
            this.ElectiveMode = Convert.ToInt32(p["ElectiveMode"]); //0"
            this.DisableCutscenes = Convert.ToInt32(p["DisableCutscenes"]); //0"
            this.ItemRarityIcons = Convert.ToInt32(p["ItemRarityIcons"]); //0"
            this.DisableShortFloatingNumbers = Convert.ToInt32(p["DisableShortFloatingNumbers"]); //0"
            this.EquipmentManagerDropToStash = Convert.ToInt32(p["EquipmentManagerDropToStash"]); //1"
            this.DisableOSShortcuts = Convert.ToInt32(p["DisableOSShortcuts"]); //0"
            this.UseCommandAsControl = Convert.ToInt32(p["UseCommandAsControl"]); //0"
            this.UseCommandClickAsRightClick = Convert.ToInt32(p["UseCommandClickAsRightClick"]); //0"
            this.NotifyFriendOnline = Convert.ToInt32(p["NotifyFriendOnline"]); //1"
            this.NotifyFriendOffline = Convert.ToInt32(p["NotifyFriendOffline"]); //0"
            this.NotifyFriendRequest = Convert.ToInt32(p["NotifyFriendRequest"]); //1"
            this.NotifyFriendAchievement = Convert.ToInt32(p["NotifyFriendAchievement"]); //1"
            this.NotifyDisplayWindow = Convert.ToInt32(p["NotifyDisplayWindow"]); //1"
            this.NotifyDuration = Convert.ToInt32(p["NotifyDuration"]); //1"
            this.AllowQuickJoin = Convert.ToInt32(p["AllowQuickJoin"]); //1"
            this.NotifyAuctionHouseEvent = Convert.ToInt32(p["NotifyAuctionHouseEvent"]); //1"
            this.NotifyFriendBroadcastDisabled = Convert.ToInt32(p["NotifyFriendBroadcastDisabled"]); //0"
            this.ShowLocalPlayersListDisabled = Convert.ToInt32(p["ShowLocalPlayersListDisabled"]); //0"
            this.NotifyGuildMemberOnlineDisabled = Convert.ToInt32(p["NotifyGuildMemberOnlineDisabled"]); //0"
            this.NotifyGuildAchievementDisabled = Convert.ToInt32(p["NotifyGuildAchievementDisabled"]); //0"
            this.MatureLanguageFilter = Convert.ToInt32(p["MatureLanguageFilter"]); //1"
            this.EchoQuestDialogToChat = Convert.ToInt32(p["EchoQuestDialogToChat"]); //1"
            this.KeybindingVersion = Convert.ToInt32(p["KeybindingVersion"]); //4"
            this.MatchmakeRegionOverride = Convert.ToInt32(p["MatchmakeRegionOverride"]); //0"
            this.MatchmakeRegionStrict = Convert.ToInt32(p["MatchmakeRegionStrict"]); //1"
            this.MatchmakeLanguageStrict = Convert.ToInt32(p["MatchmakeLanguageStrict"]); //0"
        }

        public int PreferencesVersion { get; set; } //46"
        public int PlayedCutscene0 { get; set; } //1"
        public int PlayedCutscene1 { get; set; } //0"
        public int PlayedCutscene2 { get; set; } //0"
        public int PlayedCutscene3 { get; set; } //0"
        public int PlayedCutscene4 { get; set; } //0"
        public int FirstTimeFlowCompleted { get; set; } //1"
        public float WhatsNewSeen { get; set; } //2.600000"
        public int AnniversarySeen { get; set; } //0"
        public int LeaderboardSeenSeason { get; set; } //0"
        public int SeasonTutorialsSeen { get; set; } //0"
        public int EulaAcceptedNX64 { get; set; } //0"
        public int WhatsNewSeenNX64 { get; set; } //1"
        public int DisplayModeFlags { get; set; } //10"
        public int DisplayModeWindowMode { get; set; } //0"
        public int DisplayModeWinLeft { get; set; } //0"
        public int DisplayModeWinTop { get; set; } //0"
        public int DisplayModeWinWidth { get; set; } //1024"
        public int DisplayModeWinHeight { get; set; } //768"
        public int DisplayModeUIOptWidth { get; set; } //1024"
        public int DisplayModeUIOptHeight { get; set; } //768"
        public int DisplayModeWidth { get; set; } //1024"
        public int DisplayModeHeight { get; set; } //768"
        public int DisplayModeRefreshRate { get; set; } //60"
        public int DisplayModeBitDepth { get; set; } //32"
        public int DisplayModeMSAALevel { get; set; } //0"
        public float Gamma { get; set; } //1.500000"
        public int MipOffset { get; set; } //0"
        public int ShadowQuality { get; set; } //6"
        public int ShadowDetail { get; set; } //1"
        public int PhysicsQuality { get; set; } //1"
        public int ClutterQuality { get; set; } //3"
        public int Vsync { get; set; } //1"
        public int LargeCursor { get; set; } //0"
        public int Letterbox { get; set; } //0"
        public int Antialiasing { get; set; } //1"
        public int DisableScreenShake { get; set; } //0"
        public int DisableChromaEffects { get; set; } //0"
        public int SSAO { get; set; } //1"
        public int LockCursorInFullscreenWindowed { get; set; } //0"
        public int LimitForegroundFPS { get; set; } //1"
        public int MaxForegroundFPS { get; set; } //150"
        public int LimitBackgroundFPS { get; set; } //1"
        public int MaxBackgroundFPS { get; set; } //8"
        public int DisableTrilinearFiltering { get; set; } //0"
        public int ColorCorrection { get; set; } //1"
        public float MipBias { get; set; } //-0.000000"
        public int ReflectionQuality { get; set; } //1"
        public int HardwareClass { get; set; } //4"
        public int PCIVendor { get; set; } //0"
        public int PCIDevice { get; set; } //0"
        public float flSafeZoneLeft { get; set; } //0.001746"
        public float flSafeZoneTop { get; set; } //0.000871"
        public float flSafeZoneRight { get; set; } //0.998254"
        public float flSafeZoneBottom { get; set; } //0.999129"
        public float MasterVolume { get; set; } //1.000000"
        public float EffectVolume { get; set; } //0.800000"
        public float MusicVolume { get; set; } //0.800000"
        public float NarrationVolume { get; set; } //0.800000"
        public float AmbientVolume { get; set; } //0.800000"
        public int ChannelsToUse { get; set; } //32"
        public int SoundDriver { get; set; } //0"
        public int SpeakerMode { get; set; } //0"
        public int ReverseSpeakers { get; set; } //0"
        public int QuestSubtitlesEnabled { get; set; } //0"
        public int CinematicsSubtitlesEnabled { get; set; } //0"
        public int PlayInBackground { get; set; } //0"
        public int MuteSound { get; set; } //0"
        public int MuteEffects { get; set; } //0"
        public int MuteAmbient { get; set; } //0"
        public int MuteVoice { get; set; } //0"
        public int MuteMusic { get; set; } //0"
        public int ItemsOnGroundSetting { get; set; } //3"
        public int ItemTagsAsIcons { get; set; } //0"
        public int ShowItemTooltipOnDrop { get; set; } //1"
        public int ShowMonsterHPBars { get; set; } //0"
        public int ShowItemsOnGround { get; set; } //0"
        public int ShowHPBarNumbers { get; set; } //0"
        public int ShowHealNumbers { get; set; } //0"
        public int ShowDamageNumbers { get; set; } //0"
        public int ShowCriticals { get; set; } //1"
        public int ShowDefensiveMessages { get; set; } //1"
        public int InventoryZoom { get; set; } //0"
        public int ShowPlayerNames { get; set; } //0"
        public int ShowPlayerHPBars { get; set; } //0"
        public int AutoEquipItems { get; set; } //1"
        public int EnableSmartCoopMinimap { get; set; } //0"
        public int AlwaysShowCampaignObjectives { get; set; } //0"
        public int AlwaysShowAdventureObjectives { get; set; } //1"
        public int SelectedTextLocale { get; set; } //2"
        public int SelectedAudioLocale { get; set; } //2"
        public int ShowTutorials { get; set; } //1"
        public int ShowBreadCrumbs { get; set; } //1"
        public int ShowClock { get; set; } //1"
        public int ShowAdvancedTooltips { get; set; } //0"
        public int ElectiveMode { get; set; } //0"
        public int DisableCutscenes { get; set; } //0"
        public int ItemRarityIcons { get; set; } //0"
        public int DisableShortFloatingNumbers { get; set; } //0"
        public int EquipmentManagerDropToStash { get; set; } //1"
        public int DisableOSShortcuts { get; set; } //0"
        public int UseCommandAsControl { get; set; } //0"
        public int UseCommandClickAsRightClick { get; set; } //0"
        public int NotifyFriendOnline { get; set; } //1"
        public int NotifyFriendOffline { get; set; } //0"
        public int NotifyFriendRequest { get; set; } //1"
        public int NotifyFriendAchievement { get; set; } //1"
        public int NotifyDisplayWindow { get; set; } //1"
        public int NotifyDuration { get; set; } //1"
        public int AllowQuickJoin { get; set; } //1"
        public int NotifyAuctionHouseEvent { get; set; } //1"
        public int NotifyFriendBroadcastDisabled { get; set; } //0"
        public int ShowLocalPlayersListDisabled { get; set; } //0"
        public int NotifyGuildMemberOnlineDisabled { get; set; } //0"
        public int NotifyGuildAchievementDisabled { get; set; } //0"
        public int MatureLanguageFilter { get; set; } //1"
        public int EchoQuestDialogToChat { get; set; } //1"
        public int KeybindingVersion { get; set; } //4"
        public int MatchmakeRegionOverride { get; set; } //0"
        public int MatchmakeRegionStrict { get; set; } //1"
        public int MatchmakeLanguageStrict { get; set; } //0"

    }
}
