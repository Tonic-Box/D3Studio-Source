
using PB.OnlineService;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.Account
{
    [ProtoContract(Name = "Digest")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class Digest : IExtensible
    {
        private uint _version;
        private EntityId _last_played_hero_id;
        private BannerConfiguration _banner_configuration;
        private uint _flags = 0;
        private ulong _pvp_cooldown = 0;
        private int _unknown_6 = 0;
        private uint _season_id = 0;
        private ulong _guild_id = 0;
        private List<uint> _alt_levels = new List<uint>();
        private IExtension extensionObject;

        [ProtoMember(1, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "version")]
        public uint version
        {
            get => this._version;
            set => this._version = value;
        }

        [ProtoMember(2, DataFormat = DataFormat.Default, IsRequired = true, Name = "last_played_hero_id")]
        public EntityId last_played_hero_id
        {
            get => this._last_played_hero_id;
            set => this._last_played_hero_id = value;
        }

        [ProtoMember(3, DataFormat = DataFormat.Default, IsRequired = true, Name = "banner_configuration")]
        public BannerConfiguration banner_configuration
        {
            get => this._banner_configuration;
            set => this._banner_configuration = value;
        }

        [ProtoMember(4, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "flags")]
        [DefaultValue(0)]
        public uint flags
        {
            get => this._flags;
            set => this._flags = value;
        }

        [ProtoMember(5, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "pvp_cooldown")]
        [DefaultValue(0.0f)]
        public ulong pvp_cooldown
        {
            get => this._pvp_cooldown;
            set => this._pvp_cooldown = value;
        }

        [ProtoMember(6, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "unknown_6")]
        [DefaultValue(0)]
        public int unknown_6
        {
            get => this._unknown_6;
            set => this._unknown_6 = value;
        }

        [ProtoMember(7, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "season_id")]
        [DefaultValue(0)]
        public uint season_id
        {
            get => this._season_id;
            set => this._season_id = value;
        }

        [ProtoMember(8, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "guild_id")]
        [DefaultValue(0.0f)]
        public ulong guild_id
        {
            get => this._guild_id;
            set => this._guild_id = value;
        }

        [ProtoMember(9, DataFormat = DataFormat.TwosComplement, Name = "alt_levels")]
        public List<uint> alt_levels
        {
            get => this._alt_levels;
            set => this._alt_levels = value;
        }
        
        [ProtoMember(10, DataFormat = DataFormat.TwosComplement, Name = "stash_tabs_rewarded_from_seasons")]
        [DefaultValue(0)]

        public int stash_tabs_rewarded_from_seasons { get; set; }

        [ProtoMember(11, DataFormat = DataFormat.Default, IsRequired = false, Name = "rebirths_used")]
        [DefaultValue(0)]
        public int rebirths_used { get; set; }

        [ProtoMember(12, DataFormat = DataFormat.Default, IsRequired = false, Name = "patch_version")]
        [DefaultValue("")]
        public string patch_version { get; set; }

        private _unknown_13 _challenge_rift_account_data = new _unknown_13();

        [ProtoMember(13, DataFormat = DataFormat.Default, IsRequired = false, Name = "challenge_rift_account_data")]
        [DefaultValue(null)]
        public _unknown_13 challenge_rift_account_data
        {
            get => this._challenge_rift_account_data;
            set => this._challenge_rift_account_data = value;
        }

        [ProtoMember(14, DataFormat = DataFormat.Default, IsRequired = false, Name = "completed_solo_rift")]
        [DefaultValue(false)]
        public bool completed_solo_rift { get; set; }

        [ProtoMember(15, DataFormat = DataFormat.Default, IsRequired = false, Name = "last_publish_time")]
        [DefaultValue(0)]
        public int last_publish_time { get; set; }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }


        [ProtoContract(Name = "Flags")]
        public enum Flags
        {
            [ProtoEnum(Name = "HARDCORE_HERO_UNLOCKED_DEPRECATED", Value = 1)] HARDCORE_HERO_UNLOCKED_DEPRECATED = 1,
            [ProtoEnum(Name = "ADVENTURE_MODE_UNLOCKED", Value = 2)] ADVENTURE_MODE_UNLOCKED = 2,
            [ProtoEnum(Name = "PARAGON_100_VANILLA_FEAT", Value = 3)] PARAGON_100_VANILLA_FEAT = 3,
            [ProtoEnum(Name = "MASTER_DIFFICULTY_UNLOCKED", Value = 4)] MASTER_DIFFICULTY_UNLOCKED = 4,
            [ProtoEnum(Name = "TORMENT_DIFFICULTY_UNLOCKED", Value = 5)] TORMENT_DIFFICULTY_UNLOCKED = 5,
            [ProtoEnum(Name = "ADVENTURE_MODE_TUTORIAL_PLAYED", Value = 6)] ADVENTURE_MODE_TUTORIAL_PLAYED = 6,
            [ProtoEnum(Name = "HARDCORE_MASTER_DIFFICULTY_UNLOCKED", Value = 7)] HARDCORE_MASTER_DIFFICULTY_UNLOCKED = 7,
            [ProtoEnum(Name = "HARDCORE_TORMENT_DIFFICULTY_UNLOCKED", Value = 8)] HARDCORE_TORMENT_DIFFICULTY_UNLOCKED = 8,
            [ProtoEnum(Name = "HARDCORE_ADVENTURE_MODE_UNLOCKED", Value = 9)] HARDCORE_ADVENTURE_MODE_UNLOCKED = 9,
        }
    }

    [ProtoContract(Name = "_unknown_13")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class _unknown_13 : IExtensible
    {
        private IExtension extensionObject;

        [ProtoMember(1, DataFormat = DataFormat.Default, Name = "field_1")]
        [DefaultValue(0)]
        public long field_1 { get; set; }

        private List<_field_3_entry> _field_3_data = new List<_field_3_entry>();

        [ProtoMember(3, DataFormat = DataFormat.Default, Name = "field_3")]
        [DefaultValue(null)]
        public List<_field_3_entry> field_3
        {
            get => this._field_3_data;
            set => this._field_3_data = value;
        }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }

    [ProtoContract(Name = "_field_3_entry")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class _field_3_entry : IExtensible
    {
        private IExtension extensionObject;

        [ProtoMember(1, DataFormat = DataFormat.Default, Name = "field_1")]
        [DefaultValue(null)]
        public byte[] field_1 { get; set; }

        [ProtoMember(3, DataFormat = DataFormat.Default, Name = "field_3")]
        [DefaultValue(null)]
        public byte[] field_3 { get; set; }

        [ProtoMember(4, DataFormat = DataFormat.Default, Name = "field_4")]
        [DefaultValue(0)]
        public long field_4 { get; set; }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
