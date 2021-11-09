
using PB.OnlineService;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.Hero
{
    [ProtoContract(Name = "Digest")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class Digest : IExtensible
    {
        private uint _version;
        private EntityId _hero_id;
        private string _hero_name = "";
        private int _gbid_class;
        private int _level;
        private uint _player_flags;
        private VisualEquipment _visual_equipment;
        private List<QuestHistoryEntry> _quest_history = new List<QuestHistoryEntry>();
        private int _last_played_act;
        private int _highest_unlocked_act;
        private int _last_played_difficulty = 0;
        private int _highest_unlocked_difficulty = 0;
        private int _last_played_quest;
        private int _last_played_quest_step;
        private uint _time_played;
        private int _highest_completed_difficulty = -1;
        private uint _create_time = 0;
        private uint _last_played_time = 0;
        private uint _delete_time = 0;
        private int _alt_level = 0;
        private int _pvp_rank = 0;
        private IExtension extensionObject;

        [ProtoMember(1, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "version")]
        public uint version
        {
            get => this._version;
            set => this._version = value;
        }

        [ProtoMember(2, DataFormat = DataFormat.Default, IsRequired = true, Name = "hero_id")]
        public EntityId hero_id
        {
            get => this._hero_id;
            set => this._hero_id = value;
        }

        [ProtoMember(3, DataFormat = DataFormat.Default, IsRequired = true, Name = "hero_name")]
        [DefaultValue("")]
        public string hero_name
        {
            get => this._hero_name;
            set => this._hero_name = value;
        }

        [ProtoMember(4, DataFormat = DataFormat.FixedSize, IsRequired = true, Name = "gbid_class")]
        public int gbid_class
        {
            get => this._gbid_class;
            set => this._gbid_class = value;
        }

        [ProtoMember(5, DataFormat = DataFormat.ZigZag, IsRequired = true, Name = "level")]
        public int level
        {
            get => this._level;
            set => this._level = value;
        }

        [ProtoMember(6, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "player_flags")]
        public uint player_flags
        {
            get => this._player_flags;
            set => this._player_flags = value;
        }

        [ProtoMember(7, DataFormat = DataFormat.Default, IsRequired = true, Name = "visual_equipment")]
        public VisualEquipment visual_equipment
        {
            get => this._visual_equipment;
            set => this._visual_equipment = value;
        }

        [ProtoMember(8, DataFormat = DataFormat.Default, Name = "quest_history")]
        public List<QuestHistoryEntry> quest_history
        {
            get => this._quest_history;
            set => this._quest_history = value;
        }

        [ProtoMember(9, DataFormat = DataFormat.ZigZag, IsRequired = true, Name = "last_played_act")]
        public int last_played_act
        {
            get => this._last_played_act;
            set => this._last_played_act = value;
        }

        [ProtoMember(10, DataFormat = DataFormat.ZigZag, IsRequired = true, Name = "highest_unlocked_act")]
        public int highest_unlocked_act
        {
            get => this._highest_unlocked_act;
            set => this._highest_unlocked_act = value;
        }

        [ProtoMember(11, DataFormat = DataFormat.ZigZag, IsRequired = true, Name = "last_played_difficulty")]
        [DefaultValue(0)]
        public int last_played_difficulty
        {
            get => this._last_played_difficulty;
            set => this._last_played_difficulty = value;
        }

        [ProtoMember(12, DataFormat = DataFormat.ZigZag, IsRequired = true, Name = "highest_unlocked_difficulty")]
        [DefaultValue(0)]
        public int highest_unlocked_difficulty
        {
            get => this._highest_unlocked_difficulty;
            set => this._highest_unlocked_difficulty = value;
        }

        [ProtoMember(13, DataFormat = DataFormat.FixedSize, IsRequired = true, Name = "last_played_quest")]
        public int last_played_quest
        {
            get => this._last_played_quest;
            set => this._last_played_quest = value;
        }

        [ProtoMember(14, DataFormat = DataFormat.ZigZag, IsRequired = true, Name = "last_played_quest_step")]
        public int last_played_quest_step
        {
            get => this._last_played_quest_step;
            set => this._last_played_quest_step = value;
        }

        [ProtoMember(15, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "time_played")]
        public uint time_played
        {
            get => this._time_played;
            set => this._time_played = value;
        }

        [ProtoMember(16, DataFormat = DataFormat.ZigZag, IsRequired = false, Name = "highest_completed_difficulty")]
        [DefaultValue(-1)]
        public int highest_completed_difficulty
        {
            get => this._highest_completed_difficulty;
            set => this._highest_completed_difficulty = value;
        }

        [ProtoMember(17, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "create_time")]
        [DefaultValue(0)]
        public uint create_time
        {
            get => this._create_time;
            set => this._create_time = value;
        }

        [ProtoMember(18, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "last_played_time")]
        [DefaultValue(0)]
        public uint last_played_time
        {
            get => this._last_played_time;
            set => this._last_played_time = value;
        }

        [ProtoMember(19, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "delete_time")]
        [DefaultValue(0)]
        public uint delete_time
        {
            get => this._delete_time;
            set => this._delete_time = value;
        }

        [ProtoMember(20, DataFormat = DataFormat.ZigZag, IsRequired = false, Name = "alt_level")]
        [DefaultValue(0)]
        public int alt_level
        {
            get => this._alt_level;
            set => this._alt_level = value;
        }

        [ProtoMember(21, DataFormat = DataFormat.ZigZag, IsRequired = true, Name = "pvp_rank")]
        [DefaultValue(0)]
        public int pvp_rank
        {
            get => this._pvp_rank;
            set => this._pvp_rank = value;
        }
        //*
        [ProtoMember(22, DataFormat = DataFormat.Default, IsRequired = true, Name = "season_created")]
        [DefaultValue(null)]
        //*
        [Browsable(true)]
        /*/
        [Browsable(false)]
        //*/
        public int season_created { get; set; }

        [ProtoMember(23, DataFormat = DataFormat.FixedSize, IsRequired = true, Name = "last_played_mode_deprecated")]
        [DefaultValue(null)]
        public int last_played_mode_deprecated { get; set; }

        private EntityId _original_hero_id = new EntityId();

        [ProtoMember(24, DataFormat = DataFormat.FixedSize, IsRequired = true, Name = "original_hero_id")]
        [DefaultValue(null)]
        public EntityId original_hero_id { get; set; }

        [ProtoMember(25, DataFormat = DataFormat.Default, IsRequired = true, Name = "highest_solo_rift_completed")]
        [DefaultValue(null)]
        public int highest_solo_rift_completed { get; set; }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
