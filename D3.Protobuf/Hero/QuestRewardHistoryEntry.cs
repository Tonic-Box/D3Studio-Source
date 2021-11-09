
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.Hero
{
  [ProtoContract(Name = "QuestRewardHistoryEntry")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class QuestRewardHistoryEntry : IExtensible
  {
    private int _sno_quest;
    private int _step_uid;
    private int _difficulty_deprecated = 0;
    private uint _difficulty_flags = 0;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.FixedSize, IsRequired = true, Name = "sno_quest")]
    public int sno_quest
    {
      get => this._sno_quest;
      set => this._sno_quest = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.ZigZag, IsRequired = true, Name = "step_uid")]
    public int step_uid
    {
      get => this._step_uid;
      set => this._step_uid = value;
    }

    [ProtoMember(3, DataFormat = DataFormat.ZigZag, IsRequired = true, Name = "difficulty_deprecated")]
    [DefaultValue(0)]
    public int difficulty_deprecated
    {
      get => this._difficulty_deprecated;
      set => this._difficulty_deprecated = value;
    }

    [ProtoMember(4, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "difficulty_flags")]
    [DefaultValue(0)]
    public uint difficulty_flags
    {
      get => this._difficulty_flags;
      set => this._difficulty_flags = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
