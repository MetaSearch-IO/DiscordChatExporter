using System.Threading;
using System.Threading.Tasks;

namespace DiscordChatExporter.Core.Utils.Extensions;

public static class LoggingExtensions
{
    static ReaderWriterLockSlim locker = new ReaderWriterLockSlim();

    public static void WriteDebug(this string text, string path)
    {
        try
        {
            locker.EnterWriteLock();
            System.IO.File.AppendAllLines(path, new[] { text });
        }
        finally
        {
            locker.ExitWriteLock();
        }
    }
}