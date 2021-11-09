
using PB.AttributeSerializer;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.Hero
{
  [ProtoContract(Name = "BasicAttributeList")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class BasicAttributeList : IExtensible
  {
    private List<SavedAttribute> _attributes = new List<SavedAttribute>();
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.Default, Name = "attributes")]
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
