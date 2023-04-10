namespace CaptchaGenerator.Lib;

public class CaptchaGenerator
{
    private static readonly char[] _codeLetters = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    public static string GenerateCaptchaCode(int keyDigit = 4) => Extensions.GetUniqueKey(keyDigit, _codeLetters);

    public static CaptchaResult GenerateCaptchaImage(ushort width, ushort height, string captchaCode)
    {
        var slc = new Captcha(new CaptchaOptions
        {
            Width = width,
            Height = height,
            MaxRotationDegrees = 15,
            FontSize = GetFontSize(width, captchaCode.Length)
        });
        var captchaCodeBytes = slc.Generate(captchaCode);

        return new CaptchaResult
        {
            CaptchaCode = captchaCode,
            CaptchaByteData = captchaCodeBytes,
            Timestamp = DateTime.Now
        };
    }

    private static byte GetFontSize(int imageWidth, int captchCodeLength)
    {
        var averageSize = imageWidth / captchCodeLength * 1.2;
        return Convert.ToByte(averageSize);
    }
}