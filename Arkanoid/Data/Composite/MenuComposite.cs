using System.Text;

namespace Arkanoid.Data.Composite
{
    public class MenuComposite : MenuComponent
    {
        private List<MenuComponent> children;
        public MenuComposite(List<MenuComponent> items, string name, string onClickFunction = "") : base(name, onClickFunction)
        {
            children = items;
        }

        public override string GetHTML()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<div style=\"padding-left: 4px;\">");
            sb.Append($"<p @onclick=\"{OnClickFunction}\">{Name}</p>");
            foreach (MenuComponent item in children)
            {
                sb.Append(item.GetHTML());
            }
            sb.Append("</div>");
            return sb.ToString();
        }
    }
}
