using System;
using System.Collections.Generic;

// Mensagens
abstract class Message
{
    public string Text { get; protected set; }
    public DateTime SendDate { get; protected set; }

    public Message(string text)
    {
        Text = text;
        SendDate = DateTime.Now;
    }

    public abstract void PrintInfo();
}

class TextMessage : Message
{
    public TextMessage(string text) : base(text) { }

    public override void PrintInfo()
    {
        Console.WriteLine($"[Texto] " +
            $"Mensagem: {Text} | " +
            $"Data Envio: {SendDate}");
    }
}

class VideoMessage : Message
{
    public string FileName { get; private set; }
    public string Format { get; private set; }
    public double Duration { get; private set; }

    public VideoMessage(string text, string fileName, string format, double duration)
        : base(text)
    {
        FileName = fileName;
        Format = format;
        Duration = duration;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"[Vídeo] " +
            $"Mensagem: {Text} | " +
            $"Arquivo: {FileName} | " +
            $"Formato: {Format} | " +
            $"Duração: {Duration} seg | " +
            $"Data Envio: {SendDate}");
    }
}

class PhotoMessage : Message
{
    public string FileName { get; private set; }
    public string Format { get; private set; }

    public PhotoMessage(string text, string fileName, string format)
        : base(text)
    {
        FileName = fileName;
        Format = format;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"[Foto] " +
            $"Mensagem: {Text} | " +
            $"Arquivo: {FileName} | " +
            $"Formato: {Format} | " +
            $"Data Envio: {SendDate}");
    }
}

class FileMessage : Message
{
    public string FileName { get; private set; }
    public string Format { get; private set; }

    public FileMessage(string text, string fileName, string format)
        : base(text)
    {
        FileName = fileName;
        Format = format;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"[Arquivo] " +
            $"Mensagem: {Text} | " +
            $"Arquivo: {FileName} | " +
            $"Formato: {Format} | " +
            $"Data Envio: {SendDate}");
    }
}

// Canais
abstract class Channel
{
    public abstract void Send(Message message);
}

class WhatsAppChannel : Channel
{
    private string PhoneNumber;

    public WhatsAppChannel(string phoneNumber)
    {
        PhoneNumber = phoneNumber;
    }

    public override void Send(Message message)
    {
        Console.WriteLine($"Enviando pelo WhatsApp para {PhoneNumber}...");
        message.PrintInfo();
        Console.WriteLine();
    }
}

class TelegramChannel : Channel
{
    private string Contact;

    public TelegramChannel(string contact)
    {
        Contact = contact;
    }

    public override void Send(Message message)
    {
        Console.WriteLine($"Enviando pelo Telegram para {Contact}...");
        message.PrintInfo();
        Console.WriteLine();
    }
}

class FacebookChannel : Channel
{
    private string Username;

    public FacebookChannel(string username)
    {
        Username = username;
    }

    public override void Send(Message message)
    {
        Console.WriteLine($"Enviando pelo Facebook para {Username}...");
        message.PrintInfo();
        Console.WriteLine();
    }
}

class InstagramChannel : Channel
{
    private string Username;

    public InstagramChannel(string username)
    {
        Username = username;
    }

    public override void Send(Message message)
    {
        Console.WriteLine($"Enviando pelo Instagram para {Username}...");
        message.PrintInfo();
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var messages = new List<Message>
        {
            new TextMessage("Olá! Como vai?"),
            new VideoMessage("Confira este vídeo.", "video.mp4", "mp4", 120.5),
            new PhotoMessage("Veja essa foto.", "foto.jpg", "jpg"),
            new FileMessage("Segue o arquivo.", "documento.pdf", "pdf")
        };

        var channels = new List<Channel>
        {
            new WhatsAppChannel("+5511999999999"),
            new TelegramChannel("+5511888888888"),
            new TelegramChannel("usuarioTelegram"),
            new FacebookChannel("usuarioFacebook"),
            new InstagramChannel("usuarioInstagram")
        };

        // Enviar cada mensagem em todos os canais compatíveis
        foreach (var msg in messages)
        {
            foreach (var ch in channels)
            {
                // WhatsApp e Telegram aceitam telefone
                if ((ch is WhatsAppChannel || ch is TelegramChannel) && ch is TelegramChannel telegram && long.TryParse(telegram.ToString(), out _))
                {
                    ch.Send(msg);
                }
                else
                {
                    ch.Send(msg);
                }
            }
        }
    }
}
