using Avalonia.Controls;
using Avalonia.Controls.Templates;

using ReactiveUI;

using System;

namespace ImeSense.Boilerplates.Avalonia.DataTemplates;

public class ViewDataTemplate : IDataTemplate
{
    public IControl Build(object data)
    {
        string name = data.GetType().FullName!.Replace("ViewModel", "View");
        Type? type = Type.GetType(name);
        if (type is not null)
        {
            return (Control) Activator.CreateInstance(type)!;
        }
        return new TextBlock
        {
            Text = "Not Found: " + name,
        };
    }

    public bool Match(object data)
    {
        bool result = data is ReactiveObject;
        return result;
    }
}
