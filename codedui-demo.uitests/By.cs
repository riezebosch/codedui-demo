namespace codedui_demo.uitests
{
    public sealed class By
    {

        private readonly string name;
        private readonly int value;

        public static readonly By Id = new By(1, "id");
        public static readonly By Type = new By(2, "type");
        public static readonly By Title = new By(3, "title");
        public static readonly By Text = new By(4, "");

        private By(int value, string name)
        {
            this.name = name;
            this.value = value;
        }

        public override string ToString()
        {
            return name;
        }

    }
}