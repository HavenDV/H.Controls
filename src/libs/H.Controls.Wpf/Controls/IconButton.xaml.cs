using Icon = MaterialDesignThemes.Wpf.PackIconKind;

#nullable enable

namespace H.Controls;

public partial class IconButton : Button
{
    #region Dependency Properties

    public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
        nameof(Icon),
        typeof(Icon),
        typeof(IconButton),
        new PropertyMetadata(null));

    public static readonly DependencyProperty IconWidthProperty = DependencyProperty.Register(
        nameof(IconWidth),
        typeof(double),
        typeof(IconButton),
        new PropertyMetadata(null));

    public static readonly DependencyProperty IconHeightProperty = DependencyProperty.Register(
        nameof(IconHeight),
        typeof(double),
        typeof(IconButton),
        new PropertyMetadata(null));

    public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
        nameof(Text),
        typeof(string),
        typeof(IconButton),
        new PropertyMetadata(null));

    public static readonly DependencyProperty ContentMarginProperty = DependencyProperty.Register(
        nameof(ContentMargin),
        typeof(Thickness),
        typeof(IconButton),
        new PropertyMetadata(null));

    #endregion

    #region Properties

    public Icon Icon {
        get => (Icon)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public double IconWidth {
        get => (double)GetValue(IconWidthProperty);
        set => SetValue(IconWidthProperty, value);
    }

    public double IconHeight {
        get => (double)GetValue(IconHeightProperty);
        set => SetValue(IconHeightProperty, value);
    }

    public string? Text {
        get => (string?)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public Thickness ContentMargin {
        get => (Thickness)GetValue(ContentMarginProperty);
        set => SetValue(ContentMarginProperty, value);
    }

    #endregion
}
