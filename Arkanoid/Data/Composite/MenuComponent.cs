namespace Arkanoid.Data.Composite
{
    public abstract class MenuComponent
    {
        protected string Name { get; set; }
        protected string OnClickFunction { get; set; }
        public MenuComponent(string name, string onClickFunction = "")
        {
            Name = name;
            OnClickFunction = onClickFunction;
        }
        public abstract string GetHTML();
    }
}
