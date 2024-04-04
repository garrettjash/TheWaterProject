namespace TheWaterProject.Models
{
    public class Cart
    {
        // store a list of lines - the = new says if we didn't have one built before then build a new one
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        //pass in project and quantity
        public virtual void AddItem(Project p, int quantity)
        {
            // build an instance where it's equal to the projectID
            CartLine? line = Lines
                .Where(x => x.Project.ProjectId == p.ProjectId)
                .FirstOrDefault();

            if (line == null) 
            {
                Lines.Add(new CartLine()
                {
                    Project = p,
                    Quantity = quantity
                });
            }
            else 
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Project p) => Lines.RemoveAll(x => x.Project.ProjectId == p.ProjectId);

        public virtual void Clear() => Lines.Clear();

        public virtual decimal CalculateTotal() => Lines.Sum(x => 25 * x.Quantity);
/*        {
            // The lambda function essentill does this
            var blah = Lines.Sum(x => 25 * x.Quantity);

            return blah
        }*/

        public class CartLine
        {
            public int CartlineID { get; set; }
            public Project Project { get; set; }
            public int Quantity { get; set; }
        }
    }
}
