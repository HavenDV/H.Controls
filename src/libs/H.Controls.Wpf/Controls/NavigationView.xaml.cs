using System.Collections;
using System.ComponentModel;
using System.Windows.Input;

namespace H.Controls;

public partial class NavigationView : HeaderedContentControl
{
    #region Dependency Properties

    public static readonly DependencyProperty ItemTemplateProperty = DependencyProperty.Register(
        nameof(ItemTemplate),
        typeof(DataTemplate),
        typeof(NavigationView),
        new PropertyMetadata(null));

    public static readonly DependencyProperty MenuItemsSourceProperty = DependencyProperty.Register(
        nameof(MenuItemsSource),
        typeof(IEnumerable),
        typeof(NavigationView),
        new PropertyMetadata(Array.Empty<string>()));

    public static readonly DependencyProperty FooterMenuItemsSourceProperty = DependencyProperty.Register(
        nameof(FooterMenuItemsSource),
        typeof(IEnumerable),
        typeof(NavigationView),
        new PropertyMetadata(Array.Empty<string>()));

    public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(
        nameof(SelectedItem),
        typeof(object),
        typeof(NavigationView),
        new PropertyMetadata(null));

    public static readonly DependencyProperty IsExpandedProperty = DependencyProperty.Register(
        nameof(IsExpanded),
        typeof(bool),
        typeof(NavigationView),
        new PropertyMetadata(false, OnIsExpandedPropertyChanged));

    public static readonly DependencyProperty ExpandCommandProperty = DependencyProperty.Register(
        nameof(ExpandCommand),
        typeof(ICommand),
        typeof(NavigationView),
        new PropertyMetadata(null));

    public static readonly DependencyProperty CollapseCommandProperty = DependencyProperty.Register(
        nameof(CollapseCommand),
        typeof(ICommand),
        typeof(NavigationView),
        new PropertyMetadata(null));

    private static void OnIsExpandedPropertyChanged(
        DependencyObject element, 
        DependencyPropertyChangedEventArgs args)
    {
        if (element is not FrameworkElement frameworkElement)
        {
            throw new ArgumentException($"Element should be {nameof(FrameworkElement)}.");
        }
        if (args.NewValue is not bool isExpanded)
        {
            throw new ArgumentException($"Value should be {nameof(Boolean)}.");
        }

        _ = VisualStateManager.GoToState(
            frameworkElement, 
            isExpanded ? "Expanded" : "Collapsed", 
            true);
    }

    public NavigationView()
    {
        ExpandCommand = new ExpandCollapseCommand(this, true);
        CollapseCommand = new ExpandCollapseCommand(this, false);
    }

    #endregion

    #region Properties

    [Bindable(true)]
    public DataTemplate? ItemTemplate { get; set; }

    [Bindable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IEnumerable MenuItemsSource {
        get => (IEnumerable)GetValue(MenuItemsSourceProperty);
        set => SetValue(MenuItemsSourceProperty, value);
    }

    [Bindable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IEnumerable FooterMenuItemsSource {
        get => (IEnumerable)GetValue(FooterMenuItemsSourceProperty);
        set => SetValue(FooterMenuItemsSourceProperty, value);
    }

    [Bindable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public object? SelectedItem {
        get => GetValue(SelectedItemProperty);
        set => SetValue(SelectedItemProperty, value);
    }

    [Bindable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsExpanded
    {
        get => (bool)GetValue(IsExpandedProperty);
        set => SetValue(IsExpandedProperty, value);
    }

    [Bindable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ICommand ExpandCommand
    {
        get => (ICommand)GetValue(ExpandCommandProperty);
        set => SetValue(ExpandCommandProperty, value);
    }

    [Bindable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ICommand CollapseCommand
    {
        get => (ICommand)GetValue(CollapseCommandProperty);
        set => SetValue(CollapseCommandProperty, value);
    }

    #endregion
}
