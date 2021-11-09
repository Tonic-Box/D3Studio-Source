
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.Account
{
  [ProtoContract(Name = "BannerConfiguration")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class BannerConfiguration : IExtensible
  {
    private uint _banner_shape;
    private uint _sigil_main;
    private uint _sigil_accent;
    private uint _pattern_color;
    private uint _background_color;
    private uint _sigil_color;
    private uint _sigil_placement;
    private uint _pattern;
    private bool _use_sigil_variant;
    private uint _epic_banner = 0;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "banner_shape")]
    public uint banner_shape
    {
      get => this._banner_shape;
      set => this._banner_shape = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "sigil_main")]
    public uint sigil_main
    {
      get => this._sigil_main;
      set => this._sigil_main = value;
    }

    [ProtoMember(3, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "sigil_accent")]
    public uint sigil_accent
    {
      get => this._sigil_accent;
      set => this._sigil_accent = value;
    }

    [ProtoMember(4, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "pattern_color")]
    public uint pattern_color
    {
      get => this._pattern_color;
      set => this._pattern_color = value;
    }

    [ProtoMember(5, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "background_color")]
    public uint background_color
    {
      get => this._background_color;
      set => this._background_color = value;
    }

    [ProtoMember(6, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "sigil_color")]
    public uint sigil_color
    {
      get => this._sigil_color;
      set => this._sigil_color = value;
    }

    [ProtoMember(7, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "sigil_placement")]
    public uint sigil_placement
    {
      get => this._sigil_placement;
      set => this._sigil_placement = value;
    }

    [ProtoMember(8, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "pattern")]
    public uint pattern
    {
      get => this._pattern;
      set => this._pattern = value;
    }

    [ProtoMember(9, DataFormat = DataFormat.Default, IsRequired = true, Name = "use_sigil_variant")]
    public bool use_sigil_variant
    {
      get => this._use_sigil_variant;
      set => this._use_sigil_variant = value;
    }

    [ProtoMember(10, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "epic_banner")]
    [DefaultValue(0)]
    public uint epic_banner
    {
      get => this._epic_banner;
      set => this._epic_banner = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
