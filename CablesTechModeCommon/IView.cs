using System;

namespace CableTechModeCommon
{
    public interface IView
    {
        ProgramDataRepository ProgramDataRepository { get; set; }

        event Action<int> ShortNameChanged;

        event Action ViewClosed;
    }
}
