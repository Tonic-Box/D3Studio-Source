
using PB.OnlineService;
using ProtoBuf;
using System;
using System.ComponentModel;

namespace PB.Items
{
  [ProtoContract(Name = "Mail")]
  [TypeConverter(typeof (ExpandableObjectConverter))]
  [Serializable]
  public class Mail : IExtensible
  {
    private EntityId _account_to;
    private EntityId _account_from;
    private ulong _mail_id;
    private string _title = "";
    private string _body = "";
    private uint _status = 0;
    private uint _send_time = 0;
    private MailAttachments _attachments = (MailAttachments) null;
    private uint _flags = 0;
    private IExtension extensionObject;

    [ProtoMember(1, DataFormat = DataFormat.Default, IsRequired = true, Name = "account_to")]
    public EntityId account_to
    {
      get => this._account_to;
      set => this._account_to = value;
    }

    [ProtoMember(2, DataFormat = DataFormat.Default, IsRequired = true, Name = "account_from")]
    public EntityId account_from
    {
      get => this._account_from;
      set => this._account_from = value;
    }

    [ProtoMember(3, DataFormat = DataFormat.TwosComplement, IsRequired = true, Name = "mail_id")]
    public ulong mail_id
    {
      get => this._mail_id;
      set => this._mail_id = value;
    }

    [ProtoMember(4, DataFormat = DataFormat.Default, IsRequired = false, Name = "title")]
    [DefaultValue("")]
    public string title
    {
      get => this._title;
      set => this._title = value;
    }

    [ProtoMember(5, DataFormat = DataFormat.Default, IsRequired = false, Name = "body")]
    [DefaultValue("")]
    public string body
    {
      get => this._body;
      set => this._body = value;
    }

    [ProtoMember(6, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "status")]
    [DefaultValue(0)]
    public uint status
    {
      get => this._status;
      set => this._status = value;
    }

    [ProtoMember(7, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "send_time")]
    [DefaultValue(0)]
    public uint send_time
    {
      get => this._send_time;
      set => this._send_time = value;
    }

    [ProtoMember(8, DataFormat = DataFormat.Default, IsRequired = false, Name = "attachments")]
    [DefaultValue(null)]
    public MailAttachments attachments
    {
      get => this._attachments;
      set => this._attachments = value;
    }

    [Browsable(true)]
    [ProtoMember(9, DataFormat = DataFormat.TwosComplement, IsRequired = false, Name = "flags")]
    [DefaultValue(0)]
    public uint flags
    {
      get => this._flags;
      set => this._flags = value;
    }

        IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
