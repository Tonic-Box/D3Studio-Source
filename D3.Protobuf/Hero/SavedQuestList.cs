
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.Hero
{
  [ProtoContract(Name = "SavedQuestList")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class SavedQuestList : IExtensible
  {
    private List<SavedQuest> _saved_quests = new List<SavedQuest>();
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.Default, Name = "saved_quests")]
    public List<SavedQuest> saved_quests
    {
      get => this._saved_quests;
      set => this._saved_quests = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
