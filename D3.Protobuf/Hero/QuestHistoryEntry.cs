
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.Hero
{
  [ProtoContract(Name = "QuestHistoryEntry")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class QuestHistoryEntry : IExtensible
  {
    private int _sno_quest;
    private int _difficulty = 0;
    private int _highest_played_quest_step = -3;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.FixedSize, IsRequired = true, Name = "sno_quest")]
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

    [ProtoMember(3, DataFormat = DataFormat.ZigZag, IsRequired = true, Name = "highest_played_quest_step")]
    [DefaultValue(-3)]
    public int highest_played_quest_step
    {
      get => this._highest_played_quest_step;
      set => this._highest_played_quest_step = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
