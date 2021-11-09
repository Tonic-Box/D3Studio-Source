
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.Hero
{
  [ProtoContract(Name = "SavedItemLink")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class SavedItemLink : IExtensible
  {
    private int _x;
    private int _y;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.ZigZag, IsRequired = true, Name = "x")]
    public int x
    {
      get => this._x;
      set => this._x = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.ZigZag, IsRequired = true, Name = "y")]
    public int y
    {
      get => this._y;
      set => this._y = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
