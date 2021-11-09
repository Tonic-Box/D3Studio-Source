
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.Hero
{
  [ProtoContract(Name = "QuestRewardHistoryList")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class QuestRewardHistoryList : IExtensible
  {
    private List<QuestRewardHistoryEntry> _quest_reward_history = new List<QuestRewardHistoryEntry>();
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.Default, Name = "quest_reward_history")]
    public List<QuestRewardHistoryEntry> quest_reward_history
    {
      get => this._quest_reward_history;
      set => this._quest_reward_history = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
