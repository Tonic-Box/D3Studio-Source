
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.Profile
{
  [ProtoContract(Name = "ClassInfo")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class ClassInfo : IExtensible
  {
    private ulong _playtime = 0;
    private uint _highest_level = 0;
    private uint _highest_difficulty = 0;
    private uint _pvp_games = 0;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "playtime")]
    [DefaultValue(0.0f)]
    public ulong playtime
    {
      get => this._playtime;
      set => this._playtime = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "highest_level")]
    [DefaultValue(0)]
    public uint highest_level
    {
      get => this._highest_level;
      set => this._highest_level = value;
    }

    [ProtoMember(3, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "highest_difficulty")]
    [DefaultValue(0)]
    public uint highest_difficulty
    {
      get => this._highest_difficulty;
      set => this._highest_difficulty = value;
    }

    [ProtoMember(4, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "pvp_games")]
    [DefaultValue(0)]
    public uint pvp_games
    {
      get => this._pvp_games;
      set => this._pvp_games = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
