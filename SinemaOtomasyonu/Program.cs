namespace SinemaOtomasyonu
{
    /*
 PROJE : Sinema Otomasyonu
    032290001 Ay�eg�l BEK�EN
    032290007 Ahmet Eren ���NC�
    032290036 Alperen TOPAK
    032290085 Enes Berke KARAO�LAN
    032290034 Emirhan TOZLU
    032290084 Muhammed Kaan K���K

DERS KODU : BMB2006
DOSYA ADI : 26_SinemaOtomasyonu*/
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new GirisForm1());
        }
    }
}