
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.Hero
{
  [ProtoContract(Name = "QuestHistoryList")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class QuestHistoryList : IExtensible
  {
    private List<QuestHistoryEntry> _quest_history = new List<QuestHistoryEntry>();
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.Default, Name = "quest_history")]
    public List<QuestHistoryEntry> quest_history
    {
      get => this._quest_history;
      set => this._quest_history = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
