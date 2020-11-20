namespace LexLetsManagement
{
    class Designer
    {
        float size; //  In mm
        float angle;
        readonly float radius; // in pixels
        string name;

        public Designer(float size, string name)
        {
            this.size = size;
            this.name = name;
            this.radius = ((this.size * 96f) / 25.4f) / 2f;
        }
        public float Radius
        {
            get { return radius; }
            set { this.Radius = ((this.size * 96f) / 25.4f) / 2f; }
        }
        public float Size
        {
            set { size = value; }
            get { return size; }
        }
        public float Angle
        {
            set { angle = value; }
            get { return angle; }
        }
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        private float ConvertMmToPixels(float diameter)
        {
            return diameter * 3.7795275591f;
        }
    }
}
