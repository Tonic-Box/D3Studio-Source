
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.Quests
{
  [ProtoContract(Name = "QuestStepComplete")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class QuestStepComplete : IExtensible
  {
    private bool _is_quest_complete;
    private QuestReward _reward = (QuestReward) null;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.Default, IsRequired = true, Name = "is_quest_complete")]
    public bool is_quest_complete
    {
      get => this._is_quest_complete;
      set => this._is_quest_complete = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.Default, IsRequired = false, Name = "reward")]
    [DefaultValue(null)]
    public QuestReward reward
    {
      get => this._reward;
      set => this._reward = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
