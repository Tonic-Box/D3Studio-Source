
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.Items
{
  [ProtoContract(Name = "RareItemName")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class RareItemName : IExtensible
  {
    private bool _item_name_is_prefix = false;
    private int _sno_affix_string_list = 0;
    private int _affix_string_list_index = 0;
    private int _item_string_list_index = 0;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.Default, IsRequired = true, Name = "item_name_is_prefix")]
    public bool item_name_is_prefix
    {
      get => this._item_name_is_prefix;
      set => this._item_name_is_prefix = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.FixedSize, IsRequired = true, Name = "sno_affix_string_list")]
    public int sno_affix_string_list
    {
      get => this._sno_affix_string_list;
      set => this._sno_affix_string_list = value;
    }

    [ProtoMember(3, DataFormat = DataFormat.ZigZag, IsRequired = true, Name = "affix_string_list_index")]
    public int affix_string_list_index
    {
      get => this._affix_string_list_index;
      set => this._affix_string_list_index = value;
    }

    [ProtoMember(4, DataFormat = DataFormat.ZigZag, IsRequired = true, Name = "item_string_list_index")]
    public int item_string_list_index
    {
      get => this._item_string_list_index;
      set => this._item_string_list_index = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
