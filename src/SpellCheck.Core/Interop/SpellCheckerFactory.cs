using System.Runtime.InteropServices;

namespace SpellCheck.Core.Interop
{
    [CoClass(typeof(SpellCheckerFactoryClass))]
    [Guid("8E018A9D-2415-4677-BF08-794EA61F94BB")]
    [ComImport]
    public interface SpellCheckerFactory : ISpellCheckerFactory
    {
    }
}
