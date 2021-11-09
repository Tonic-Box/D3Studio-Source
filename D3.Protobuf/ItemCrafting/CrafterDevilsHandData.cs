
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.ItemCrafting
{
  [ProtoContract(Name = "CrafterDevilsHandData")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class CrafterDevilsHandData : IExtensible
  {
    private List<int> _unlocked_sets = new List<int>();
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.FixedSize, Name = "unlocked_sets")]
    public List<int> unlocked_sets
    {
      get => this._unlocked_sets;
      set => this._unlocked_sets = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
