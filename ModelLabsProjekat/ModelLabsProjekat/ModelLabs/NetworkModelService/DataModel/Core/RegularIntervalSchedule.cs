﻿using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Core
{
    public class RegularIntervalSchedule : BasicIntervalSchedule
    {
        private List<long> timePoints = new List<long>();

        public RegularIntervalSchedule(long globalId)
           : base(globalId)
        {
        }

        public List<long> TimePoints
        {
            get { return timePoints; }
            set { timePoints = value; }
        }

		public override bool Equals(object obj)
		{
			if (base.Equals(obj))
			{
				RegularIntervalSchedule x = (RegularIntervalSchedule)obj;
				return (CompareHelper.CompareLists(x.TimePoints, this.TimePoints, true));
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
				case ModelCode.REGULARINTERVALSCHEDULE_TIMEPOINTS:
					return true;

				default:
					return base.HasProperty(t);
			}
		}

		public override void GetProperty(Property prop)
		{
			switch (prop.Id)
			{

				case ModelCode.REGULARINTERVALSCHEDULE_TIMEPOINTS:
					prop.SetValue(timePoints);
					break;

				default:
					base.GetProperty(prop);
					break;
			}
		}

		public override void SetProperty(Property property)
		{
			base.SetProperty(property);
		}

		#endregion IAccess implementation

		#region IReference implementation

		public override bool IsReferenced
		{
			get
			{
				return (timePoints.Count > 0) || base.IsReferenced;
			}
		}

		public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
		{
			if (timePoints != null && timePoints.Count > 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
			{
				references[ModelCode.REGULARINTERVALSCHEDULE_TIMEPOINTS] = timePoints.GetRange(0, timePoints.Count);
			}

			base.GetReferences(references, refType);
		}

		public override void AddReference(ModelCode referenceId, long globalId)
		{
			switch (referenceId)
			{
				case ModelCode.REGULARTIMEPOINT_INTERVALSCHEDULE:
					timePoints.Add(globalId);
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
				case ModelCode.REGULARTIMEPOINT_INTERVALSCHEDULE:

					if (timePoints.Contains(globalId))
					{
						timePoints.Remove(globalId);
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
