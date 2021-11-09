
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.Account
{
  [ProtoContract(Name = "LadderInfo")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class LadderInfo : IExtensible
  {
    private ulong _account_id;
    private uint _level;
    private uint _xp;
    private ulong _guild_id;
    private string _guild_name = "";
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "account_id")]
    public ulong account_id
    {
      get => this._account_id;
      set => this._account_id = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "level")]
    public uint level
    {
      get => this._level;
      set => this._level = value;
    }

    [ProtoMember(3, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "xp")]
    public uint xp
    {
      get => this._xp;
      set => this._xp = value;
    }

    [ProtoMember(4, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "guild_id")]
    public ulong guild_id
    {
      get => this._guild_id;
      set => this._guild_id = value;
    }

    [ProtoMember(5, DataFormat = DataFormat.Default, IsRequired = false, Name = "guild_name")]
    [DefaultValue("")]
    public string guild_name
    {
      get => this._guild_name;
      set => this._guild_name = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
