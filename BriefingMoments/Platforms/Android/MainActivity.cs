using Android.App;
using Android.Content.PM;
using Android.OS;

namespace BriefingMoments
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        public static MainActivity Instance { get; private set; }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait; // Bloqueia a rotação
            base.OnCreate(savedInstanceState);

            // Define esta instância para ser acessada globalmente
            Instance = this;
        }

        private string GetDownloadsPath()
        {
            string downloadsPath = string.Empty;

            if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                // Certifique-se de que "Android.OS.Environment" está acessível
                var directory = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads);
                if (directory != null)
                {
                    downloadsPath = directory.AbsolutePath;
                }
                else
                {
                    throw new Exception("Não foi possível obter o diretório de Downloads no Android.");
                }
            }

            return downloadsPath;
        }

    }
}
