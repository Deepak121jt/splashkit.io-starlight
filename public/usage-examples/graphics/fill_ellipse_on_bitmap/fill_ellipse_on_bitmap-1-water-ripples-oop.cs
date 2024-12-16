using SplashKitSDK;

namespace FillEllipseOnBitmap
{
    public class Program
    {
        public static void Main()
        {
            // Create a window and bitmap for the water surface
            Window window = new Window("Window", 400, 300);
            Bitmap bitmap = new Bitmap("water", 400, 300);

            // Fill background with light blue
            bitmap.Clear(Color.RGBAColor(200, 230, 255, 255));

            // Create different blue tones for ripples (from most opaque to most transparent)
            Color[] rippleColors = {
                Color.RGBAColor(100, 150, 255, 100),
                Color.RGBAColor(120, 170, 255, 80),
                Color.RGBAColor(140, 190, 255, 60),
                Color.RGBAColor(160, 210, 255, 40),
                Color.RGBAColor(180, 230, 255, 20)
            };

            // Create ripple effect with concentric ellipses
            double centerX = 200;  // Center of the bitmap
            double centerY = 150;
            for (int i = 0; i < rippleColors.Length; i++)
            {
                // Larger ellipses with decreasing size from center
                bitmap.FillEllipse(rippleColors[i],
                                 centerX - (100 + i * 30),  // x gets further from center
                                 centerY - (75 + i * 20),   // y gets further from center
                                 200 + i * 60,              // width increases for outer ripples
                                 150 + i * 40);             // height increases for outer ripples
            }

            while (!window.CloseRequested)
            {
                SplashKit.ProcessEvents();
                // Draw the bitmap to the window
                window.DrawBitmap(bitmap, 0, 0);
                SplashKit.RefreshScreen();
            }

            bitmap.Free();
            SplashKit.CloseAllWindows();
        }
    }
}