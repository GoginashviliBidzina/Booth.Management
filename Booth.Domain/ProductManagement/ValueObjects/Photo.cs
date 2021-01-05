namespace Booth.Domain.ProductManagement.ValueObjects
{
    public class Photo
    {
        public string Url { get; private set; }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public Photo(string url,
                     int width,
                     int height)
        {
            Url = url;
            Width = width;
            Height = height;
        }
    }
}
