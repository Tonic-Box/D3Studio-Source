
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.Profile
{
  [ProtoContract(Name = "PvpTeam")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class PvpTeam : IExtensible
  {
    private ulong _team_id = 0;
    private float _rating = 0.0f;
    private float _rating_variance = 0.0f;
    private float _bootstrap = 0.0f;
    private int _games_played = 0;
    private uint _last_played = 0;
    private int _num_members = 0;
    private int _game_mode = 0;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "team_id")]
    [DefaultValue(0.0f)]
    public ulong team_id
    {
      get => this._team_id;
      set => this._team_id = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.FixedSize, IsRequired = false, Name = "rating")]
    [DefaultValue(0.0f)]
    public float rating
    {
      get => this._rating;
      set => this._rating = value;
    }

    [ProtoMember(3, DataFormat = DataFormat.FixedSize, IsRequired = false, Name = "rating_variance")]
    [DefaultValue(0.0f)]
    public float rating_variance
    {
      get => this._rating_variance;
      set => this._rating_variance = value;
    }

    [ProtoMember(4, DataFormat = DataFormat.FixedSize, IsRequired = false, Name = "bootstrap")]
    [DefaultValue(0.0f)]
    public float bootstrap
    {
      get => this._bootstrap;
      set => this._bootstrap = value;
    }

    [ProtoMember(5, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "games_played")]
    [DefaultValue(0)]
    public int games_played
    {
      get => this._games_played;
      set => this._games_played = value;
    }

    [ProtoMember(6, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "last_played")]
    [DefaultValue(0)]
    public uint last_played
    {
      get => this._last_played;
      set => this._last_played = value;
    }

    [ProtoMember(7, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "num_members")]
    [DefaultValue(0)]
    public int num_members
    {
      get => this._num_members;
      set => this._num_members = value;
    }

    [ProtoMember(8, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "game_mode")]
    [DefaultValue(0)]
    public int game_mode
    {
      get => this._game_mode;
      set => this._game_mode = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
