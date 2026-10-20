using System;

namespace freetrain.world
{
	/// <summary>
	/// Span of time
	/// </summary>
	[Serializable]
	public struct TimeLength
	{
		private TimeLength( long sec ) { totalSeconds=sec; }
		
		// create new time span objects that correspond to the specified period of the time.
		public static TimeLength fromSeconds( long sec ) { return new TimeLength(sec); }
		public static TimeLength fromMinutes( long min   ) { return new TimeLength(min*60); }
		public static TimeLength fromHours  ( long hours ) { return new TimeLength(hours*60*60); }
		public static TimeLength fromDays   ( long days)   { return TimeLength.fromHours(days*24); }
		public static TimeLength random( TimeLength min, TimeLength max ) {
			return new TimeLength( (long)
				(rnd.NextDouble()*(max.totalSeconds-min.totalSeconds)+min.totalSeconds) );
		}

		// create a time span object that represents the period until tomorrow's 0:00.
		// if the current time is just 0:00, it returns "24hours" rather than 0.
		public static TimeLength untilTomorrow() {
			Clock c = World.world.clock;
			return fromSeconds( ONEDAY.totalSeconds - ((c.hour*60+c.minutes))*60%ONEDAY.totalSeconds );
		}

		//
		// time constants
		//
		public static readonly TimeLength ZERO = new TimeLength(0);
		public static readonly TimeLength ONEDAY = new TimeLength(60*60*24);

		private static Random rnd = new Random();

		/// <summary>
		/// Time span in seconds.
		/// </summary>
		public long totalSeconds;

		public bool isPositive { get { return totalSeconds>0; } }


		public static TimeLength operator + ( TimeLength a, TimeLength b ) {
			return new TimeLength( a.totalSeconds + b.totalSeconds );
		}

		public static long operator / ( TimeLength a, TimeLength b ) {
			return( a.totalSeconds / b.totalSeconds );
		}
	}
}
