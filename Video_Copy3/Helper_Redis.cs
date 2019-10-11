using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Copy3
{
    public class Helper_Redis : IDisposable
    {

        private static ConnectionMultiplexer redis = null;
        private static bool connected = false;
        private IDatabase db = null;
        private int current = 0;
        public static bool IsConnected { get { Open(); return redis.IsConnected; } }
        public static bool Test()
        {
            bool r = true;
            try
            {
                Helper_Redis.Using(rs => { rs.Use(0); });
            }
            catch (Exception e)
            {
                Helper_log.Write_Error("[Redis] test fail " + e.Message);
                r = false;
            }
            if (r) Helper_log.Write_log("[Redis] test ok.");
            return r;
        }
        private static int Open()
        {
            if (connected) return 1;
            redis = ConnectionMultiplexer.Connect("localhost:6379,password=123456,abortConnect = false");
            connected = true;
            return 1;
        }
        public static void Using(Action<Helper_Redis> a)
        {
            using (var red = new Helper_Redis())
            {
                a(red);
            }
        }
        public Helper_Redis Use(int i)
        {
            Open();
            current = i;
            db = redis.GetDatabase(i);

            //Log.Logs($"RedisDB Conntet State: {redis.IsConnected}");
            var t = db.Ping();
            //Log.Logs($"RedisDB Select {i}, Ping.{t.TotalMilliseconds}ms");
            return this;
        }

        public void Set(string key, string val, TimeSpan? ts = null)
        {
            db.StringSet(key, val, ts);
        }

        public string Get(string key)
        {
            return db.StringGet(key);
        }

        public void Remove(string key)
        {
            //db.KeyDelete(key, CommandFlags.HighPriority);
            db.KeyDelete(key);
        }

        public bool Exists(string key)
        {
            return db.KeyExists(key);
        }

        public void Dispose()
        {
            db = null;
        }

        #region Redis发布订阅

        public delegate void RedisDeletegate(string str);
        public event RedisDeletegate RedisSubMessageEvent;

        /// <summary>
        /// 订阅
        /// </summary>
        /// <param name="subChannel"></param>
        public void RedisSub(string subChannel)
        {

            redis.GetSubscriber().Subscribe(subChannel, (channel, message) => {
                RedisSubMessageEvent?.Invoke(message); //触发事件

            });

        }

        /// <summary>
        /// 发布
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="channel"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public long RedisPub<T>(string channel, string msg)
        {
            return redis.GetSubscriber().Publish(channel, msg);
            //return redis.GetSubscriber().Publish(channel, msg.Json());
        }

        /// <summary>
        /// 取消订阅
        /// </summary>
        /// <param name="channel"></param>
        public void Unsubscribe(string channel)
        {
            redis.GetSubscriber().Unsubscribe(channel);
        }

        /// <summary>
        /// 取消全部订阅
        /// </summary>
        public void UnsubscribeAll()
        {
            redis.GetSubscriber().UnsubscribeAll();
        }

        #endregion
    }
}
