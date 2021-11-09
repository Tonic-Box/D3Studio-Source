
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PB.Items
{
  [ProtoContract(Name = "Mails")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class Mails : IExtensible
  {
    private List<Mail> _mails = new List<Mail>();
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.Default, Name = "mails")]
    public List<Mail> mails
    {
      get => this._mails;
      set => this._mails = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
