
using PB.GameBalance;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.AttributeSerializer
{
  [ProtoContract(Name = "SavedAttributes")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class SavedAttributes : IExtensible
  {
    private Handle _gb_handle;
    private List<SavedAttribute> _attributes = new List<SavedAttribute>();
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.Default, IsRequired = true, Name = "gb_handle")]
    public Handle gb_handle
    {
      get => this._gb_handle;
      set => this._gb_handle = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.Default, Name = "attributes")]
    public List<SavedAttribute> attributes
    {
      get => this._attributes;
      set => this._attributes = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
