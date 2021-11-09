
using PB.Achievements;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using PB.AttributeSerializer;
using PB.ItemCrafting;
using PB.Items;
using PB.OnlineService;

namespace PB.Account
{
    [ProtoContract(Name = "UnlockedPetsData")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class UnlockedCosmeticsData : IExtensible
    {
		// Token: 0x17000151 RID: 337
		// (get) Token: 0x0600030C RID: 780 RVA: 0x00006034 File Offset: 0x00004234
		// (set) Token: 0x0600030D RID: 781 RVA: 0x0000604C File Offset: 0x0000424C
		[ProtoMember(1, Name = "unlocked_cosmetics", DataFormat = DataFormat.FixedSize)]
		public List<int> unlocked_cosmetics
		{
			get
			{
				return this._unlocked_cosmetics;
			}
			set
			{
				this._unlocked_cosmetics = value;
			}
		}

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x0600030E RID: 782 RVA: 0x00006058 File Offset: 0x00004258
		// (set) Token: 0x0600030F RID: 783 RVA: 0x00006070 File Offset: 0x00004270
		[ProtoMember(2, IsRequired = false, Name = "unlocked_cosmetics_bitfield", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public byte[] unlocked_cosmetics_bitfield
		{
			get
			{
				return this._unlocked_cosmetics_bitfield;
			}
			set
			{
				this._unlocked_cosmetics_bitfield = value;
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
		private List<int> _unlocked_cosmetics = new List<int>();

		// Token: 0x0400018D RID: 397
		private byte[] _unlocked_cosmetics_bitfield;

		// Token: 0x0400018E RID: 398
		private int _bitfield_leading_null_bytes = 0;

		// Token: 0x0400018F RID: 399
		private IExtension extensionObject;
	}
}
