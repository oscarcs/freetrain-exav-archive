using System;
using System.Diagnostics;
using DxVBLibA;

namespace org.kohsuke.directaudio
{
	/// <summary>
	/// SegmentState ÇÃäTóvÇÃê‡ñæÇ≈Ç∑ÅB
	/// </summary>
	public class SegmentState
	{
		internal SegmentState( Performance perf, DirectMusicSegmentState8 state, int endTime ) {
			this.performance = perf;
			this.state = state;
			this.estimatedEndTime = endTime;
		}

		private readonly Performance performance;
		private readonly DirectMusicSegmentState8 state;
		private readonly int estimatedEndTime;

		/// <summary>
		/// Returns true if this segment is still being played.
		/// </summary>
		public bool isPlaying {
			get {
Debug.Print(string.Format("SegmentState.isPlaying1:estimatedEndTime={0}", estimatedEndTime));
Debug.Print(string.Format("SegmentState.isPlaying2:GetMusicTime={0}", performance.handle.GetMusicTime()));

                if( performance.handle.IsPlaying(null,state) )
					return true;

				if( performance.handle.GetMusicTime() < estimatedEndTime )
					return true;

//				// because of the latency, sometimes this method false even if it's not being played yet.
//				// thus make sure that it has the reasonable start time.
//				int currentTime = performance.handle.GetMusicTime();
//				if( currentTime <= state.GetStartTime() )
//					return true;	// this will be played in a future
				
				return false;
			}
		}
	}
}
