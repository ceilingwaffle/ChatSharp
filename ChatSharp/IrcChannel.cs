﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatSharp
{
    public class IrcChannel
    {
        private IrcClient Client { get; set; }

        internal string _Topic;
        public string Topic 
        {
            get
            {
                return _Topic;
            }
            set
            {
                Client.SetTopic(Name, value);
                _Topic = value;
            }
        }

        public string Name { get; internal set; }
        public string Mode { get; internal set; }
        public UserCollection Users { get; private set; }
        public UserCollection Opped { get; private set; }
        public UserCollection Voiced { get; private set; }
        public MaskCollection Bans { get; private set; }
        public MaskCollection Exceptions { get; private set; }
        public MaskCollection Quiets { get; private set; }
        public MaskCollection Invites { get; private set; }

        internal IrcChannel(IrcClient client, string name)
        {
            Client = client;
            Users = new UserCollection();
            Opped = new UserCollection();
            Voiced = new UserCollection();
            Bans = new MaskCollection();
            Exceptions = new MaskCollection();
            Quiets = new MaskCollection();
            Invites = new MaskCollection();
            Name = name;
        }

        public void Part()
        {
            Client.PartChannel(Name);
        }

        public void Part(string reason)
        {
            Client.PartChannel(Name);
        }

        public void GetBanList(Action<IrcChannel> callback)
        {
            Client.GetBanList(Name, bans =>
                {
                    if (callback != null)
                        callback(this);
                });
        }

        public void GetExceptionList(Action<IrcChannel> callback)
        {
            Client.GetExceptionList(Name, exceptions =>
            {
                if (callback != null)
                    callback(this);
            });
        }

        public void GetQuietList(Action<IrcChannel> callback)
        {
            Client.GetQuietList(Name, quiets =>
            {
                if (callback != null)
                    callback(this);
            });
        }

        public void GetInviteList(Action<IrcChannel> callback)
        {
            Client.GetInviteList(Name, invites =>
            {
                if (callback != null)
                    callback(this);
            });
        }
    }
}
