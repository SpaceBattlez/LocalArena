using System;

namespace SpaceBattlez.GameElements
{
	public class Vector
	{
		public int X;
		public int Y;

		public Vector(int x, int y)
		{
			X = x;
			Y = y;
		}

		public double Distance(Vector t)
		{
			return Math.Sqrt((t.X - X) * (t.X - X) + (t.Y - Y) * (t.Y - Y));
		}

		public void Rotate(double angleDeg)
		{
			var rad = angleDeg * (Math.PI / 180);

			double cosv = Math.Cos(rad);
			double sinv = Math.Sin(rad);

			double xx = X * cosv - Y * sinv;
			double yy = Y * cosv + X * sinv;

			X = (int)Math.Round(xx);
			Y = (int)Math.Round(yy);

			//X = xx;
			//Y = yy;
		}

		public override string ToString()
		{
			return $"({X},{Y})";
		}
	}
}