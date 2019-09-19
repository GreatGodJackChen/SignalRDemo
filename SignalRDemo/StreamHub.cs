using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace SignalRDemo
{
    public class StreamHub: Hub
    {
        //public ChannelReader<int> DelayCounter(int delay)
        //{
        //    var channel = Channel.CreateUnbounded<int>();

        //    _ = WriteItems(channel.Writer, 20, delay);

        //    return channel.Reader;
        //}

        //private async Task WriteItems(ChannelWriter<int> writer, int count, int delay)
        //{
        //    for (var i = 0; i < count; i++)
        //    {
        //        await writer.WriteAsync(i);
        //        await Task.Delay(delay);
        //    }

        //    writer.TryComplete();
        //}
        public ChannelReader<Phone> DelayCounter(int delay)
        {
            var channel = Channel.CreateUnbounded<Phone>();

            _ = WriteItems(channel.Writer, 20, delay);

            return channel.Reader;
        }

        private async Task WriteItems(ChannelWriter<Phone> writer, int count, int delay)
        {
            var p=new Phone() { PhoneNo="12312",State="成功"};
            for (var i = 0; i < count; i++)
            {
                await writer.WriteAsync(p);
                await Task.Delay(delay);
            }

            writer.TryComplete();
        }
    }
    public class Phone
    {
        public string PhoneNo { get; set; }
        public string State { get; set; }
    }
}
