using System.Windows;
using WPF_MVVM_CV19.Infrastructure.Commands.Base;

namespace WPF_MVVM_CV19.Infrastructure.Commands
{
    internal class CloseApplicationCommand : Command
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter) => Application.Current.Shutdown();
    }
}
