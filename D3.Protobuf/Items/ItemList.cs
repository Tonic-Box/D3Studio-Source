
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.Items
{
  [ProtoContract(Name = "ItemList")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class ItemList : IExtensible
  {
    private List<SavedItem> _items = new List<SavedItem>();
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.Default, Name = "items")]
    public List<SavedItem> items
    {
      get => this._items;
      set => this._items = value;
    }
        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
