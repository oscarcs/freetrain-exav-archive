// 2010.04.21 riorio fixed
using System;
using System.Xml;
using System.Diagnostics;
using freetrain.framework.plugin;
using freetrain.contributions.population;

namespace freetrain.world.soccerstadium
{
	/// <summary>
	/// Population implementation for soccer stadium.
	/// </summary>
	[Serializable]
	public class PopulationImpl : Population
	{
        public PopulationImpl( XmlElement e ) {}
		public PopulationImpl( ) { }

		// nobody is living in a stadium.
		public override int residents { get { return 1; } }

        private int _populs = 10;

        public int populs {
          get { return _populs; }
          set { _populs = value; }
        }

        private int _baseP = 10;

        public int baseP {
          get { return _baseP; }
          set { _baseP = value; }
        }
        /// <summary>
		/// Computes the population of the given structure at the given time.
		/// </summary>
		public override int calcPopulation( Time currentTime ) {
            
            Debug.Print("return _populs "+_populs);
			return _populs;
		}
	}
}
