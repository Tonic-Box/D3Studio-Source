
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.Hero
{
  [ProtoContract(Name = "NameText")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class NameText : IExtensible
  {
    private string _name;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.Default, IsRequired = true, Name = "name")]
    public string name
    {
      get => this._name;
      set => this._name = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
