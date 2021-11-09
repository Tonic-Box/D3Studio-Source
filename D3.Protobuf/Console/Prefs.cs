
namespace PB.Console
{
  public class Prefs
  {
    private int preferencesversion;
    private int playedcutscene0;
    private int playedcutscene1;
    private int playedcutscene2;
    private int playedcutscene3;
    private int playedcutscene4;
    private int firsttimeflowcompleted;
    private int displaymodeflags;
    private int displaymodewindowmode;
    private int displaymodewinleft;
    private int displaymodewintop;
    private int displaymodewinwidth;
    private int displaymodewinheight;
    private int displaymodeuioptwidth;
    private int displaymodeuioptheight;
    private int displaymodewidth;
    private int displaymodeheight;
    private int displaymoderefreshrate;
    private int displaymodebitdepth;
    private double gamma;
    private int mipoffset;
    private int shadowquality;
    private int shadowdetail;
    private int physicsquality;
    private int clutterquality;
    private int vsync;
    private int letterbox;
    private int antialiasing;
    private int lockcursorinfullscreenwindowed;
    private int limitforegroundfps;
    private int maxforegroundfps;
    private int limitbackgroundfps;
    private int maxbackgroundfps;
    private int disabletrilinearfiltering;
    private int colorcorrection;
    private double mipbias;
    private int reflectionquality;
    private int hardwareclass;
    private int pcivendor;
    private int pcidevice;
    private double flsafezoneleft;
    private double flsafezonetop;
    private double flsafezoneright;
    private double flsafezonebottom;
    private double mastervolume;
    private double effectvolume;
    private double musicvolume;
    private double narrationvolume;
    private double ambientvolume;
    private int channelstouse;
    private int sounddriver;
    private int speakermode;
    private int reversespeakers;
    private int questsubtitlesenabled;
    private int cinematicssubtitlesenabled;
    private int playinbackground;
    private int mutesound;
    private int muteeffects;
    private int muteambient;
    private int mutevoice;
    private int mutemusic;
    private int itemsongroundsetting;
    private int itemtagsasicons;
    private int showitemtooltipondrop;
    private int showmonsterhpbars;
    private int showitemsonground;
    private int showhpbarnumbers;
    private int showhealnumbers;
    private int showdamagenumbers;
    private int showcriticals;
    private int showdefensivemessages;
    private int inventoryzoom;
    private int showplayernames;
    private int showplayerhpbars;
    private int autoequipitems;
    private int enablesmartcoopminimap;
    private int alwaysshowcampaignobjectives;
    private int alwaysshowadventureobjectives;
    private int showtutorials;
    private int showbreadcrumbs;
    private int showclock;
    private int showadvancedtooltips;
    private int electivemode;
    private int disablecutscenes;
    private int disableosshortcuts;
    private int usecommandascontrol;
    private int usecommandclickasrightclick;
    private int notifyfriendonline;
    private int notifyfriendoffline;
    private int notifyfriendrequest;
    private int notifyfriendachievement;
    private int notifydisplaywindow;
    private int notifyduration;
    private int allowquickjoin;
    private int notifyauctionhouseevent;
    private int notifyfriendbroadcastdisabled;
    private int showlocalplayerslistdisabled;
    private int notifyguildmemberonlinedisabled;
    private int maturelanguagefilter;
    private int echoquestdialogtochat;
    private int keybindingversion;
    private int matchmakeregionoverride;
    private int matchmakeregionstrict;
    private int matchmakelanguagestrict;

    public int PreferencesVersion
    {
      get => this.preferencesversion;
      set => this.preferencesversion = value;
    }

    public int PlayedCutscene0
    {
      get => this.playedcutscene0;
      set => this.playedcutscene0 = value;
    }

    public int PlayedCutscene1
    {
      get => this.playedcutscene1;
      set => this.playedcutscene1 = value;
    }

    public int PlayedCutscene2
    {
      get => this.playedcutscene2;
      set => this.playedcutscene2 = value;
    }

    public int PlayedCutscene3
    {
      get => this.playedcutscene3;
      set => this.playedcutscene3 = value;
    }

    public int PlayedCutscene4
    {
      get => this.playedcutscene4;
      set => this.playedcutscene4 = value;
    }

    public int FirstTimeFlowCompleted
    {
      get => this.firsttimeflowcompleted;
      set => this.firsttimeflowcompleted = value;
    }

    public int DisplayModeFlags
    {
      get => this.displaymodeflags;
      set => this.displaymodeflags = value;
    }

    public int DisplayModeWindowMode
    {
      get => this.displaymodewindowmode;
      set => this.displaymodewindowmode = value;
    }

    public int DisplayModeWinLeft
    {
      get => this.displaymodewinleft;
      set => this.displaymodewinleft = value;
    }

    public int DisplayModeWinTop
    {
      get => this.displaymodewintop;
      set => this.displaymodewintop = value;
    }

    public int DisplayModeWinWidth
    {
      get => this.displaymodewinwidth;
      set => this.displaymodewinwidth = value;
    }

    public int DisplayModeWinHeight
    {
      get => this.displaymodewinheight;
      set => this.displaymodewinheight = value;
    }

    public int DisplayModeUIOptWidth
    {
      get => this.displaymodeuioptwidth;
      set => this.displaymodeuioptwidth = value;
    }

    public int DisplayModeUIOptHeight
    {
      get => this.displaymodeuioptheight;
      set => this.displaymodeuioptheight = value;
    }

    public int DisplayModeWidth
    {
      get => this.displaymodewidth;
      set => this.displaymodewidth = value;
    }

    public int DisplayModeHeight
    {
      get => this.displaymodeheight;
      set => this.displaymodeheight = value;
    }

    public int DisplayModeRefreshRate
    {
      get => this.displaymoderefreshrate;
      set => this.displaymoderefreshrate = value;
    }

    public int DisplayModeBitDepth
    {
      get => this.displaymodebitdepth;
      set => this.displaymodebitdepth = value;
    }

    public double Gamma
    {
      get => this.gamma;
      set => this.gamma = value;
    }

    public int MipOffset
    {
      get => this.mipoffset;
      set => this.mipoffset = value;
    }

    public int ShadowQuality
    {
      get => this.shadowquality;
      set => this.shadowquality = value;
    }

    public int ShadowDetail
    {
      get => this.shadowdetail;
      set => this.shadowdetail = value;
    }

    public int PhysicsQuality
    {
      get => this.physicsquality;
      set => this.physicsquality = value;
    }

    public int ClutterQuality
    {
      get => this.clutterquality;
      set => this.clutterquality = value;
    }

    public int Vsync
    {
      get => this.vsync;
      set => this.vsync = value;
    }

    public int Letterbox
    {
      get => this.letterbox;
      set => this.letterbox = value;
    }

    public int Antialiasing
    {
      get => this.antialiasing;
      set => this.antialiasing = value;
    }

    public int LockCursorInFullscreenWindowed
    {
      get => this.lockcursorinfullscreenwindowed;
      set => this.lockcursorinfullscreenwindowed = value;
    }

    public int LimitForegroundFPS
    {
      get => this.limitforegroundfps;
      set => this.limitforegroundfps = value;
    }

    public int MaxForegroundFPS
    {
      get => this.maxforegroundfps;
      set => this.maxforegroundfps = value;
    }

    public int LimitBackgroundFPS
    {
      get => this.limitbackgroundfps;
      set => this.limitbackgroundfps = value;
    }

    public int MaxBackgroundFPS
    {
      get => this.maxbackgroundfps;
      set => this.maxbackgroundfps = value;
    }

    public int DisableTrilinearFiltering
    {
      get => this.disabletrilinearfiltering;
      set => this.disabletrilinearfiltering = value;
    }

    public int ColorCorrection
    {
      get => this.colorcorrection;
      set => this.colorcorrection = value;
    }

    public double MipBias
    {
      get => this.mipbias;
      set => this.mipbias = value;
    }

    public int ReflectionQuality
    {
      get => this.reflectionquality;
      set => this.reflectionquality = value;
    }

    public int HardwareClass
    {
      get => this.hardwareclass;
      set => this.hardwareclass = value;
    }

    public int PCIVendor
    {
      get => this.pcivendor;
      set => this.pcivendor = value;
    }

    public int PCIDevice
    {
      get => this.pcidevice;
      set => this.pcidevice = value;
    }

    public double flSafeZoneLeft
    {
      get => this.flsafezoneleft;
      set => this.flsafezoneleft = value;
    }

    public double flSafeZoneTop
    {
      get => this.flsafezonetop;
      set => this.flsafezonetop = value;
    }

    public double flSafeZoneRight
    {
      get => this.flsafezoneright;
      set => this.flsafezoneright = value;
    }

    public double flSafeZoneBottom
    {
      get => this.flsafezonebottom;
      set => this.flsafezonebottom = value;
    }

    public double MasterVolume
    {
      get => this.mastervolume;
      set => this.mastervolume = value;
    }

    public double EffectVolume
    {
      get => this.effectvolume;
      set => this.effectvolume = value;
    }

    public double MusicVolume
    {
      get => this.musicvolume;
      set => this.musicvolume = value;
    }

    public double NarrationVolume
    {
      get => this.narrationvolume;
      set => this.narrationvolume = value;
    }

    public double AmbientVolume
    {
      get => this.ambientvolume;
      set => this.ambientvolume = value;
    }

    public int ChannelsToUse
    {
      get => this.channelstouse;
      set => this.channelstouse = value;
    }

    public int SoundDriver
    {
      get => this.sounddriver;
      set => this.sounddriver = value;
    }

    public int SpeakerMode
    {
      get => this.speakermode;
      set => this.speakermode = value;
    }

    public int ReverseSpeakers
    {
      get => this.reversespeakers;
      set => this.reversespeakers = value;
    }

    public int QuestSubtitlesEnabled
    {
      get => this.questsubtitlesenabled;
      set => this.questsubtitlesenabled = value;
    }

    public int CinematicsSubtitlesEnabled
    {
      get => this.cinematicssubtitlesenabled;
      set => this.cinematicssubtitlesenabled = value;
    }

    public int PlayInBackground
    {
      get => this.playinbackground;
      set => this.playinbackground = value;
    }

    public int MuteSound
    {
      get => this.mutesound;
      set => this.mutesound = value;
    }

    public int MuteEffects
    {
      get => this.muteeffects;
      set => this.muteeffects = value;
    }

    public int MuteAmbient
    {
      get => this.muteambient;
      set => this.muteambient = value;
    }

    public int MuteVoice
    {
      get => this.mutevoice;
      set => this.mutevoice = value;
    }

    public int MuteMusic
    {
      get => this.mutemusic;
      set => this.mutemusic = value;
    }

    public int ItemsOnGroundSetting
    {
      get => this.itemsongroundsetting;
      set => this.itemsongroundsetting = value;
    }

    public int ItemTagsAsIcons
    {
      get => this.itemtagsasicons;
      set => this.itemtagsasicons = value;
    }

    public int ShowItemTooltipOnDrop
    {
      get => this.showitemtooltipondrop;
      set => this.showitemtooltipondrop = value;
    }

    public int ShowMonsterHPBars
    {
      get => this.showmonsterhpbars;
      set => this.showmonsterhpbars = value;
    }

    public int ShowItemsOnGround
    {
      get => this.showitemsonground;
      set => this.showitemsonground = value;
    }

    public int ShowHPBarNumbers
    {
      get => this.showhpbarnumbers;
      set => this.showhpbarnumbers = value;
    }

    public int ShowHealNumbers
    {
      get => this.showhealnumbers;
      set => this.showhealnumbers = value;
    }

    public int ShowDamageNumbers
    {
      get => this.showdamagenumbers;
      set => this.showdamagenumbers = value;
    }

    public int ShowCriticals
    {
      get => this.showcriticals;
      set => this.showcriticals = value;
    }

    public int ShowDefensiveMessages
    {
      get => this.showdefensivemessages;
      set => this.showdefensivemessages = value;
    }

    public int InventoryZoom
    {
      get => this.inventoryzoom;
      set => this.inventoryzoom = value;
    }

    public int ShowPlayerNames
    {
      get => this.showplayernames;
      set => this.showplayernames = value;
    }

    public int ShowPlayerHPBars
    {
      get => this.showplayerhpbars;
      set => this.showplayerhpbars = value;
    }

    public int AutoEquipItems
    {
      get => this.autoequipitems;
      set => this.autoequipitems = value;
    }

    public int EnableSmartCoopMinimap
    {
      get => this.enablesmartcoopminimap;
      set => this.enablesmartcoopminimap = value;
    }

    public int AlwaysShowCampaignObjectives
    {
      get => this.alwaysshowcampaignobjectives;
      set => this.alwaysshowcampaignobjectives = value;
    }

    public int AlwaysShowAdventureObjectives
    {
      get => this.alwaysshowadventureobjectives;
      set => this.alwaysshowadventureobjectives = value;
    }

    public int ShowTutorials
    {
      get => this.showtutorials;
      set => this.showtutorials = value;
    }

    public int ShowBreadCrumbs
    {
      get => this.showbreadcrumbs;
      set => this.showbreadcrumbs = value;
    }

    public int ShowClock
    {
      get => this.showclock;
      set => this.showclock = value;
    }

    public int ShowAdvancedTooltips
    {
      get => this.showadvancedtooltips;
      set => this.showadvancedtooltips = value;
    }

    public int ElectiveMode
    {
      get => this.electivemode;
      set => this.electivemode = value;
    }

    public int DisableCutscenes
    {
      get => this.disablecutscenes;
      set => this.disablecutscenes = value;
    }

    public int DisableOSShortcuts
    {
      get => this.disableosshortcuts;
      set => this.disableosshortcuts = value;
    }

    public int UseCommandAsControl
    {
      get => this.usecommandascontrol;
      set => this.usecommandascontrol = value;
    }

    public int UseCommandClickAsRightClick
    {
      get => this.usecommandclickasrightclick;
      set => this.usecommandclickasrightclick = value;
    }

    public int NotifyFriendOnline
    {
      get => this.notifyfriendonline;
      set => this.notifyfriendonline = value;
    }

    public int NotifyFriendOffline
    {
      get => this.notifyfriendoffline;
      set => this.notifyfriendoffline = value;
    }

    public int NotifyFriendRequest
    {
      get => this.notifyfriendrequest;
      set => this.notifyfriendrequest = value;
    }

    public int NotifyFriendAchievement
    {
      get => this.notifyfriendachievement;
      set => this.notifyfriendachievement = value;
    }

    public int NotifyDisplayWindow
    {
      get => this.notifydisplaywindow;
      set => this.notifydisplaywindow = value;
    }

    public int NotifyDuration
    {
      get => this.notifyduration;
      set => this.notifyduration = value;
    }

    public int AllowQuickJoin
    {
      get => this.allowquickjoin;
      set => this.allowquickjoin = value;
    }

    public int NotifyAuctionHouseEvent
    {
      get => this.notifyauctionhouseevent;
      set => this.notifyauctionhouseevent = value;
    }

    public int NotifyFriendBroadcastDisabled
    {
      get => this.notifyfriendbroadcastdisabled;
      set => this.notifyfriendbroadcastdisabled = value;
    }

    public int ShowLocalPlayersListDisabled
    {
      get => this.showlocalplayerslistdisabled;
      set => this.showlocalplayerslistdisabled = value;
    }

    public int NotifyGuildMemberOnlineDisabled
    {
      get => this.notifyguildmemberonlinedisabled;
      set => this.notifyguildmemberonlinedisabled = value;
    }

    public int MatureLanguageFilter
    {
      get => this.maturelanguagefilter;
      set => this.maturelanguagefilter = value;
    }

    public int EchoQuestDialogToChat
    {
      get => this.echoquestdialogtochat;
      set => this.echoquestdialogtochat = value;
    }

    public int KeybindingVersion
    {
      get => this.keybindingversion;
      set => this.keybindingversion = value;
    }

    public int MatchmakeRegionOverride
    {
      get => this.matchmakeregionoverride;
      set => this.matchmakeregionoverride = value;
    }

    public int MatchmakeRegionStrict
    {
      get => this.matchmakeregionstrict;
      set => this.matchmakeregionstrict = value;
    }

    public int MatchmakeLanguageStrict
    {
      get => this.matchmakelanguagestrict;
      set => this.matchmakelanguagestrict = value;
    }
  }
}
