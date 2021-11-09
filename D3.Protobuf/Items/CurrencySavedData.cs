
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.Items
{
  [ProtoContract(Name = "CurrencySavedData")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class CurrencySavedData : IExtensible
  {
    private List<Currency> _currency = new List<Currency>();
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.Default, IsRequired = true, Name = "currency")]
    [DefaultValue(null)]
    public List<Currency> currency
    {
      get => this._currency;
      set => this._currency = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
