// 2008.09.06 YZ Fixed VS2008 Warning
// 2009.02.07 YZ Fixed bug of don't ring depature bell
using System;
using System.Diagnostics;
using System.Windows.Forms;
using DxVBLibA;

namespace org.kohsuke.directaudio
{
	/// <summary>
	/// Performance ÇÃäTóvÇÃê‡ñæÇ≈Ç∑ÅB
	/// </summary>
	public class Performance : IDisposable
	{
		internal DirectMusicPerformance8 handle;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="owner">owner window object</param>
		public Performance( IWin32Window owner ) {
#region YZ_20080906_MODIFIED
//          handle = DirectAudio.dx.DirectMusicPerformanceCreate();
//			this.handle = handle;
            this.handle = DirectAudio.dx.DirectMusicPerformanceCreate();
#endregion

            DMUS_AUDIOPARAMS param = new DMUS_AUDIOPARAMS();
			DirectSound8 nullDs8 = null;

			// TODO: learn more about this initialization process
			handle.InitAudio( owner.Handle.ToInt32(),
				CONST_DMUS_AUDIO.DMUS_AUDIOF_ALL,  
				ref param,
				ref nullDs8,
				CONST_DMUSIC_STANDARD_AUDIO_PATH.DMUS_APATH_DYNAMIC_STEREO, 16 );
		}

		public void Dispose() {
			if(handle!=null) {
				handle.CloseDown();
				System.Runtime.InteropServices.Marshal.ReleaseComObject(handle);
			}
			handle = null;
		}

		/// <summary>
		/// Plays the given segment exclusively.
		/// </summary>
		public SegmentState playExclusive( Segment seg ) {
			return new SegmentState( this, 
				handle.PlaySegmentEx( seg.handle, 0, 0, null, null ),
				handle.GetMusicTime()+seg.handle.GetLength() );
		}

		/// <summary>
		/// Plays the given segment immediately.
		/// </summary>
		public SegmentState play( Segment seg ) {
			return play(seg,0);
		}

		/// <summary>
		/// Plays the given segment after the specified lead time (in milliseconds)
		/// </summary>
		public SegmentState play( Segment seg, int leadTime ) {
Debug.Print(string.Format("Performance.play1:leadTime={0}", leadTime));

            if( leadTime!=0 )
// 2009.02.07 YZ Fixed bug of don't ring depature bell
// ClockTime is method of vb interface, it's 1ms unit.
// it's convert to reference_time, estimatedEndTime is bigger value.
//				leadTime = handle.ClockToMusicTime(leadTime*10*1000 + handle.GetClockTime());
				leadTime = handle.ClockToMusicTime(leadTime + handle.GetClockTime());
// 2009.02.07 YZ Fixed bug of don't ring depature bell
			if( leadTime<0 )
				leadTime = 0;

Debug.Print(string.Format("Performance.play2:leadTime={0}", leadTime));
Debug.Print(string.Format("Performance.play3:GetMusicTime={0}", handle.GetMusicTime()));
Debug.Print(string.Format("Performance.play4:GetLength={0}", seg.handle.GetLength()));

// 2009.02.07 YZ Fixed bug of don't ring depature bell
//			return new SegmentState( this, handle.PlaySegmentEx( seg.handle,
//				CONST_DMUS_SEGF_FLAGS.DMUS_SEGF_SECONDARY, leadTime, null, null ),
//				handle.GetMusicTime()+seg.handle.GetLength()+leadTime );
			return new SegmentState( this, handle.PlaySegmentEx( seg.handle,
				CONST_DMUS_SEGF_FLAGS.DMUS_SEGF_SECONDARY, leadTime, null, null ),
				seg.handle.GetLength()+leadTime );
// 2009.02.07 YZ Fixed bug of don't ring depature bell
		}

		/// <summary>
		/// Creates an audio path from the properties of the given segment.
		/// </summary>
		public AudioPath createAudioPath( Segment seg ) {
			return new AudioPath( handle.CreateAudioPath( seg.handle.GetAudioPathConfig(), true ) );
		}
	}
}
