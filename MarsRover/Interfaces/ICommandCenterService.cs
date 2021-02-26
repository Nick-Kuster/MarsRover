using MarsRover.ViewModels;

namespace MarsRover.Interfaces
{
    public interface ICommandCenterService
    {
        CommandCenterViewModel ExecuteCommands(CommandCenterViewModel model);
    }
}
