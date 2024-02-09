namespace exampleBridge
{
    // abstraction
    public abstract class Box
    {
        protected IColor color;
        public Box(IColor color) { this.color = color; }
        public abstract void PaintBox();
    }

    // refined the abstraction
    // refered to the implementation of the abstraction
    // example we want the object type box, so there could be many type of box 
    public class CottonBox : Box
    {
        public CottonBox(IColor color) : base(color) { }
        public override void PaintBox()  // implement the box abstraction's behavior by calling the PaintColor(), 
                                         // what ever the color passed to the constructor will be behave here
        {
            color.PaintColor();
        }
    }

    public class StealBox : Box
    {
        public StealBox(IColor color) : base(color) { }
        public override void PaintBox()
        {
            color.PaintColor();
        }
    }


    public interface IColor  // we can say, this define the implementation's type
    {
        public void PaintColor();
    }


    // interface impl
    public class GlossColorImpl : IColor
    {
        public void PaintColor()
        {
            Console.WriteLine("Painting Gloss.");
        }
    }

    public class MateColorImpl : IColor
    {
        public void PaintColor()
        {
            Console.WriteLine("Painting Mate.");
        }
    }

    class Program
    {
        static void Main(String[] args)
        {
            // 
            IColor mateColor = new MateColorImpl();
            IColor glossColor = new GlossColorImpl();

            // 
            Box stealBox = new StealBox(mateColor); // see here, stealbox can take different behavior(ColorType), 
                                                    //  we can pass any behavior here if its type(interface) is as same as
                                                    // what the box need in the constructor(IColor)
            stealBox.PaintBox();
            //
            Box stealBox1 = new StealBox(glossColor);
            stealBox1.PaintBox();
        }

    }
}