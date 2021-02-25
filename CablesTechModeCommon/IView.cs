using System;

namespace CableTechModeCommon
{
    public interface IView
    {
        ProgramDataRepository ProgramDataRepository { get; set; }
        void SetProgramData();
        event Action<int> ShortNameChanged;
    }
}
