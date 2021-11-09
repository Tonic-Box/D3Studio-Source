
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.Profile
{
    [ProtoContract(Name = "AccountProfile")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class AccountProfile : IExtensible
    {
        private uint _highest_difficulty = 0;
        private uint _highest_boss_difficulty_1 = 0;
        private uint _highest_boss_difficulty_2 = 0;
        private uint _highest_boss_difficulty_3 = 0;
        private uint _highest_boss_difficulty_4 = 0;
        private ulong _monsters_killed = 0;
        private ulong _elites_killed = 0;
        private ulong _gold_collected = 0;
        private ulong _highest_hardcore_level = 0;
        private ulong _hardcore_monsters_killed = 0;
        private ClassInfo _class_barbarian = (ClassInfo)null;
        private ClassInfo _class_demonhunter = (ClassInfo)null;
        private ClassInfo _class_monk = (ClassInfo)null;
        private ClassInfo _class_witchdoctor = (ClassInfo)null;
        private ClassInfo _class_wizard = (ClassInfo)null;
        private ClassInfo _class_crusader = (ClassInfo)null;
        private ClassInfo _class_necromancer = (ClassInfo)null;
        private uint _pvp_wins = 0;
        private uint _pvp_takedowns = 0;
        private ulong _pvp_damage = 0;
        private uint _season_id = 0;
        private uint _highest_boss_difficulty_5 = 0;
        private uint _deprecated_best_ladder_paragon_level = 0;
        private uint _paragon_level = 0;
        private ulong _paragon_xp_next = 0;
        private List<uint> _seasons = new List<uint>();
        private uint _paragon_level_hardcore = 0;
        private ulong _paragon_xp_next_hardcore = 0;
        private uint _bounties_completed = 0;
        private uint _loot_runs_completed = 0;
        private ulong _highest_level = 0;
        private ulong _blood_shards_collected = 0;
        private List<HeroMiniProfile> _heroes = new List<HeroMiniProfile>();
        private List<uint> _leaderboard_eras_with_scores = new List<uint>();
        private uint _num_fallen_heroes = 0;
        private IExtension extensionObject;

        [ProtoMember(1, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "highest_difficulty")]
        [DefaultValue(0)]
        public uint highest_difficulty
        {
            get => this._highest_difficulty;
            set => this._highest_difficulty = value;
        }

        [ProtoMember(2, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "highest_boss_difficulty_1")]
        [DefaultValue(0)]
        public uint highest_boss_difficulty_1
        {
            get => this._highest_boss_difficulty_1;
            set => this._highest_boss_difficulty_1 = value;
        }

        [ProtoMember(3, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "highest_boss_difficulty_2")]
        [DefaultValue(0)]
        public uint highest_boss_difficulty_2
        {
            get => this._highest_boss_difficulty_2;
            set => this._highest_boss_difficulty_2 = value;
        }

        [ProtoMember(4, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "highest_boss_difficulty_3")]
        [DefaultValue(0)]
        public uint highest_boss_difficulty_3
        {
            get => this._highest_boss_difficulty_3;
            set => this._highest_boss_difficulty_3 = value;
        }

        [ProtoMember(5, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "highest_boss_difficulty_4")]
        [DefaultValue(0)]
        public uint highest_boss_difficulty_4
        {
            get => this._highest_boss_difficulty_4;
            set => this._highest_boss_difficulty_4 = value;
        }

        [ProtoMember(6, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "monsters_killed")]
        [DefaultValue(0.0f)]
        public ulong monsters_killed
        {
            get => this._monsters_killed;
            set => this._monsters_killed = value;
        }

        [ProtoMember(7, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "elites_killed")]
        [DefaultValue(0.0f)]
        public ulong elites_killed
        {
            get => this._elites_killed;
            set => this._elites_killed = value;
        }

        [ProtoMember(8, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "gold_collected")]
        [DefaultValue(0.0f)]
        public ulong gold_collected
        {
            get => this._gold_collected;
            set => this._gold_collected = value;
        }

        [ProtoMember(9, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "highest_hardcore_level")]
        [DefaultValue(0.0f)]
        public ulong highest_hardcore_level
        {
            get => this._highest_hardcore_level;
            set => this._highest_hardcore_level = value;
        }

        [ProtoMember(10, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "hardcore_monsters_killed")]
        [DefaultValue(0.0f)]
        public ulong hardcore_monsters_killed
        {
            get => this._hardcore_monsters_killed;
            set => this._hardcore_monsters_killed = value;
        }

        [ProtoMember(11, DataFormat = DataFormat.Default, IsRequired = false, Name = "class_barbarian")]
        [DefaultValue(null)]
        public ClassInfo class_barbarian
        {
            get => this._class_barbarian;
            set => this._class_barbarian = value;
        }

        [ProtoMember(12, DataFormat = DataFormat.Default, IsRequired = false, Name = "class_demonhunter")]
        [DefaultValue(null)]
        public ClassInfo class_demonhunter
        {
            get => this._class_demonhunter;
            set => this._class_demonhunter = value;
        }

        [ProtoMember(13, DataFormat = DataFormat.Default, IsRequired = false, Name = "class_monk")]
        [DefaultValue(null)]
        public ClassInfo class_monk
        {
            get => this._class_monk;
            set => this._class_monk = value;
        }

        [ProtoMember(14, DataFormat = DataFormat.Default, IsRequired = false, Name = "class_witchdoctor")]
        [DefaultValue(null)]
        public ClassInfo class_witchdoctor
        {
            get => this._class_witchdoctor;
            set => this._class_witchdoctor = value;
        }

        [ProtoMember(15, DataFormat = DataFormat.Default, IsRequired = false, Name = "class_wizard")]
        [DefaultValue(null)]
        public ClassInfo class_wizard
        {
            get => this._class_wizard;
            set => this._class_wizard = value;
        }

        [ProtoMember(16, DataFormat = DataFormat.Default, IsRequired = false, Name = "class_crusader")]
        [DefaultValue(null)]
        public ClassInfo class_crusader
        {
            get => this._class_crusader;
            set => this._class_crusader = value;
        }

        [ProtoMember(17, DataFormat = DataFormat.Default, IsRequired = false, Name = "class_necromancer")]
        [DefaultValue(null)]
        public ClassInfo class_necromancer
        {
            get => this._class_necromancer;
            set => this._class_necromancer = value;
        }

        [ProtoMember(18, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "pvp_wins")]
        [DefaultValue(0)]
        public uint pvp_wins
        {
            get => this._pvp_wins;
            set => this._pvp_wins = value;
        }

        [ProtoMember(19, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "pvp_takedowns")]
        [DefaultValue(0)]
        public uint pvp_takedowns
        {
            get => this._pvp_takedowns;
            set => this._pvp_takedowns = value;
        }

        [ProtoMember(20, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "pvp_damage")]
        [DefaultValue(0.0f)]
        public ulong pvp_damage
        {
            get => this._pvp_damage;
            set => this._pvp_damage = value;
        }

        [ProtoMember(21, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "season_id")]
        [DefaultValue(0)]
        public uint season_id
        {
            get => this._season_id;
            set => this._season_id = value;
        }

        [ProtoMember(22, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "highest_boss_difficulty_5")]
        [DefaultValue(0)]
        public uint highest_boss_difficulty_5
        {
            get => this._highest_boss_difficulty_5;
            set => this._highest_boss_difficulty_5 = value;
        }

        [ProtoMember(23, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "deprecated_best_ladder_paragon_level")]
        [DefaultValue(0)]
        public uint deprecated_best_ladder_paragon_level
        {
            get => this._deprecated_best_ladder_paragon_level;
            set => this._deprecated_best_ladder_paragon_level = value;
        }

        [ProtoMember(24, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "paragon_level")]
        [DefaultValue(0)]
        public uint paragon_level
        {
            get => this._paragon_level;
            set => this._paragon_level = value;
        }

        [ProtoMember(25, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "paragon_xp_next")]
        [DefaultValue(0.0f)]
        public ulong paragon_xp_next
        {
            get => this._paragon_xp_next;
            set => this._paragon_xp_next = value;
        }

        [ProtoMember(26, DataFormat = DataFormat.TwosComplement, Name = "seasons")]
        public List<uint> seasons
        {
            get => this._seasons;
            set => this._seasons = value;
        }

        [ProtoMember(27, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "paragon_level_hardcore")]
        [DefaultValue(0)]
        public uint paragon_level_hardcore
        {
            get => this._paragon_level_hardcore;
            set => this._paragon_level_hardcore = value;
        }

        [ProtoMember(28, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "paragon_xp_next_hardcore")]
        [DefaultValue(0.0f)]
        public ulong paragon_xp_next_hardcore
        {
            get => this._paragon_xp_next_hardcore;
            set => this._paragon_xp_next_hardcore = value;
        }

        [ProtoMember(29, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "bounties_completed")]
        [DefaultValue(0)]
        public uint bounties_completed
        {
            get => this._bounties_completed;
            set => this._bounties_completed = value;
        }

        [ProtoMember(30, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "loot_runs_completed")]
        [DefaultValue(0)]
        public uint loot_runs_completed
        {
            get => this._loot_runs_completed;
            set => this._loot_runs_completed = value;
        }

        [ProtoMember(31, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "highest_level")]
        [DefaultValue(0.0f)]
        public ulong highest_level
        {
            get => this._highest_level;
            set => this._highest_level = value;
        }

        [ProtoMember(32, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "blood_shards_collected")]
        [DefaultValue(0.0f)]
        public ulong blood_shards_collected
        {
            get => this._blood_shards_collected;
            set => this._blood_shards_collected = value;
        }

        [ProtoMember(34, DataFormat = DataFormat.Default, Name = "heroes")]
        public List<HeroMiniProfile> heroes
        {
            get => this._heroes;
            set => this._heroes = value;
        }

        [ProtoMember(35, DataFormat = DataFormat.TwosComplement, Name = "leaderboard_eras_with_scores")]
        public List<uint> leaderboard_eras_with_scores
        {
            get => this._leaderboard_eras_with_scores;
            set => this._leaderboard_eras_with_scores = value;
        }

        [ProtoMember(36, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "num_fallen_heroes")]
        [DefaultValue(0)]
        public uint num_fallen_heroes
        {
            get => this._num_fallen_heroes;
            set => this._num_fallen_heroes = value;
        }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
