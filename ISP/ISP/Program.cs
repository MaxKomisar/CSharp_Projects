using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public interface IMessage
    {
        void Send();
        string ToAddres { get; set; }
        string FromAddres { get; set; }
    }

    public interface IEmailMessage : IMessage
    {
        string Subject { get; set; }
    }

    public interface IVoiceMessage : IMessage
    {
        byte[] Voice { get; set; }
    }

    public interface ITextMessage : IMessage
    {
        string Text { get; set; }
    }

    public class EmailMessage : IEmailMessage
    {
        public string Text { get; set; }
        public string Subject { get; set; }
        public string ToAddres { get; set; }
        public string FromAddres { get; set; }

        public void Send()
        {
            Console.WriteLine("Send email message:{0}",Text);
        }
    }

    
    public class SmsMessage : ITextMessage
    {
        public string Text { get; set; }
        public string ToAddres { get; set; }
        public string FromAddres { get; set; }
        

        public void Send()
        {
            Console.WriteLine("Send message sms: {0}",Text);
        }
    }

   public class VoiceMessage : IVoiceMessage
    {
        public string ToAddres { get; set; }
        public string FromAddres { get; set; }

        public byte[] Voice { get; set; }
        public void Send()
        {
            Console.WriteLine("Передача голосовой почты");
        }
    }


    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///

    interface ICall
    {
        void Call();
    }
    interface IPhoto
    {
        void TakePhoto();
    }
    interface IVideo
    {
        void MakeVideo();
    }
    interface IWeb
    {
        void BrowseInternet();
    }

    class Camera : IPhoto
    {
        public void TakePhoto()
        {
            Console.WriteLine("Фотографируем с помощью фотокамеры");
        }
    }

    class Phone : ICall, IPhoto, IVideo, IWeb
    {
        public void Call()
        {
            Console.WriteLine("Звоним");
        }
        public void TakePhoto()
        {
            Console.WriteLine("Фотографируем с помощью смартфона");
        }
        public void MakeVideo()
        {
            Console.WriteLine("Снимаем видео");
        }
        public void BrowseInternet()
        {
            Console.WriteLine("Серфим в интернете");
        }
    }

}
