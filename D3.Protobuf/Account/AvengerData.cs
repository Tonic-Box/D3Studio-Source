
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.Account
{
  [ProtoContract(Name = "AvengerData")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class AvengerData : IExtensible
  {
    private Avenger _avenger_hardcore = (Avenger) null;
    private Avenger _avenger_solo = (Avenger) null;
    private Avenger _avenger_friends = (Avenger) null;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.Default, IsRequired = true, Name = "avenger_hardcore")]
    [DefaultValue(null)]
    public Avenger avenger_hardcore
    {
      get => this._avenger_hardcore;
      set => this._avenger_hardcore = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.Default, IsRequired = true, Name = "avenger_solo")]
    [DefaultValue(null)]
    public Avenger avenger_solo
    {
      get => this._avenger_solo;
      set => this._avenger_solo = value;
    }

    [ProtoMember(3, DataFormat = DataFormat.Default, IsRequired = true, Name = "avenger_friends")]
    [DefaultValue(null)]
    public Avenger avenger_friends
    {
      get => this._avenger_friends;
      set => this._avenger_friends = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    
}
}
