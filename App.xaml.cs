using PrismUI.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using PrismUI.ViewModels;

namespace PrismUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

            // Navigation 遷移画面の登録
            containerRegistry.RegisterForNavigation<NavigationA>();
            containerRegistry.RegisterForNavigation<NavigationB>();
            containerRegistry.RegisterForNavigation<NavigationC>();
            containerRegistry.RegisterForNavigation<NavigationD>();
            containerRegistry.RegisterForNavigation<ToolsListBox>();
            containerRegistry.RegisterForNavigation<ToolsComboBox>();
            containerRegistry.RegisterForNavigation<ToolsControlEvent>();

            // Pop Up 表示画面の登録
            containerRegistry.RegisterDialog<WindowA, WindowAViewModel>();
            containerRegistry.RegisterDialog<WindowB, WindowBViewModel>();
            containerRegistry.RegisterDialog<WindowC, WindowCViewModel>();
            containerRegistry.RegisterDialog<WindowD, WindowDViewModel>();

            // Main 画面で値を受け取る設定
            containerRegistry.RegisterSingleton<MainWindowViewModel>();

        }
    }
}
