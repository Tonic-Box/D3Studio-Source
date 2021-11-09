
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.Hero
{
  [ProtoContract(Name = "SavedQuest")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class SavedQuest : IExtensible
  {
    private int _sno_quest = 0;
    private int _difficulty = 0;
    private int _current_step_uid = 0;
    private List<int> _objective_state = new List<int>();
    private List<int> _failure_condition_state = new List<int>();
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.FixedSize, IsRequired = true, Name = "sno_quest")]
    [DefaultValue(0)]
    public int sno_quest
    {
      get => this._sno_quest;
      set => this._sno_quest = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.ZigZag, IsRequired = true, Name = "difficulty")]
    [DefaultValue(0)]
    public int difficulty
    {
      get => this._difficulty;
      set => this._difficulty = value;
    }

    [ProtoMember(3, DataFormat = DataFormat.ZigZag, IsRequired = true, Name = "current_step_uid")]
    [DefaultValue(0)]
    public int current_step_uid
    {
      get => this._current_step_uid;
      set => this._current_step_uid = value;
    }

    [ProtoMember(4, DataFormat = DataFormat.ZigZag, Name = "objective_state", Options = MemberSerializationOptions.Packed)]
    public List<int> objective_state
    {
      get => this._objective_state;
      set => this._objective_state = value;
    }

    [ProtoMember(5, DataFormat = DataFormat.ZigZag, Name = "failure_condition_state", Options = MemberSerializationOptions.Packed)]
    public List<int> failure_condition_state
    {
      get => this._failure_condition_state;
      set => this._failure_condition_state = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
