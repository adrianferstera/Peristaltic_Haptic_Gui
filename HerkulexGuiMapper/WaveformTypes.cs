using System;
using System.Collections.Generic;
using System.Text;

namespace HerkulexGuiMapper
{
    /// <summary>
    /// All possible waveform types which can be generated.
    /// </summary>
    public enum WaveformType
    {
        Sine, 
        Triangle, 
        SineTriangle, 
        TriangleSine,
        PositiveSawtooth, 
        NegativeSawtooth
    }
}
