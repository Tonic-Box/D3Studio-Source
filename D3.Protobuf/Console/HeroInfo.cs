
using PB.Hero;
using PB.OnlineService;
using PB.Profile;
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.Console
{
    [ProtoContract(Name = "HeroInfo")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class HeroInfo : IExtensible
    {
        private EntityId _hero_id;
        private string _hero_name;
        private int _gbid_class;
        private int _level;
        private int _alt_level;
        private uint _player_flags;
        private int _last_played_act;
        private int _last_played_difficulty = 0;
        private VisualEquipment _visual_equipment;
        private uint _create_time;
        private string _filename;
        private uint _death_time;
        private KillerInfo _killer_info;
        private string _killer_name = "";
        private ulong _monsters_killed;
        private ulong _elites_killed;
        private ulong _gold_collected;
        private uint _time_played = 0;
        private int _highest_unlocked_difficulty = 0;
        private IExtension extensionObject;

        [ProtoMember(1, DataFormat = DataFormat.Default, IsRequired = true, Name = "hero_id")]
        public EntityId hero_id
        {
            get => this._hero_id;
            set => this._hero_id = value;
        }

        [ProtoMember(2, DataFormat = DataFormat.Default, IsRequired = true, Name = "hero_name")]
        public string hero_name
        {
            get => this._hero_name;
            set => this._hero_name = value;
        }

        [ProtoMember(3, DataFormat = DataFormat.FixedSize, IsRequired = true, Name = "gbid_class")]
        public int gbid_class
        {
            get => this._gbid_class;
            set => this._gbid_class = value;
        }

        [ProtoMember(4, DataFormat = DataFormat.ZigZag, IsRequired = true, Name = "level")]
        public int level
        {
            get => this._level;
            set => this._level = value;
        }

        [ProtoMember(5, DataFormat = DataFormat.ZigZag, IsRequired = true, Name = "alt_level")]
        public int alt_level
        {
            get => this._alt_level;
            set => this._alt_level = value;
        }

        [ProtoMember(6, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "player_flags")]
        public uint player_flags
        {
            get => this._player_flags;
            set => this._player_flags = value;
        }

        [ProtoMember(7, DataFormat = DataFormat.ZigZag, IsRequired = true, Name = "last_played_act")]
        public int last_played_act
        {
            get => this._last_played_act;
            set => this._last_played_act = value;
        }

        [ProtoMember(8, DataFormat = DataFormat.ZigZag, IsRequired = false, Name = "last_played_difficulty")]
        [DefaultValue(0)]
        public int last_played_difficulty
        {
            get => this._last_played_difficulty;
            set => this._last_played_difficulty = value;
        }

        [ProtoMember(9, DataFormat = DataFormat.Default, IsRequired = true, Name = "visual_equipment")]
        public VisualEquipment visual_equipment
        {
            get => this._visual_equipment;
            set => this._visual_equipment = value;
        }

        [ProtoMember(10, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "create_time")]
        public uint create_time
        {
            get => this._create_time;
            set => this._create_time = value;
        }

        [ProtoMember(11, DataFormat = DataFormat.Default, IsRequired = true, Name = "filename")]
        public string filename
        {
            get => this._filename;
            set => this._filename = value;
        }

        [ProtoMember(12, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "death_time")]
        public uint death_time
        {
            get => this._death_time;
            set => this._death_time = value;
        }

        [ProtoMember(13, DataFormat = DataFormat.Default, IsRequired = true, Name = "killer_info")]
        public KillerInfo killer_info
        {
            get => this._killer_info;
            set => this._killer_info = value;
        }

        [ProtoMember(14, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "monsters_killed")]
        public ulong monsters_killed
        {
            get => this._monsters_killed;
            set => this._monsters_killed = value;
        }

        [ProtoMember(15, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "gold_collected")]
        public ulong gold_collected
        {
            get => this._gold_collected;
            set => this._gold_collected = value;
        }

        [ProtoMember(16, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "elites_killed")]
        public ulong elites_killed
        {
            get => this._elites_killed;
            set => this._elites_killed = value;
        }

        [ProtoMember(17, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "time_played")]
        [DefaultValue(0)]
        public uint time_played
        {
            get => this._time_played;
            set => this._time_played = value;
        }

        [ProtoMember(18, DataFormat = DataFormat.ZigZag, IsRequired = false, Name = "highest_unlocked_difficulty")]
        [DefaultValue(0)]
        public int highest_unlocked_difficulty
        {
            get => this._highest_unlocked_difficulty;
            set => this._highest_unlocked_difficulty = value;
        }

        [ProtoMember(19, DataFormat = DataFormat.Default, IsRequired = false, Name = "killer_name")]
        [DefaultValue("")]
        public string killer_name
        {
            get => this._killer_name;
            set => this._killer_name = value;
        }

        [ProtoMember(20, DataFormat = DataFormat.Default, IsRequired = true, Name = "season_created")]
        [DefaultValue(null)]
        public int season_created { get; set; }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
