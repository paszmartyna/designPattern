﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyPattern
{
    class SpaceBookSystem
    {
        //The Subject
        private class SpaceBook
        {
            static SortedList<string, SpaceBook> community = new SortedList<string, SpaceBook>(100);
            string pages;
            string name;
            string gap = "\n\t\t\t\t";

            static public bool IsUnique(string name)
            {
                return community.ContainsKey(name);
            }

            internal SpaceBook(string n)
            {
                name = n;
                community[n] = this;
            }

            internal void Add(string s)
            {
                pages += gap + s;
                Console.WriteLine(gap + "===========" + name + "'s SpaceBook ===========");
                Console.WriteLine(pages);
                Console.WriteLine(gap + "==============================");
            }

            internal void Add(string friend, string message)
            {
                community[friend].Add(message);
            }

            internal void Poke(string who, string friend)
            {
                community[who].pages += gap + friend + " poked you";
            }
        }

        //The Proxy
        public class MySpaceBook
        {
            SpaceBook mySpaceBook;
            string password;
            string name;
            bool loggedIn = false;

            void Register()
            {
                Console.WriteLine("Let's register you for SpaceBook");
                do
                {
                    Console.WriteLine("All SpaceBook names must be unique");
                    Console.WriteLine("Type in a user name");
                    name = Console.ReadLine();
                } while (SpaceBook.IsUnique(name));

                Console.WriteLine("Type in a password: ");
                password = Console.ReadLine();
                Console.WriteLine("Thanks for registering with SpaceBook");
            }

            bool Authenticate()
            {
                Console.WriteLine("Welcome " + name + ". Please type in your password: ");
                string supplied = Console.ReadLine();
                if (supplied == password)
                {
                    loggedIn = true;
                    Console.WriteLine("logged into SpaceBook");
                    if (mySpaceBook == null)
                        mySpaceBook = new SpaceBook(name);
                    return true;
                }
                Console.WriteLine("Incorrect password");
                return false;
            }

            public void Add(string message)
            {
                Check();
                if (loggedIn) mySpaceBook.Add(message);
            }
            
            public void Add(string friend, string message)
            {
                Check();
                if (loggedIn)
                    mySpaceBook.Add(friend, name + "said: " + message);
            }

            public void Poke(string who)
            {
                Check();
                if (loggedIn)
                    mySpaceBook.Poke(who, name);
            }


            void Check()
            {
                if (!loggedIn)
                {
                    if (password == null)
                        Register();
                    if (mySpaceBook == null)
                        Authenticate();
                }
            }
        }

    }
        
}