using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProtoBuf;

namespace PB.ItemCrafting
{
	// Token: 0x02000038 RID: 56
	[ProtoContract(Name = "CrafterKanaisCubeData")]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	[Serializable]
	public class CrafterKanaisCubeData : IExtensible
	{
		// Token: 0x17000151 RID: 337
		// (get) Token: 0x0600030C RID: 780 RVA: 0x00006034 File Offset: 0x00004234
		// (set) Token: 0x0600030D RID: 781 RVA: 0x0000604C File Offset: 0x0000424C
		[ProtoMember(1, Name = "extracted_legendaries", DataFormat = DataFormat.FixedSize)]
		public List<int> extracted_legendaries
		{
			get
			{
				return this._extracted_legendaries;
			}
			set
			{
				this._extracted_legendaries = value;
			}
		}

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x0600030E RID: 782 RVA: 0x00006058 File Offset: 0x00004258
		// (set) Token: 0x0600030F RID: 783 RVA: 0x00006070 File Offset: 0x00004270
		[ProtoMember(2, IsRequired = false, Name = "extracted_legendaries_bitfield", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public byte[] extracted_legendaries_bitfield
		{
			get
			{
				return this._extracted_legendaries_bitfield;
			}
			set
			{
				this._extracted_legendaries_bitfield = value;
			}
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x06000310 RID: 784 RVA: 0x0000607C File Offset: 0x0000427C
		// (set) Token: 0x06000311 RID: 785 RVA: 0x00006094 File Offset: 0x00004294
		[ProtoMember(3, IsRequired = false, Name = "bitfield_leading_null_bytes", DataFormat = DataFormat.TwosComplement)]
		[DefaultValue(0)]
		public int bitfield_leading_null_bytes
		{
			get
			{
				return this._bitfield_leading_null_bytes;
			}
			set
			{
				this._bitfield_leading_null_bytes = value;
			}
		}

		// Token: 0x06000312 RID: 786 RVA: 0x000060A0 File Offset: 0x000042A0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400018C RID: 396
		private List<int> _extracted_legendaries = new List<int>();

		// Token: 0x0400018D RID: 397
		private byte[] _extracted_legendaries_bitfield;

		// Token: 0x0400018E RID: 398
		private int _bitfield_leading_null_bytes = 0;

		// Token: 0x0400018F RID: 399
		private IExtension extensionObject;
	}
}
