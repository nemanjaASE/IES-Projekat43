﻿using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Wires
{
    public class Breaker : ProtectedSwitch
    {
		private float inTransitTime;
		public Breaker(long globalId)
		   : base(globalId)
		{
		}
		public float InTransitTime
		{
			get { return inTransitTime; }
			set { inTransitTime = value; }
		}
		public override bool Equals(object obj)
		{
			if (base.Equals(obj))
			{
				Breaker x = (Breaker)obj;
				return (x.inTransitTime == this.inTransitTime);
			}
			else
			{
				return false;
			}
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		#region IAccess implementation

		public override bool HasProperty(ModelCode t)
		{
			switch (t)
			{
				case ModelCode.BREAKER_INTRANSITTIME:
					return true;

				default:
					return base.HasProperty(t);
			}
		}

		public override void GetProperty(Property prop)
		{
			switch (prop.Id)
			{
				case ModelCode.BREAKER_INTRANSITTIME:
					prop.SetValue(inTransitTime);
					break;

				default:
					base.GetProperty(prop);
					break;
			}
		}

		public override void SetProperty(Property property)
		{

			switch (property.Id)
			{
				case ModelCode.BREAKER_INTRANSITTIME:
					inTransitTime = property.AsFloat();
					break;

				default:
					base.SetProperty(property);
					break;
			}

		}

		#endregion IAccess implementation
	}
}
