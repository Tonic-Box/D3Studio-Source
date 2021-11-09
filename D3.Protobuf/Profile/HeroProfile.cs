
using PB.Items;
using PB.OnlineService;
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.Profile
{
  [ProtoContract(Name = "HeroProfile")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class HeroProfile : IExtensible
  {
    private ulong _monsters_killed = 0;
    private ulong _elites_killed = 0;
    private ulong _gold_collected = 0;
    private uint _highest_level = 0;
    private uint _highest_difficulty = 0;
    private uint _create_time = 0;
    private bool _hardcore = false;
    private uint _strength = 0;
    private uint _dexterity = 0;
    private uint _intelligence = 0;
    private uint _vitality = 0;
    private uint _armor = 0;
    private float _dps = 0.0f;
    private uint _resist_arcane = 0;
    private uint _resist_fire = 0;
    private uint _resist_lightning = 0;
    private uint _resist_poison = 0;
    private uint _resist_cold = 0;
    private ItemList _equipment = (ItemList) null;
    private SkillsWithRunes _sno_active_skills = (SkillsWithRunes) null;
    private PassiveSkills _sno_traits = (PassiveSkills) null;
    private uint _death_time = 0;
    private KillerInfo _killer_info = (KillerInfo) null;
    private uint _sno_kill_location = 0;
    private EntityId _hero_id = (EntityId) null;
    private float _damage_increase = 0.0f;
    private float _crit_chance = 0.0f;
    private float _damage_reduction = 0.0f;
    private uint _life = 0;
    private uint _pvp_glory = 0;
    private uint _pvp_wins = 0;
    private uint _pvp_takedowns = 0;
    private ulong _pvp_damage = 0;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "monsters_killed")]
    [DefaultValue(0.0f)]
    public ulong monsters_killed
    {
      get => this._monsters_killed;
      set => this._monsters_killed = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "elites_killed")]
    [DefaultValue(0.0f)]
    public ulong elites_killed
    {
      get => this._elites_killed;
      set => this._elites_killed = value;
    }

    [ProtoMember(3, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "gold_collected")]
    [DefaultValue(0.0f)]
    public ulong gold_collected
    {
      get => this._gold_collected;
      set => this._gold_collected = value;
    }

    [ProtoMember(4, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "highest_level")]
    [DefaultValue(0)]
    public uint highest_level
    {
      get => this._highest_level;
      set => this._highest_level = value;
    }

    [ProtoMember(5, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "highest_difficulty")]
    [DefaultValue(0)]
    public uint highest_difficulty
    {
      get => this._highest_difficulty;
      set => this._highest_difficulty = value;
    }

    [ProtoMember(6, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "create_time")]
    [DefaultValue(0)]
    public uint create_time
    {
      get => this._create_time;
      set => this._create_time = value;
    }

    [ProtoMember(7, DataFormat = DataFormat.Default, IsRequired = false, Name = "hardcore")]
    [DefaultValue(false)]
    public bool hardcore
    {
      get => this._hardcore;
      set => this._hardcore = value;
    }

    [ProtoMember(8, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "strength")]
    [DefaultValue(0)]
    public uint strength
    {
      get => this._strength;
      set => this._strength = value;
    }

    [ProtoMember(9, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "dexterity")]
    [DefaultValue(0)]
    public uint dexterity
    {
      get => this._dexterity;
      set => this._dexterity = value;
    }

    [ProtoMember(10, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "intelligence")]
    [DefaultValue(0)]
    public uint intelligence
    {
      get => this._intelligence;
      set => this._intelligence = value;
    }

    [ProtoMember(11, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "vitality")]
    [DefaultValue(0)]
    public uint vitality
    {
      get => this._vitality;
      set => this._vitality = value;
    }

    [ProtoMember(12, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "armor")]
    [DefaultValue(0)]
    public uint armor
    {
      get => this._armor;
      set => this._armor = value;
    }

    [ProtoMember(13, DataFormat = DataFormat.FixedSize, IsRequired = false, Name = "dps")]
    [DefaultValue(0.0f)]
    public float dps
    {
      get => this._dps;
      set => this._dps = value;
    }

    [ProtoMember(14, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "resist_arcane")]
    [DefaultValue(0)]
    public uint resist_arcane
    {
      get => this._resist_arcane;
      set => this._resist_arcane = value;
    }

    [ProtoMember(15, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "resist_fire")]
    [DefaultValue(0)]
    public uint resist_fire
    {
      get => this._resist_fire;
      set => this._resist_fire = value;
    }

    [ProtoMember(16, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "resist_lightning")]
    [DefaultValue(0)]
    public uint resist_lightning
    {
      get => this._resist_lightning;
      set => this._resist_lightning = value;
    }

    [ProtoMember(17, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "resist_poison")]
    [DefaultValue(0)]
    public uint resist_poison
    {
      get => this._resist_poison;
      set => this._resist_poison = value;
    }

    [ProtoMember(18, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "resist_cold")]
    [DefaultValue(0)]
    public uint resist_cold
    {
      get => this._resist_cold;
      set => this._resist_cold = value;
    }

    [ProtoMember(19, DataFormat = DataFormat.Default, IsRequired = false, Name = "equipment")]
    [DefaultValue(null)]
    public ItemList equipment
    {
      get => this._equipment;
      set => this._equipment = value;
    }

    [ProtoMember(20, DataFormat = DataFormat.Default, IsRequired = false, Name = "sno_active_skills")]
    [DefaultValue(null)]
    public SkillsWithRunes sno_active_skills
    {
      get => this._sno_active_skills;
      set => this._sno_active_skills = value;
    }

    [ProtoMember(21, DataFormat = DataFormat.Default, IsRequired = false, Name = "sno_traits")]
    [DefaultValue(null)]
    public PassiveSkills sno_traits
    {
      get => this._sno_traits;
      set => this._sno_traits = value;
    }

    [ProtoMember(22, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "death_time")]
    [DefaultValue(0)]
    public uint death_time
    {
      get => this._death_time;
      set => this._death_time = value;
    }

    [ProtoMember(23, DataFormat = DataFormat.Default, IsRequired = false, Name = "killer_info")]
    [DefaultValue(null)]
    public KillerInfo killer_info
    {
      get => this._killer_info;
      set => this._killer_info = value;
    }

    [ProtoMember(24, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "sno_kill_location")]
    [DefaultValue(0)]
    public uint sno_kill_location
    {
      get => this._sno_kill_location;
      set => this._sno_kill_location = value;
    }

    [ProtoMember(27, DataFormat = DataFormat.Default, IsRequired = false, Name = "hero_id")]
    [DefaultValue(null)]
    public EntityId hero_id
    {
      get => this._hero_id;
      set => this._hero_id = value;
    }

    [ProtoMember(28, DataFormat = DataFormat.FixedSize, IsRequired = false, Name = "damage_increase")]
    [DefaultValue(0.0f)]
    public float damage_increase
    {
      get => this._damage_increase;
      set => this._damage_increase = value;
    }

    [ProtoMember(29, DataFormat = DataFormat.FixedSize, IsRequired = false, Name = "crit_chance")]
    [DefaultValue(0.0f)]
    public float crit_chance
    {
      get => this._crit_chance;
      set => this._crit_chance = value;
    }

    [ProtoMember(30, DataFormat = DataFormat.FixedSize, IsRequired = false, Name = "damage_reduction")]
    [DefaultValue(0.0f)]
    public float damage_reduction
    {
      get => this._damage_reduction;
      set => this._damage_reduction = value;
    }

    [ProtoMember(31, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "life")]
    [DefaultValue(0)]
    public uint life
    {
      get => this._life;
      set => this._life = value;
    }

    [ProtoMember(35, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "pvp_glory")]
    [DefaultValue(0)]
    public uint pvp_glory
    {
      get => this._pvp_glory;
      set => this._pvp_glory = value;
    }

    [ProtoMember(36, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "pvp_wins")]
    [DefaultValue(0)]
    public uint pvp_wins
    {
      get => this._pvp_wins;
      set => this._pvp_wins = value;
    }

    [ProtoMember(37, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "pvp_takedowns")]
    [DefaultValue(0)]
    public uint pvp_takedowns
    {
      get => this._pvp_takedowns;
      set => this._pvp_takedowns = value;
    }

    [ProtoMember(38, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "pvp_damage")]
    [DefaultValue(0.0f)]
    public ulong pvp_damage
    {
      get => this._pvp_damage;
      set => this._pvp_damage = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
