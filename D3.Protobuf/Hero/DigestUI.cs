
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.Hero
{
  [ProtoContract(Name = "DigestUI")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class DigestUI : IExtensible
  {
    private int _last_played_act;
    private int _highest_unlocked_act;
    private int _last_played_difficulty;
    private int _highest_unlocked_difficulty;
    private int _last_played_quest;
    private int _last_played_quest_step;
    private uint _time_played;
    private int _highest_completed_difficulty = 0;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.ZigZag, IsRequired = true, Name = "last_played_act")]
    public int last_played_act
    {
      get => this._last_played_act;
      set => this._last_played_act = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.ZigZag, IsRequired = true, Name = "highest_unlocked_act")]
    public int highest_unlocked_act
    {
      get => this._highest_unlocked_act;
      set => this._highest_unlocked_act = value;
    }

    [ProtoMember(3, DataFormat = DataFormat.ZigZag, IsRequired = true, Name = "last_played_difficulty")]
    public int last_played_difficulty
    {
      get => this._last_played_difficulty;
      set => this._last_played_difficulty = value;
    }

    [ProtoMember(4, DataFormat = DataFormat.ZigZag, IsRequired = true, Name = "highest_unlocked_difficulty")]
    public int highest_unlocked_difficulty
    {
      get => this._highest_unlocked_difficulty;
      set => this._highest_unlocked_difficulty = value;
    }

    [ProtoMember(5, DataFormat = DataFormat.FixedSize, IsRequired = true, Name = "last_played_quest")]
    public int last_played_quest
    {
      get => this._last_played_quest;
      set => this._last_played_quest = value;
    }

    [ProtoMember(6, DataFormat = DataFormat.ZigZag, IsRequired = true, Name = "last_played_quest_step")]
    public int last_played_quest_step
    {
      get => this._last_played_quest_step;
      set => this._last_played_quest_step = value;
    }

    [ProtoMember(7, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "time_played")]
    public uint time_played
    {
      get => this._time_played;
      set => this._time_played = value;
    }

    [ProtoMember(8, DataFormat = DataFormat.ZigZag, IsRequired = false, Name = "highest_completed_difficulty")]
    [DefaultValue(0)]
    public int highest_completed_difficulty
    {
      get => this._highest_completed_difficulty;
      set => this._highest_completed_difficulty = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
