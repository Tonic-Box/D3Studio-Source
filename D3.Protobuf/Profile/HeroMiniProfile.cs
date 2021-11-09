
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.Profile
{
  [ProtoContract(Name = "HeroMiniProfile")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class HeroMiniProfile : IExtensible
  {
    private uint _hero_id;
    private string _hero_name;
    private int _hero_gbid_class;
    private uint _hero_flags;
    private uint _hero_level;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "hero_id")]
    public uint hero_id
    {
      get => this._hero_id;
      set => this._hero_id = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.Default, IsRequired = true, Name = "hero_name")]
    public string hero_name
    {
      get => this._hero_name;
      set => this._hero_name = value;
    }

    [ProtoMember(3, DataFormat = DataFormat.FixedSize, IsRequired = true, Name = "hero_gbid_class")]
    public int hero_gbid_class
    {
      get => this._hero_gbid_class;
      set => this._hero_gbid_class = value;
    }

    [ProtoMember(4, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "hero_flags")]
    public uint hero_flags
    {
      get => this._hero_flags;
      set => this._hero_flags = value;
    }

    [ProtoMember(5, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "hero_level")]
    public uint hero_level
    {
      get => this._hero_level;
      set => this._hero_level = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
