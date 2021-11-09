
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.Console
{
  [ProtoContract(Name = "BalanceUpdateConfig")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class BalanceUpdateConfig : IExtensible
  {
    private int _title_version = 0;
    private int _version = 0;
    private string _toc = "";
    private string _locale = "";
    private string _locale_toc = "";
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.ZigZag, IsRequired = false, Name = "title_version")]
    [DefaultValue(0)]
    public int title_version
    {
      get => this._title_version;
      set => this._title_version = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.ZigZag, IsRequired = false, Name = "version")]
    [DefaultValue(0)]
    public int version
    {
      get => this._version;
      set => this._version = value;
    }

    [ProtoMember(3, DataFormat = DataFormat.Default, IsRequired = false, Name = "toc")]
    [DefaultValue("")]
    public string toc
    {
      get => this._toc;
      set => this._toc = value;
    }

    [ProtoMember(4, DataFormat = DataFormat.Default, IsRequired = false, Name = "locale")]
    [DefaultValue("")]
    public string locale
    {
      get => this._locale;
      set => this._locale = value;
    }

    [ProtoMember(5, DataFormat = DataFormat.Default, IsRequired = false, Name = "locale_toc")]
    [DefaultValue("")]
    public string locale_toc
    {
      get => this._locale_toc;
      set => this._locale_toc = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
