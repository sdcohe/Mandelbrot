using System.Configuration;

namespace Mandelbrot.Classes
{
    [Serializable]
    internal class MandelbrotSettings : ApplicationSettingsBase
    {
        [UserScopedSettingAttribute()]
        [DefaultSettingValueAttribute("128")]
        public int NumberOfIterations
        {
            get => (int)this[nameof(NumberOfIterations)];
            set => this[nameof(NumberOfIterations)] = value;
        }
        [UserScopedSettingAttribute()]
        [DefaultSettingValueAttribute("1.5")]
        public float PaletteMultiplier
        {
            get => (float)this[nameof(PaletteMultiplier)];
            set => this[nameof(PaletteMultiplier)] = value;
        }

        [UserScopedSettingAttribute()]
        [DefaultSettingValueAttribute("")]
        public MandelbrotCoordinates StartCoordinates
        {
            get => (MandelbrotCoordinates)this[nameof(StartCoordinates)];
            set => this[nameof(StartCoordinates)] = value;
        }
    }
}
