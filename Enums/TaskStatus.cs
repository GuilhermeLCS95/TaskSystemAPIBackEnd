using System.ComponentModel;

namespace TaskSystemAPIBackEnd.Enums
{
    public enum TaskStatus
    {
        [Description("A fazer")]
        ToDo = 0,
        [Description("Em andamento")]
        InProgress = 1,
        [Description("Concluído")]
        Done = 2,
    }
}
