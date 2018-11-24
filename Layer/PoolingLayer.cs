using System;
namespace Layer
{
    public class PoolingLayer : ILayer<double[,]>
    {
        public int UnitNumber { get; }
        public int RowNumber { get; }
        public int ColumnNumber { get; }

        PoolingWindow window;

        public PoolingLayer(int rows, int columns, PoolingMethod method, int windowWidth, int windowHeight, int stride = 0)
        {
            UnitNumber = rows * columns;
            RowNumber = rows;
            ColumnNumber = columns;
            window = new PoolingWindow(windowWidth, windowHeight, stride);
        }

        public double[,] Forward(double[,] input)
        {
            throw new NotImplementedException();
        }

        public double[,] Backword(double[,] gradient)
        {
            throw new NotImplementedException();
        }
    }

    public enum PoolingMethod
    {
        Max,
        Average,
    }

    struct PoolingWindow
    {
        public int Width { get; }
        public int Height { get; }
        public double[,] Window { get; }
        public int Stride { get; }

        public PoolingWindow(int width, int height, int stride)
        {
            Width = width;
            Height = height;
            Stride = stride == 0 ? width : stride;
            Window = new double[width, height];
        }
    }
}
