namespace Manager.Theme
{
    internal class DrawItemEx
    {

        public static void Draw(DrawItemEventArgs e, Image image, string text, Color fore, Color selected)
        {
            e.DrawBackground();
            if (e.State.HasFlag(DrawItemState.Selected))
            {
                e.Graphics.FillRectangle(new SolidBrush(selected), e.Bounds);
            }

            const int imgSize = 32;

            e.Graphics.DrawImage(image, e.Bounds.X + 10, e.Bounds.Y + ((e.Bounds.Height - imgSize) / 2), imgSize, imgSize);

            var textSize = e.Graphics.MeasureString("A", e.Font);
            e.Graphics.DrawString(text, e.Font, new SolidBrush(fore), e.Bounds.X + imgSize + 20, e.Bounds.Y + ((e.Bounds.Height - textSize.Height) / 2));
            e.DrawFocusRectangle();
        }

    }
}
