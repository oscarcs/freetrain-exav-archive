using System;

namespace freetrain.world.rail.tattc
{
	/// <summary>
	/// Determines the time of stop at statins.
	/// </summary>
	[Serializable]
	internal abstract class StationHandler
	{
		internal abstract TimeLength getStopTimeSpan( Train train, int callCount );

		internal static readonly StationHandler defaultHandler =
			new FixedDurationStationHandler( TimeLength.fromSeconds(60), false );
	}



	/// <summary>
	/// Always pass.
	/// </summary>
	[Serializable]
	internal class PassStationHandler : StationHandler {
		internal override TimeLength getStopTimeSpan( Train train, int callCount ) {
			return TimeLength.ZERO;
		}
	}



	/// <summary>
	/// Always stop the fixed amount of time.
	/// </summary>
	[Serializable]
	internal class FixedDurationStationHandler : StationHandler {
		internal FixedDurationStationHandler( TimeLength ts, bool turnAround ) {
			duration = ts;
			this.turnAround = turnAround;
		}

		public readonly TimeLength duration;
		public bool turnAround;

		internal override TimeLength getStopTimeSpan( Train train, int callCount ) {
			if( callCount==0 )	return duration;
			else {
				if(turnAround)	return TimeLength.fromSeconds(-1);
				else			return TimeLength.ZERO;
			}
		}
	}



	/// <summary>
	/// Always depart at the given time
	/// </summary>
	[Serializable]
	internal class OnceADayStationHandler : StationHandler {
		internal OnceADayStationHandler( int s, bool turnAround ) {
			seconds=s;
			this.turnAround = turnAround;
		}
		
		/// <summary>
		/// Total minutes & seconds from the beginning of a day.
		/// </summary>
		public int seconds;

		public bool turnAround;

		internal override TimeLength getStopTimeSpan( Train train, int callCount ) {
			if( callCount!=0 ) {
				if(turnAround)	return TimeLength.fromSeconds(-1);
				else			return TimeLength.ZERO;
			}
			
			Clock c = World.world.clock;

			int s = (c.hour*60 + c.minutes)*60;

			if( seconds>s )		return TimeLength.fromSeconds( seconds-s );
			else				return TimeLength.fromSeconds( seconds-s ) + TimeLength.ONEDAY;
		}
	}




}
