using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

namespace Arkanoid.Data.Composite
{
    public class MenuItem : MenuComponent
    {
        public MenuItem(string name, string onClickFunction = "") : base(name, onClickFunction)
        {

        }

        public override string GetHTML()
        {
            return $"<button class=\"btn btn-primary\" @onclick=\"{OnClickFunction}\">{Name}</button>";
        }
    }
}
