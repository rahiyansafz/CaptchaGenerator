namespace CaptchaGenerator.Lib;
public interface ICaptchaModule
{
    byte[] Generate(string text);
}
