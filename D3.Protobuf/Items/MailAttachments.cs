
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.Items
{
  [ProtoContract(Name = "MailAttachments")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class MailAttachments : IExtensible
  {
    private ItemList _items = (ItemList) null;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.Default, IsRequired = false, Name = "items")]
    [DefaultValue(null)]
    public ItemList items
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
