﻿using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.LoadModel
{
    public class Season : IdentifiedObject
    {
		private DateTime endDate;
		private DateTime startDate;
		private List<long> seasonDayTypeSchedules = new List<long>();

		public Season(long globalId)
		   : base(globalId)
		{
		}

		public List<long> SeasonDayTypeSchedules
		{
			get { return seasonDayTypeSchedules; }
			set { seasonDayTypeSchedules = value; }
		}
		public DateTime EndDate
		{
			get { return endDate; }
			set { endDate = value; }
		}
		public DateTime StartDate
		{
			get { return startDate; }
			set { startDate = value; }
		}

		public override bool Equals(object obj)
		{
			if (base.Equals(obj))
			{
				Season x = (Season)obj;
				return (x.endDate == this.endDate &&
						x.startDate == this.startDate &&
						CompareHelper.CompareLists(x.SeasonDayTypeSchedules, this.SeasonDayTypeSchedules, true));
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
				case ModelCode.SEASON_SEASONDAYTYPESCHEDULES:
				case ModelCode.SEASON_ENDDATE:
				case ModelCode.SEASON_STARTDATE:
					return true;

				default:
					return base.HasProperty(t);
			}
		}

		public override void GetProperty(Property prop)
		{
			switch (prop.Id)
			{
				case ModelCode.SEASON_ENDDATE:
					prop.SetValue(endDate);
					break;
				case ModelCode.SEASON_STARTDATE:
					prop.SetValue(startDate);
					break;
				case ModelCode.SEASON_SEASONDAYTYPESCHEDULES:
					prop.SetValue(seasonDayTypeSchedules);
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
				case ModelCode.SEASON_ENDDATE:
					endDate = property.AsDateTime();
					break;

				case ModelCode.SEASON_STARTDATE:
					startDate = property.AsDateTime();
					break;

				default:
					base.SetProperty(property);
					break;
			}
		}

		#endregion IAccess implementation

		#region IReference implementation

		public override bool IsReferenced
		{
			get
			{
				return (seasonDayTypeSchedules.Count > 0) || base.IsReferenced;
			}
		}

		public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
		{
			if (seasonDayTypeSchedules != null && seasonDayTypeSchedules.Count > 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
			{
				references[ModelCode.SEASON_SEASONDAYTYPESCHEDULES] = seasonDayTypeSchedules.GetRange(0, seasonDayTypeSchedules.Count);
			}

			base.GetReferences(references, refType);
		}

		public override void AddReference(ModelCode referenceId, long globalId)
		{
			switch (referenceId)
			{
				case ModelCode.SEASONDAYTYPESCHEDULE_SEASON:
					seasonDayTypeSchedules.Add(globalId);
					break;

				default:
					base.AddReference(referenceId, globalId);
					break;
			}
		}

		public override void RemoveReference(ModelCode referenceId, long globalId)
		{
			switch (referenceId)
			{
				case ModelCode.SEASONDAYTYPESCHEDULE_SEASON:

					if (seasonDayTypeSchedules.Contains(globalId))
					{
						seasonDayTypeSchedules.Remove(globalId);
					}
					else
					{
						CommonTrace.WriteTrace(CommonTrace.TraceWarning, "Entity (GID = 0x{0:x16}) doesn't contain reference 0x{1:x16}.", this.GlobalId, globalId);
					}

					break;
				default:
					base.RemoveReference(referenceId, globalId);
					break;
			}
		}

		#endregion IReference implementation
	}
}
